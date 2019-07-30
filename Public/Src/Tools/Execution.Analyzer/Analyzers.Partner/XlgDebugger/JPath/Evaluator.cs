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
    public class Evaluator
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

        private readonly Stack<(Env, Expr)> m_evalStack = new Stack<(Env, Expr)>();

        public IEnumerable<object> Eval(Env env, Expr expr, string context = null)
        {
            m_evalStack.Push((env, expr));
            try
            {
                switch (expr)
                {
                    case RootExpr rootExpr:
                        return new[] { env.Root };

                    case Selector selector:
                        return env.Current
                            .Select(env.GetObjectInfo)
                            .SelectMany(obj => obj.Properties.Where(p => p.Name == selector.PropertyName))
                            .Select(prop => prop.Value);

                    case RangeExpr rangeExpr:
                        var list = Eval(env, rangeExpr.Array).ToList();

                        if (list.Count == 0)
                        {
                            return list;
                        }

                        var beginNormalized = NormalizeArrayIndex(rangeExpr.Begin, list.Count);
                        var endNormalized = NormalizeArrayIndex(rangeExpr.End, list.Count);

                        return list.GetRange(
                            index: beginNormalized,
                            count: endNormalized - beginNormalized + 1);

                    case MapExpr mapExpr:
                        var lhs = Eval(env, mapExpr.Lhs);
                        return Eval(env.WithCurrent(lhs), new Selector(mapExpr.PropertyName));

                    case FilterExpr filterExpr:
                        return Eval(env, filterExpr.Lhs)
                            .Where(obj =>
                            {
                                var filterValue = Eval(env.WithCurrent(new[] { obj }), filterExpr.Filter);
                                return ToBool(ToScalar(filterValue));
                            });

                    case IntLit intLit:
                        return new object[] { intLit.Value };

                    case StrLit strLit:
                        return new object[] { strLit.Value };

                    case RegexLit regexLit:
                        return new object[] { regexLit.Value };

                    case UnaryExpr ue:
                        var sub = Eval(env, ue.Sub);
                        return ApplyUnaryExpr(sub, ue.Op);

                    default:
                        throw new Exception("Evaluation not implemented for type: " + expr?.GetType().FullName);
                }
            }
            finally
            {
                m_evalStack.Pop();
            }
        }

        private IEnumerable<object> ApplyUnaryExpr(IEnumerable<object> value, string op)
        {
            

            return null;
        }

        private string TokenName(int tokenType)
        {
            return JPathLexer.DefaultVocabulary.GetSymbolicName(tokenType);
        }

        private object ToScalar(IEnumerable<object> value)
        {
            if (value.Count() != 1)
            {
                throw Error("Expected a scalar value, got array of size " + value.Count());
            }

            return value.First();
        }

        private int ToInt(object obj)
        {
            switch (obj)
            {
                case int i: return i;
                case long l: return (int)l;
                case byte b: return (int)b;
                case short s: return (int)s;
                default:
                    throw TypeError(obj, "int");
            }
        }

        private Exception TypeError(object obj, string expectedType)
        {
            return Error($"Cannot convert an object of type {obj?.GetType().Name} to {expectedType}");
        }

        private Exception Error(string message)
        {
            return new Exception(message);
        }

        private bool ToBool(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            switch (obj)
            {
                case IEnumerable<object> arr:
                    return arr.Any();
                case string str:
                    return !string.IsNullOrEmpty(str);
                case bool b:
                    return b;
                case int i:
                    return i != 0;
                default:
                    throw TypeError(obj, "bool");
            }
        }

        private static int NormalizeArrayIndex(int idx, int arrayLength)
        {
            if (idx < 0)
            {
                idx = arrayLength + idx;
            }

            return
                idx < 0            ? 0 :
                idx >= arrayLength ? arrayLength - 1 :
                idx;
        }
    }
}
