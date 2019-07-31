// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using Antlr4.Runtime;
using BuildXL.Utilities;

[assembly: CLSCompliant(false)]

namespace BuildXL.Execution.Analyzer.JPath
{ 
    /// <summary>
    /// Static helper methods for parsing/evaluating JPath expressions
    /// </summary>
    public static class JPath
    {
        class JPathListener : IAntlrErrorListener<IToken>
        {
            /// <nodoc />
            public string FirstError { get; private set; }

            /// <nodoc />
            public bool HasErrors => FirstError != null;

            /// <nodoc />
            public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
            {
                if (FirstError == null)
                {
                    FirstError = msg;
                }
            }
        }

        /// <nodoc />
        public static Possible<Expr> TryParse(string str)
        {
            return TryParseInternal(str).Then(TryConvertInternal);
        }

        /// <nodoc />
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

        /// <nodoc />
        public static Possible<Evaluator.Result> TryEval(Evaluator.Env env, string expr)
        {
            return TryParse(expr).Then(e => TryEval(env, e));
        }

        /// <nodoc />
        private static Evaluator.Result Eval(Evaluator.Env env, Expr expr)
        {
            return new Evaluator().Eval(env, expr);
        }

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
    }

}
