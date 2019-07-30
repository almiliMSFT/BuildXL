﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace BuildXL.Execution.Analyzer.JPath
{
    public class AstException : Exception
    {
        public AstException(string message) : base(message) { }
    }

    class AstConverter : JPathBaseVisitor<Expr>
    {
        private AstException AstError(IToken token, string message)
        {
            return new AstException($"({token.Line}:{token.Column}) :: {message}");
        }

        public override Expr VisitFilterExpr([NotNull] JPathParser.FilterExprContext context)
        {
            return new FilterExpr(lhs: context.Lhs.Accept(this), filter: context.Filter.Accept(this));
        }

        public override Expr VisitIntLitExpr([NotNull] JPathParser.IntLitExprContext context)
        {
            if (!int.TryParse(context.GetText(), out var value))
            {
                var token = context.Value;
                throw AstError(context.Value, $"Value '{context.GetText()}' is not a valid integer literal");
            }

            return new IntLit(value);
        }

        public override Expr VisitMapExpr([NotNull] JPathParser.MapExprContext context)
        {
            return new MapExpr(context.Lhs.Accept(this), context.PropertyName.Text);
        }

        public override Expr VisitRangeExpr([NotNull] JPathParser.RangeExprContext context)
        {
            return new RangeExpr(
                array: context.Lhs.Accept(this),
                begin: int.Parse(context.Begin.Text),
                end: int.Parse(context.End.Text));
        }

        public override Expr VisitIndexExpr([NotNull] JPathParser.IndexExprContext context)
        {
            var idx = int.Parse(context.Index.Text);
            return new RangeExpr(
                array: context.Lhs.Accept(this),
                begin: idx,
                end: idx);
        }

        public override Expr VisitRegExLitExpr([NotNull] JPathParser.RegExLitExprContext context)
        {
            try
            {
                var regex = new Regex(context.Value.Text);
                return new RegexLit(regex);
            }
            catch (ArgumentException e)
            {
                throw AstError(context.Value, $"Value '{context.Value}' is not a valid regex: {e.Message}");
            }
        }

        public override Expr VisitRootExpr([NotNull] JPathParser.RootExprContext context)
        {
            return new RootExpr();
        }

        public override Expr VisitSelectorExpr([NotNull] JPathParser.SelectorExprContext context)
        {
            return new Selector(context.PropertyName.Text);
        }

        public override Expr VisitStrLitExpr([NotNull] JPathParser.StrLitExprContext context)
        {
            return new StrLit(context.Value.Text.Trim('"', '\''));
        }

        public override Expr VisitSubExpr([NotNull] JPathParser.SubExprContext context)
        {
            return context.Sub.Accept(this);
        }

        public override Expr VisitExprBoolExpr([NotNull] JPathParser.ExprBoolExprContext context)
        {
            return context.Expr.Accept(this);
        }

        public override Expr VisitBinaryBoolExpr([NotNull] JPathParser.BinaryBoolExprContext context)
        {
            return new BinaryExpr(context.Op.Token, context.Lhs.Accept(this), context.Rhs.Accept(this));
        }

        public override Expr VisitUnaryBoolExpr([NotNull] JPathParser.UnaryBoolExprContext context)
        {
            return new UnaryExpr(context.Op.Token, context.Sub.Accept(this));
        }

        public override Expr VisitSubBoolExpr([NotNull] JPathParser.SubBoolExprContext context)
        {
            return context.Sub.Accept(this);
        }

        public override Expr VisitBoolLogicExpr([NotNull] JPathParser.BoolLogicExprContext context)
        {
            return context.Expr.Accept(this);
        }

        public override Expr VisitBinaryLogicExpr([NotNull] JPathParser.BinaryLogicExprContext context)
        {
            return new BinaryExpr(context.Op.GetText(), context.Lhs.Accept(this), context.Rhs.Accept(this));
        }

        public override Expr VisitUnaryLogicExpr([NotNull] JPathParser.UnaryLogicExprContext context)
        {
            return new UnaryExpr(context.Op.GetText(), context.Sub.Accept(this));
        }

        public override Expr VisitSubLogicExpr([NotNull] JPathParser.SubLogicExprContext context)
        {
            return context.Sub.Accept(this);
        }
    }
}