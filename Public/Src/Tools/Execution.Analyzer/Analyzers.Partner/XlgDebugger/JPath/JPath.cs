// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using Antlr4.Runtime;
using BuildXL.FrontEnd.Script.Debugger;
using BuildXL.Utilities;

namespace BuildXL.Execution.Analyzer.JPath
{
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

    public static class JPath
    {
        private static Possible<JPathParser.ExprContext> TryParseInternal(string str)
        {
            var lexer = new JPathLexer(new AntlrInputStream(str));
            var parser = new JPathParser(new CommonTokenStream(lexer));
            var listener = new JPathListener();
            parser.AddErrorListener(listener);
            var expr = parser.expr();

            if (listener.HasErrors)
            {
                return new Failure<string>("Syntex error: " + listener.FirstError);
            }
            else
            {
                return expr;
            }
        }

        private static Possible<Expr> TryConvertInternal(JPathParser.ExprContext expr)
        {
            try
            {
                return expr.Accept(new AstConverter());
            }
            catch (Exception e)
            {
                return new Failure<string>(e.ToString());
            }
        }

        public static Possible<Expr> TryParse(string str)
        {
            return TryParseInternal(str).Then(TryConvertInternal);
        }

        public static Evaluator.Result Eval(Evaluator.Env env, Expr expr)
        {
            return new Evaluator().Eval(env, expr);
        }

        public static Possible<Evaluator.Result> TryEval(Evaluator.Env env, Expr expr)
        {
            try
            {
                return Eval(env, expr);
            }
            catch (Exception e)
            {
                return new Failure<string>(e.ToString());
            }
        }

        public static Possible<Evaluator.Result> TryEval(Evaluator.Env env, string expr)
        {
            return TryParse(expr).Then(e => TryEval(env, e));
        }
    }

}
