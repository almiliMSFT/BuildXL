﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace BuildXL.Execution.Analyzer.JPath
{
    public interface Expr { }

    public interface BoolExpr : Expr { }

    public sealed class Var : Expr, BoolExpr
    {
        public string Name;
    }

    public abstract class Filter : Expr
    {
        public Expr Lhs;
    }

    public sealed class IntLit : Expr
    {
        public int Value;
    }

    public sealed class RangeFilter : Filter
    {
        public Expr StartIndex; // inclusive, can be negative
        public Expr EndIndex;   // inclusive, can be negative
    }

    public sealed class BoolFilter : Filter
    {
        public BoolExpr BoolExpr;
    }

    public enum BoolOp { Lt, Lte, Gt, Gte, Eq, Neq }

    public sealed class BinaryBoolExpr : BoolExpr
    {
        public Expr Lhs;
        public Expr Rhs;
        public BoolOp Op;
    }

    public sealed class RegexBoolExpr : BoolExpr
    {
        public Expr Lhs;
        public Regex Regex;
    }

    public sealed class MapExpr : Expr
    {
        public Expr Lhs;
        public Var Selector;
    }

    //public class Parser
    //{
    //    private readonly string m_source;

    //    private int m_pos = 0;

    //    public Parser(string source)
    //    {
    //        m_source = source;
    //        m_pos = 0;
    //    }

    //    /// <summary>
    //    /// IntConst := [0-9]+
    //    /// Ident    := [a-zA-Z][a-zA-Z0-9_]*
    //    /// Expr     := Iden
    //    ///           | IntConst
    //    ///           | Expr "." Iden
    //    ///           | Expr "[" Filter "]"
    //    ///           | 
    //    /// </summary>
    //    /// <returns></returns>
    //    public Expr Parse()
    //    {
    //        return null;
    //    }
    //}

    class JPathListener : JPathBaseListener
    {
    }

    class JPathVisitor : JPathBaseVisitor<Expr>
    {
        
    }

    public static class JPath
    {
        public static Expr Parse(string str)
        {
            var lexer = new JPathLexer(new AntlrInputStream(str));
            var parser = new JPathParser(new CommonTokenStream(lexer));
            var listener = new JPathListener();
            parser.AddParseListener(listener);
            var expr = parser.expr();
            Console.WriteLine(expr.ToInfoString(parser));
            Console.WriteLine("======");
            Console.WriteLine(expr.ToStringTree());
            return null;
        }
    }

}
