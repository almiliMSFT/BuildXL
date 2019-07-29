// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using BuildXL.FrontEnd.Script.Debugger;

namespace BuildXL.Execution.Analyzer.JPath
{
    public class Env
    {
        public Func<object, ObjectInfo> GetObjectInfo { get; }
        public object Root { get; }
        public IEnumerable<object> Current { get; }

        public Env(Func<object, ObjectInfo> getObjectInfo, object root, IEnumerable<object> current)
        {
            GetObjectInfo = getObjectInfo;
            Root = root;
            Current = current;
        }

        internal Env WithCurrent(IEnumerable<object> newCurrent)
        {
            return new Env(GetObjectInfo, Root, newCurrent);
        }
    }

    public static class Converter
    {
        public static string TokenName(this int tokenType)
        {
            return JPathLexer.DefaultVocabulary.GetSymbolicName(tokenType);
        }

        public static int ToInt(this object obj)
        {
            switch (obj)
            {
                case IEnumerable<object> arr:
                    var first = arr.FirstOrDefault();
                    return first == null ? false : first.ToInt();
            }
        }

        public static bool ToBool(this object obj)
        {
            switch (obj)
            {
                case IEnumerable<object> arr:
                    var first = arr.FirstOrDefault();
                    return first == null ? false : first.ToBool();
                case string str:
                    return !string.IsNullOrEmpty(str);
                case bool b:
                    return b;
                case int i:
                    return i != 0;
                default:
                    return false;
            }
        }

    }


    public abstract class Expr
    {
        public abstract string Print();

        public abstract IEnumerable<object> Eval(Env env);
    }

    public sealed class Selector : Expr
    {
        public string PropertyName { get; }

        public Selector(string propertyName)
        {
            PropertyName = propertyName;
        }

        public override string Print() => PropertyName;

        public override IEnumerable<object> Eval(Env env)
        {
            return env.Current
                .Select(env.GetObjectInfo)
                .SelectMany(obj => obj.Properties.Where(p => p.Name == PropertyName))
                .Select(prop => prop.Value);
        }

    }

    public sealed class IntLit : Expr
    {
        public int Value { get; }

        public IntLit(int value)
        {
            Value = value;
        }

        public override string Print() => Value.ToString();

        public override IEnumerable<object> Eval(Env env) => new object[] { Value };
    }

    public sealed class StrLit : Expr
    {
        public string Value { get; }

        public StrLit(string value)
        {
            Value = value;
        }

        public override string Print() => $"'{Value}'";

        public override IEnumerable<object> Eval(Env env) => new object[] { Value };
    }

    public sealed class RegexLit : Expr
    {
        public Regex Value { get; }

        public RegexLit(Regex value)
        {
            Value = value;
        }

        public override string Print() => $"/{Value}/";

        public override IEnumerable<object> Eval(Env env) => new object[] { Value };
    }

    public sealed class RangeExpr : Expr
    {
        public Expr Begin { get; } // inclusive, can be negative
        public Expr End { get; }   // inclusive, can be negative

        public RangeExpr(Expr begin, Expr end)
        {
            Begin = begin;
            End = end;
        }

        public override string Print() => $"{Begin.Print()}..{End.Print()}";

        public override IEnumerable<object> Eval(Env env)
        {
            var begin = Begin.Eval(env);
            var end = End.Eval(env);
            return new object[] { new Pair<object, object>(begin, end) };
        }
    }

    public sealed class MapExpr : Expr
    {
        public Expr Lhs { get; }
        public string PropertyName { get; }

        public MapExpr(Expr lhs, string propertyName)
        {
            Lhs = lhs;
            PropertyName = propertyName;
        }

        public override string Print() => $"{Lhs.Print()}.{PropertyName}";

        public override IEnumerable<object> Eval(Env env)
        {
            var lhs = Lhs.Eval(env);
            return new Selector(PropertyName).Eval(env.WithCurrent(lhs));
        }
    }

    public class FilterExpr : Expr
    {
        public Expr Lhs { get; }
        public Expr Filter { get; }

        public FilterExpr(Expr lhs, Expr filter)
        {
            Lhs = lhs;
            Filter = filter;
        }

        public override string Print() => $"{Lhs.Print()}[{Filter.Print()}]";

        public override IEnumerable<object> Eval(Env env)
        {
            return Lhs
                .Eval(env)
                .Where(obj => Filter.Eval(env.WithCurrent(new[] { obj })).ToBool());
        }
    }

    public class UnaryExpr : Expr
    {
        public string Op { get; }
        public Expr Sub { get; }

        public UnaryExpr(string op, Expr sub)
        {
            Op = op;
            Sub = sub;
        }

        public override string Print() => $"({Op} {Sub.Print()})";

        public override IEnumerable<object> Eval(Env env)
        {
            var sub = Sub.Eval(env);
            switch (Op)
            {
                case JPathLexer.NOT.TokenName():

                case JPathLexer.MINUS.TokenName():
                    return new object[] { -sub.ToInt() };
            }
        }
    }

    public class BinaryExpr : Expr
    {
        public string Op { get; }
        public Expr Lhs { get; }
        public Expr Rhs { get; }

        public BinaryExpr(string op, Expr lhs, Expr rhs)
        {
            Op = op;
            Lhs = lhs;
            Rhs = rhs;
        }

        public override string Print() => $"({Lhs.Print()} {Op} {Rhs.Print()})";
    }

    public class RootExpr : Expr
    {
        public override string Print() => "$";
    }

    class JPathListener : IAntlrErrorListener<IToken>
    {
        public string FirstError { get; private set; }

        public bool HasErrors => FirstError != null;

        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            if (FirstError == null)
            {
                FirstError = msg;
            }
        }
    }

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
            return new RangeExpr(begin: context.Begin.Accept(this), end: context.End.Accept(this));
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
            return new BinaryExpr(context.Op.GetText(), context.Lhs.Accept(this), context.Rhs.Accept(this));
        }

        public override Expr VisitUnaryBoolExpr([NotNull] JPathParser.UnaryBoolExprContext context)
        {
            return new UnaryExpr(context.Op.GetText(), context.Sub.Accept(this));
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

    public static class JPath
    {
        public static Expr Parse(string str)
        {
            var lexer = new JPathLexer(new AntlrInputStream(str));
            var parser = new JPathParser(new CommonTokenStream(lexer));
            var listener = new JPathListener();
            parser.AddErrorListener(listener);
            var expr = parser.expr();
            if (listener.HasErrors)
            {
                throw new Exception("Syntex error: " + listener.FirstError);
            }


            Expr result = expr.Accept(new AstConverter());
            return result;
        }
    }

}
