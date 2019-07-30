// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using System.Text.RegularExpressions;

namespace BuildXL.Execution.Analyzer.JPath
{
    [DebuggerDisplay("{Print(),nq}")]
    public abstract class Expr
    {
        public abstract string Print();
    }

    public sealed class Selector : Expr
    {
        public string PropertyName { get; }

        public Selector(string propertyName)
        {
            PropertyName = propertyName;
        }

        public override string Print() => PropertyName;

    }

    public sealed class IntLit : Expr
    {
        public int Value { get; }

        public IntLit(int value)
        {
            Value = value;
        }

        public override string Print() => Value.ToString();
    }

    public sealed class StrLit : Expr
    {
        public string Value { get; }

        public StrLit(string value)
        {
            Value = value;
        }

        public override string Print() => $"'{Value}'";
    }

    public sealed class RegexLit : Expr
    {
        public Regex Value { get; }

        public RegexLit(Regex value)
        {
            Value = value;
        }

        public override string Print() => $"/{Value}/";
    }

    public sealed class RangeExpr : Expr
    {
        public Expr Array { get; }
        public int Begin { get; } // inclusive, can be negative
        public int End { get; }   // inclusive, can be negative

        public RangeExpr(Expr array, int begin, int end)
        {
            Array = array;
            Begin = begin;
            End = end;
        }

        public override string Print() => Begin == End
            ? $"{Array.Print()}[{Begin}]"
            : $"{Array.Print()}[{Begin}..{End}]";
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
    }

    public class UnaryExpr : Expr
    {
        public int Op { get; }
        public Expr Sub { get; }

        public UnaryExpr(int op, Expr sub)
        {
            Op = op;
            Sub = sub;
        }

        public override string Print() => $"({Op} {Sub.Print()})";
    }

    public class BinaryExpr : Expr
    {
        public int Op { get; }
        public Expr Lhs { get; }
        public Expr Rhs { get; }

        public BinaryExpr(int op, Expr lhs, Expr rhs)
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
}
