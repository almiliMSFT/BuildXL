// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
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
            return new MapExpr(context.Lhs.Accept(this), (Selector)context.Selector.Accept(this));
        }

        public override Expr VisitRangeExpr([NotNull] JPathParser.RangeExprContext context)
        {
            return new RangeExpr(
                array: context.Lhs.Accept(this),
                begin: context.Begin.Accept(this),
                end: context.End.Accept(this));
        }

        public override Expr VisitIndexExpr([NotNull] JPathParser.IndexExprContext context)
        {
            return new RangeExpr(
                array: context.Lhs.Accept(this),
                begin: context.Index.Accept(this),
                end: null);
        }

        public override Expr VisitRegExLitExpr([NotNull] JPathParser.RegExLitExprContext context)
        {
            try
            {
                var regex = new Regex(context.Value.Text.Trim('/', '!'));
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
            return context.Sub.Accept(this);
        }

        public override Expr VisitIdSelector([NotNull] JPathParser.IdSelectorContext context)
        {
            return new Selector(context.PropertyName.Text); 
        }

        public override Expr VisitEscIdSelector([NotNull] JPathParser.EscIdSelectorContext context)
        {
            return new Selector(context.PropertyName.Text.Trim('`'));
        }

        public override Expr VisitStrLitExpr([NotNull] JPathParser.StrLitExprContext context)
        {
            return new StrLit(context.Value.Text.Trim('"', '\''));
        }

        public override Expr VisitSubExpr([NotNull] JPathParser.SubExprContext context)
        {
            return context.Sub.Accept(this);
        }

        public override Expr VisitExprIntExpr([NotNull] JPathParser.ExprIntExprContext context)
        {
            return context.Expr.Accept(this);
        }

        public override Expr VisitUnaryIntExpr([NotNull] JPathParser.UnaryIntExprContext context)
        {
            return new UnaryExpr(context.Op.Token.Type, context.Sub.Accept(this));
        }

        public override Expr VisitBinaryIntExpr([NotNull] JPathParser.BinaryIntExprContext context)
        {
            return new BinaryExpr(context.Op.Token.Type, context.Lhs.Accept(this), context.Rhs.Accept(this));
        }

        public override Expr VisitSubIntExpr([NotNull] JPathParser.SubIntExprContext context)
        {
            return context.Sub.Accept(this);
        }

        public override Expr VisitBinaryBoolExpr([NotNull] JPathParser.BinaryBoolExprContext context)
        {
            return new BinaryExpr(context.Op.Token.Type, context.Lhs.Accept(this), context.Rhs.Accept(this));
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
            return new BinaryExpr(context.Op.Token.Type, context.Lhs.Accept(this), context.Rhs.Accept(this));
        }

        public override Expr VisitUnaryLogicExpr([NotNull] JPathParser.UnaryLogicExprContext context)
        {
            return new UnaryExpr(context.Op.Token.Type, context.Sub.Accept(this));
        }

        public override Expr VisitSubLogicExpr([NotNull] JPathParser.SubLogicExprContext context)
        {
            return context.Sub.Accept(this);
        }

        public override Expr VisitFuncExpr([NotNull] JPathParser.FuncExprContext context)
        {
            return context.Func.Accept(this);
        }

        public override Expr VisitPipeExpr([NotNull] JPathParser.PipeExprContext context)
        {
            return new PipeExpr(context.Input.Accept(this), (FuncExpr)context.Func.Accept(this));
        }

        public override Expr VisitFunc([NotNull] JPathParser.FuncContext context)
        {
            return new FuncExpr(context.Name.Text, context._Args.Select(arg => arg.Accept(this)));
        }
    }
}