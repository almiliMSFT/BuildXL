// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using Antlr4.Runtime;

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
