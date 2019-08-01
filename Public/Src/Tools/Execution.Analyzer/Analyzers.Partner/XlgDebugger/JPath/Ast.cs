// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace BuildXL.Execution.Analyzer.JPath
{
    /// <summary>
    /// Abstract expression.
    /// </summary>
    [DebuggerDisplay("{Print(),nq}")]
    public abstract class Expr
    {
        /// <summary>
        /// Textual representation of the expression (not necessarily the same as the text it was parsed from).
        /// </summary>
        public abstract string Print();
    }

    /// <summary>
    /// Contains a property name to be resolved against the current environment.
    /// 
    /// Syntax example 1: Key
    /// Syntax example 2: `Key with spaces`
    /// </summary>
    public sealed class Selector : Expr
    {
        /// <nodoc />
        public string PropertyName { get; }

        /// <nodoc />
        public Selector(string propertyName)
        {
            PropertyName = propertyName;
        }

        /// <inheritdoc />
        public override string Print() => PropertyName;

    }

    /// <summary>
    /// Integer literal.
    /// 
    /// Syntax example: 42
    /// </summary>
    public sealed class IntLit : Expr
    {
        /// <summary>The literal integer value</summary>
        public int Value { get; }

        /// <nodoc />
        public IntLit(int value)
        {
            Value = value;
        }

        /// <inheritdoc />
        public override string Print() => Value.ToString();
    }

    /// <summary>
    /// String literal.  These literals are enclosed in either single or double quotes.
    /// 
    /// Syntax example 1: "string value"
    /// Syntax example 2: 'string value'
    /// </summary>
    public sealed class StrLit : Expr
    {
        /// <summary>The literal string value (without quotes)</summary>
        public string Value { get; }

        /// <nodoc />
        public StrLit(string value)
        {
            Value = value;
        }

        /// <inheritdoc />
        public override string Print() => $"'{Value}'";
    }

    /// <summary>
    /// Regular expression literal (as defined in C#).  These literals are enclosed in either '/' or '!'.
    /// 
    /// Syntax example 1: /Prefix.*Suffix$/
    /// Syntax example 2: !^/usr/.*/.*txt$!
    /// </summary>
    public sealed class RegexLit : Expr
    {
        /// <summary>
        /// The literal regex value.
        /// </summary>
        public Regex Value { get; }

        /// <nodoc />
        public RegexLit(Regex value)
        {
            Value = value;
        }

        /// <inheritdoc />
        public override string Print() => $"/{Value}/";
    }

    /// <summary>
    /// Selects a contiguous range from an array.
    /// 
    /// Syntax example 1: arrayExpr[-2..-1]
    /// Syntax example 2: $array[-1]
    /// </summary>
    public sealed class RangeExpr : Expr
    {
        /// <summary>Array in which to select a range.</summary>
        public Expr Array { get; }

        /// <summary>
        /// Start index of the range.  Inclusive.  
        /// When negative, counts back from the end of the array.
        /// </summary>
        public Expr Begin { get; } // inclusive, can be negative

        /// <summary>
        /// End index of the range.  Inclusive.
        /// When negative, counts back from the end of the array.
        /// When null, assumed to be the same as <see cref="Begin"/>.
        /// </summary>
        public Expr End { get; } 

        /// <nodoc />
        public RangeExpr(Expr array, Expr begin, Expr end)
        {
            Array = array;
            Begin = begin;
            End = end;
        }

        /// <inheritdoc />
        public override string Print() => Begin == End
            ? $"{Array.Print()}[{Begin}]"
            : $"{Array.Print()}[{Begin}..{End}]";
    }

    /// <summary>
    /// Maps a selector over an array value.
    /// 
    /// Syntax example: array.name
    /// </summary>
    public sealed class MapExpr : Expr
    {
        /// <summary>Collection to map <see cref="PropertySelector"/> over.</summary>
        public Expr Lhs { get; }

        /// <summary>Property to select from each value in <see cref="Lhs"/></summary>
        public Selector PropertySelector { get; }

        /// <nodoc />
        public MapExpr(Expr lhs, Selector propertyName)
        {
            Lhs = lhs;
            PropertySelector = propertyName;
        }

        /// <inheritdoc />
        public override string Print() => $"{Lhs.Print()}.{PropertySelector.Print()}";
    }

    /// <summary>
    /// Filters out values that don't satisfy the filter condition
    /// 
    /// Syntax example: arr[name='xyz']
    /// </summary>
    public class FilterExpr : Expr
    {
        /// <summary>Collection filter.</summary>
        public Expr Lhs { get; }

        /// <summary>Filter to apply over <see cref="Lhs"/></summary>
        public Expr Filter { get; }

        /// <nodoc />
        public FilterExpr(Expr lhs, Expr filter)
        {
            Lhs = lhs;
            Filter = filter;
        }

        /// <inheritdoc />
        public override string Print() => $"{Lhs.Print()}[{Filter.Print()}]";
    }

    /// <summary>
    /// A function application.
    /// 
    /// All function names start with '$'.
    /// 
    /// Syntax example: $join(' ', someExpr)
    /// </summary>
    public class FuncAppExpr : Expr
    {
        /// <summary>Name of the function.</summary>
        public Expr Func { get; }

        /// <summary>Function arguments</summary>
        public IReadOnlyList<Expr> Args { get; }

        /// <nodoc />
        public FuncAppExpr(Expr func, IEnumerable<Expr> args)
        {
            Func = func;
            Args = args.ToList();
        }

        /// <inheritdoc />
        public override string Print()
        {
            var args = string.Join(", ", Args.Select(a => a.Print()));
            return $"{Func.Print()}({args})";
        }
    }

    /// <summary>
    /// Any unary expression.
    /// 
    /// Syntax example 1: not boolExpr
    /// Syntax example 2: -intExpr
    /// </summary>
    public class UnaryExpr : Expr
    {
        /// <summary>Unary operator.</summary>
        public int Op { get; }

        /// <summary>Operand</summary>
        public Expr Sub { get; }

        /// <nodoc />
        public UnaryExpr(int op, Expr sub)
        {
            Op = op;
            Sub = sub;
        }

        /// <inheritdoc />
        public override string Print() => $"({Op} {Sub.Print()})";
    }

    /// <summary>
    /// Any binary expression.
    /// 
    /// Syntax example 1: intExpr1 + intExpr2
    /// Syntax example 2: boolExpr1 and boolExpr2
    /// </summary>
    public class BinaryExpr : Expr
    {
        /// <summary>Operator</summary>
        public int Op { get; }

        /// <summary>Left-hand side operand</summary>
        public Expr Lhs { get; }

        /// <summary>Right-hand side operand</summary>
        public Expr Rhs { get; }

        /// <nodoc />
        public BinaryExpr(int op, Expr lhs, Expr rhs)
        {
            Op = op;
            Lhs = lhs;
            Rhs = rhs;
        }

        /// <inheritdoc />
        public override string Print() => $"({Lhs.Print()} {Op} {Rhs.Print()})";
    }

    /// <summary>
    /// Always evaluates to the root object in the environment (<see cref="Evaluator.Env.Root"/>)
    /// </summary>
    public class RootExpr : Expr
    {
        public static readonly RootExpr Instance= new RootExpr();

        /// <inheritdoc />
        public override string Print() => "$";

        private RootExpr() { }
    }
}
