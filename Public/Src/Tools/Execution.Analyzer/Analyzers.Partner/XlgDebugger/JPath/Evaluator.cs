// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BuildXL.FrontEnd.Script.Debugger;

namespace BuildXL.Execution.Analyzer.JPath
{
    public class Evaluator
    {
        public sealed class Result : IEnumerable<object>
        {
            private readonly Lazy<IReadOnlyList<object>> m_value;

            public IReadOnlyList<object> Value => m_value.Value;

            public int Count => Value.Count;

            private Result(IEnumerable<object> arr)
            {
                m_value = new Lazy<IReadOnlyList<object>>(() => arr.ToList());
            }

            public static Result Scalar(object scalar) => new Result(new[] { scalar });
            public static Result Array(IEnumerable<object> arr) => new Result(arr);

            public IEnumerator<object> GetEnumerator() => Value.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => Value.GetEnumerator();

            public static implicit operator Result(int scalar) => Scalar(scalar);
            public static implicit operator Result(bool scalar) => Scalar(scalar);
            public static implicit operator Result(string scalar) => Scalar(scalar);
            public static implicit operator Result(Regex scalar) => Scalar(scalar);
            public static implicit operator Result(object[] arr) => Array(arr);
            public static implicit operator Result(List<object> arr) => Array(arr);

        }

        public class Args
        {
            public Evaluator Eval { get; }
            private readonly string m_funcName;
            private readonly Result[] m_args;

            public Args(Evaluator eval, string funcName, Result[] args)
            {
                Eval = eval;
                m_funcName = funcName;
                m_args = args;
            }

            public int Count => m_args.Length;

            public Result this[int i]
            {
                get
                {
                    if (i < 0 || i >= m_args.Length)
                    {
                        throw Eval.Error($"Function '{m_funcName}' received {m_args.Length} arguments but needs at least {i+1}");
                    }

                    return m_args[i];
                }
            }

        }

        public delegate Result LibraryFunc(Args args);
        public delegate ObjectInfo ObjectResolver(object obj);
        public delegate LibraryFunc FuncResolver(string name);

        public class Env
        {
            public ObjectResolver ResolveObject { get; }
            public FuncResolver ResolveFunc { get; }

            public object Root { get; }
            public Result Current { get; }

            public Env(
                ObjectResolver resolveObject,
                FuncResolver resolveFunc,
                object root, 
                Result current)
            {
                ResolveObject = resolveObject;
                ResolveFunc = resolveFunc;
                Root = root;
                Current = current;
            }

            public Env(ObjectResolver objectResolver, FuncResolver funcResolver, object root)
                : this(objectResolver, funcResolver, root, Result.Scalar(root)) { }

            internal Env WithCurrent(Result newCurrent)
            {
                return new Env(ResolveObject, ResolveFunc, Root, newCurrent);
            }
        }

        private readonly Stack<(Env, Expr)> m_evalStack = new Stack<(Env, Expr)>();

        private Env TopEnv => m_evalStack.Any() ? m_evalStack.Peek().Item1 : null;

        public Result Eval(Env env, Expr expr, string context = null)
        {
            m_evalStack.Push((env, expr));
            try
            {
                switch (expr)
                {
                    case RootExpr rootExpr:
                        return Result.Scalar(env.Root);

                    case Selector selector:
                        return env.Current
                            .Select(obj => env.ResolveObject(obj))
                            .SelectMany(obj => obj.Properties.Where(p => p.Name == selector.PropertyName))
                            .SelectMany(prop =>
                            {
                                // automatically flatten non-scalar results
                                switch (prop.Value)
                                {
                                    case IEnumerable<object> ie: return ie;
                                    case string str:             return new[] { str }; // string is IEnumerable, so exclude it here
                                    case IEnumerable ie2:        return ie2.Cast<object>();
                                    default:
                                        return new[] { prop.Value };
                                }
                            })
                            .ToList();

                    case RangeExpr rangeExpr:
                        var array = Eval(env, rangeExpr.Array);
                        if (array.Count == 0)
                        {
                            return array;
                        }

                        var beginIdx = ToInt(Eval(env, rangeExpr.Begin));
                        var endIdx = rangeExpr.End != null
                            ? ToInt(Eval(env, rangeExpr.End))
                            : beginIdx;

                        var beginNormalized = NormalizeArrayIndex(beginIdx, array.Count);
                        var endNormalized = NormalizeArrayIndex(endIdx, array.Count);

                        return array
                            .ToList()
                            .GetRange(index: beginNormalized, count: endNormalized - beginNormalized + 1);

                    case MapExpr mapExpr:
                        var lhs = Eval(env, mapExpr.Lhs);
                        return Eval(env.WithCurrent(lhs), mapExpr.PropertySelector);

                    case FilterExpr filterExpr:
                        return Eval(env, filterExpr.Lhs)
                            .Where(obj =>
                            {
                                var filterValue = Eval(env.WithCurrent(new[] { obj }), filterExpr.Filter);
                                return ToBool(filterValue);
                            })
                            .ToList();

                    case FuncExpr funcExpr:
                        return ResolveAndInvokeFunction(env, funcExpr.Name, funcExpr.Args);

                    case PipeExpr pipeExpr:
                        return ResolveAndInvokeFunction(env, pipeExpr.Func.Name, pipeExpr.ConcatArgs());

                    case IntLit intLit:
                        return intLit.Value;

                    case StrLit strLit:
                        return strLit.Value;

                    case RegexLit regexLit:
                        return regexLit.Value;

                    case UnaryExpr ue:
                        var sub = Eval(env, ue.Sub);
                        return ApplyUnaryExpr(ue.Op, sub);

                    case BinaryExpr be:
                        var lhsVal = Eval(env, be.Lhs);
                        var rhsVal = Eval(env, be.Rhs);
                        return ApplyBinaryExpr(be.Op, lhsVal, rhsVal);

                    default:
                        throw new Exception("Evaluation not implemented for type: " + expr?.GetType().FullName);
                }
            }
            finally
            {
                m_evalStack.Pop();
            }
        }

        private Result ResolveAndInvokeFunction(Env env, string name, IEnumerable<Expr> args)
        {
            var func = env.ResolveFunc(name);
            return func.Invoke(new Args(this, name, args.Select(a => Eval(env, a)).ToArray()));
        }

        private Result ApplyUnaryExpr(int op, Result value)
        {
            switch (op)
            {
                case JPathLexer.NOT:   return !ToBool(value);
                case JPathLexer.MINUS: return -ToInt(value);

                default:
                    throw ApplyError(op, value);
            }
        }

        private Result ApplyBinaryExpr(int op, Result lhs, Result rhs)
        {
            switch (op)
            {
                case JPathLexer.GTE: return ToInt(lhs) >= ToInt(rhs);
                case JPathLexer.GT:  return ToInt(lhs) >  ToInt(rhs);
                case JPathLexer.LTE: return ToInt(lhs) <= ToInt(rhs);
                case JPathLexer.LT:  return ToInt(lhs) <  ToInt(rhs);
                case JPathLexer.EQ:  return lhs.ToHashSet().SetEquals(rhs);
                case JPathLexer.NEQ: return !lhs.ToHashSet().SetEquals(rhs);

                case JPathLexer.AND: return ToBool(lhs) && ToBool(rhs);
                case JPathLexer.OR:  return ToBool(lhs) || ToBool(rhs);
                case JPathLexer.XOR: return ToBool(lhs) != ToBool(rhs);
                case JPathLexer.IFF: return ToBool(lhs) == ToBool(rhs);

                case JPathLexer.PLUS:  return ToInt(lhs) + ToInt(rhs);
                case JPathLexer.MINUS: return ToInt(lhs) - ToInt(rhs);
                case JPathLexer.TIMES: return ToInt(lhs) * ToInt(rhs);
                case JPathLexer.DIV:   return ToInt(lhs) / ToInt(rhs);
                case JPathLexer.MOD:   return ToInt(lhs) % ToInt(rhs);

                case JPathLexer.MATCH:  return Matches(lhs, rhs);
                case JPathLexer.NMATCH: return !Matches(lhs, rhs);

                default:
                    throw ApplyError(op, lhs, rhs);
            }
        }

        public bool Matches(Result lhs, Result rhs)
        {
            if (lhs.Count != 1)
            {
                return false;
            }
            var lhsStr = PreviewObj(ToScalar(lhs));
            return Matches(lhsStr, rhs);
        }

        public bool Matches(string lhsStr, Result rhs)
        {
            var rhsVal = ToScalar(rhs);
            switch (rhsVal)
            {
                case string str: return lhsStr.Contains(str);
                case Regex regex: return regex.Match(lhsStr).Success;
                default:
                    throw TypeError(rhsVal, "string | Regex");
            }
        }

        private string TokenName(int tokenType)
        {
            return JPathLexer.DefaultVocabulary.GetSymbolicName(tokenType);
        }

        public string PreviewObj(object obj)
        {
            var env = TopEnv;
            if (env == null)
            {
                return obj?.ToString() ?? "<null>";
            }

            var objInfo = env.ResolveObject(obj);
            return objInfo.Preview;
        }

        private string PreviewArray(Result result)
        {
            return "[" + Environment.NewLine +
                    string.Join(string.Empty, result.Select(PreviewObj).Select(str => Environment.NewLine + "  " + str)) +
                    Environment.NewLine + "]";
        }

        private Exception ApplyError(int op, params Result[] values)
        {
            var valuesStr = string.Join(string.Empty, values
                .Select(PreviewArray)
                .Select(str => Environment.NewLine + str));
            return Error($"Cannot apply operation '{JPathLexer.DefaultVocabulary.GetSymbolicName(op)}', to values {valuesStr}");
        }

        private Exception TypeError(object obj, string expectedType)
        {
            return Error($"Cannot convert an object of type {obj?.GetType().Name} to {expectedType}");
        }

        private Exception Error(string message)
        {
            return new Exception(message);
        }

        public object ToScalar(Result value)
        {
            if (value.Count != 1)
            {
                throw Error("Expected a scalar value, got array of size " + value.Count);
            }

            return value.Value.First();
        }

        public int ToInt(object obj)
        {
            switch (obj)
            {
                case Result r: return ToInt(ToScalar(r));
                case int i:    return i;
                case long l:   return (int)l;
                case byte b:   return (int)b;
                case short s:  return (int)s;
                default:
                    throw TypeError(obj, "int");
            }
        }

        public string ToString(object obj)
        {
            switch (obj)
            {
                case Result r: return ToString(ToScalar(r));
                case string s: return s;
                default:
                    throw TypeError(obj, "string");
            }
        }

        private bool ToBool(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            switch (obj)
            {
                case Result r:                 return ToBool(ToScalar(r));
                case IEnumerable<object> arr:  return arr.Any();
                case string str:               return !string.IsNullOrEmpty(str);
                case bool b:                   return b;
                case int i:                    return i != 0;
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
