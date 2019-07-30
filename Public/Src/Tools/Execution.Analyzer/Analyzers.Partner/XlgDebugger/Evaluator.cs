// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildXL.FrontEnd.Script.Debugger;

namespace BuildXL.Execution.Analyzer.JPath
{
    public class JPathEvaluator
    {
        public static string TokenName(int tokenType)
        {
            return JPathLexer.DefaultVocabulary.GetSymbolicName(tokenType);
        }

        public static int ToInt(object obj)
        {
            switch (obj)
            {
                case IEnumerable<object> arr:
                    var first = arr.FirstOrDefault();
                    return first == null ? false : ToInt(first);
            }
        }

        public static bool ToBool(object obj)
        {
            switch (obj)
            {
                case IEnumerable<object> arr:
                    var first = arr.FirstOrDefault();
                    return first == null ? false : ToBool(first);
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

        public IEnumerable<object> Eval(Env env, Expr expr)
        {
            switch (expr)
            {
                case Selector selector:
                    return env.Current
                        .Select(env.GetObjectInfo)
                        .SelectMany(obj => obj.Properties.Where(p => p.Name == selector.PropertyName))
                        .Select(prop => prop.Value);

                case IntLit intLit:
                    return new object[] { intLit.Value };

                case StrLit strLit:
                    return new object[] { strLit.Value };

                case RegexLit regexLit:
                    return new object[] { regexLit.Value };

                case RangeExpr rangeExpr:
                    var begin = Eval(env, rangeExpr.Begin);
                    var end = Eval(env, rangeExpr.End);
                    return new object[] { begin, end  };

                case MapExpr mapExpr:
                    var lhs = Eval(env, mapExpr.Lhs);
                    return Eval(env.WithCurrent(lhs), new Selector(mapExpr.PropertyName));

                case FilterExpr filterExpr:
                    return Eval(env, filterExpr.Lhs)
                        .Where(obj => Eval(env.WithCurrent(new[] { obj }), filterExpr.Filter).ToBool());

                default:
                    throw new Exception("Evaluation not implemented for type: " + expr?.GetType().FullName);
            }
        }
    }
}
