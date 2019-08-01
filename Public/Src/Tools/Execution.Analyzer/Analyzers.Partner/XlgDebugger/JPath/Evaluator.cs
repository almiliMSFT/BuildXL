// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.ContractsLight;
using System.Linq;
using System.Text.RegularExpressions;
using Antlr4.Runtime;
using BuildXL.FrontEnd.Script.Debugger;
using BuildXL.Utilities.Collections;

namespace BuildXL.Execution.Analyzer.JPath
{
    /// <summary>
    /// Evaluates an expression of type <see cref="Expr"/> and produces a result of type <see cref="Result"/>.
    /// 
    /// Every expression evaluates to a collection of values (hence <see cref="Result.Value"/> is of type List)
    /// </summary>
    public sealed class Evaluator
    {
        /// <summary>
        /// The result of an evaluation.
        /// 
        /// Every expression evaluates to a vector, which is accessible via the <see cref="Value"/> property.
        /// </summary>
        public sealed class Result : IEnumerable<object>
        {
            /// <summary>
            /// Empty result
            /// </summary>
            public static readonly Result Empty = new Result(new object[0]);

            private readonly Lazy<IReadOnlyList<object>> m_value;

            /// <summary>
            /// The result of evaluation.  Every expression evaluates to a vector, hence the type.
            /// </summary>
            public IReadOnlyList<object> Value => m_value.Value;

            /// <summary>
            /// Number of values in this vector (<see cref="Value"/>)
            /// </summary>
            public int Count => Value.Count;

            /// <summary>
            /// Whether this is a scalar result (the vector contains exactly one element)
            /// </summary>
            public bool IsScalar => Count == 1;

            /// <summary>
            /// Whether this vector is empty.
            /// </summary>
            public bool IsEmpty => Count == 0;

            private Result(IEnumerable<object> arr)
            {
                m_value = new Lazy<IReadOnlyList<object>>(() => arr.ToList());
            }

            /// <summary>Factory method from a scalar.</summary>
            public static Result Scalar(object scalar) => new Result(new[] { scalar });

            /// <summary>Factory method from a vector.</summary>
            public static Result Array(IEnumerable<object> arr) => new Result(arr);

            // IEnumerable methods

            public IEnumerator<object> GetEnumerator() => Value.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => Value.GetEnumerator();

            // implicit conversions

            public static implicit operator Result(int scalar)       => Scalar(scalar);
            public static implicit operator Result(bool scalar)      => Scalar(scalar);
            public static implicit operator Result(string scalar)    => Scalar(scalar);
            public static implicit operator Result(Regex scalar)     => Scalar(scalar);
            public static implicit operator Result(Function scalar)  => Scalar(scalar);
            public static implicit operator Result(object[] arr)     => Array(arr);
            public static implicit operator Result(List<object> arr) => Array(arr);
        }

        /// <summary>
        /// An environment against which expressions are evaluated
        /// </summary>
        public class Env
        {
            /// <summary>
            /// A caller-provided object resolver.
            /// 
            /// Takes an object and returns an <see cref="ObjectInfo"/> for it
            /// (i.e., a name and a list of its properties).
            /// </summary>
            public ObjectResolver ResolveObject { get; }

            /// <summary>
            /// The root object (<see cref="RootExpr"/>).
            /// </summary>
            public object Root { get; }

            /// <summary>
            /// The result of the last evaluated expression (against which selector properties are resolved)
            /// </summary>
            public Result Current { get; }

            /// <nodoc />
            public Env(ObjectResolver resolveObject, object root, Result current)
            {
                ResolveObject = resolveObject;
                Root = root;
                Current = current;
            }

            /// <nodoc />
            public Env(ObjectResolver objectResolver, object root)
                : this(objectResolver, root, Result.Scalar(root)) { }

            /// <summary>
            /// Returns a new environment in which only the <see cref="Current"/> property is updated to <paramref name="newCurrent"/>.
            /// </summary>
            internal Env WithCurrent(Result newCurrent)
            {
                return new Env(ResolveObject, Root, newCurrent);
            }
        }

        /// <summary>
        /// Arguments that are passed to library-defined functions (returned by <see cref="Env.ResolveFunc"/>)
        /// </summary>
        public class Args
        {
            /// <summary>Reference to the current evaluator</summary>
            public Evaluator Eval { get; }

            /// <summary>Name of the function to which these arguments are passed</summary>
            private readonly string m_funcName;

            /// <summary>The arguments passed to the function</summary>
            private readonly Result[] m_args;

            /// <nodoc />
            public Args(Evaluator eval, string funcName, Result[] args)
            {
                Eval = eval;
                m_funcName = funcName;
                m_args = args;
            }

            /// <summary>
            /// Number of arguments provided.
            /// </summary>
            public int Count => m_args.Length;

            /// <summary>
            /// Returns the argument at position <paramref name="i"/> or throws if that index is out of bounds
            /// </summary>
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

        /// <summary>
        /// Library-defined function delegate type.
        /// </summary>
        public delegate Result LibraryFunc(Args args);

        /// <summary>
        /// A function value.
        /// </summary>
        public sealed class Function
        {
            private readonly LibraryFunc m_func;
            private readonly Result[] m_curriedArgs;

            /// <nodoc />
            public string Name { get; }

            /// <nodoc />
            public int MinArity { get; }

            /// <nodoc />
            public int? MaxArity { get; }

            /// <nodoc />
            public Function(LibraryFunc func, string name = "<lambda>", int minArity = 1, int? maxArity = null, IEnumerable<Result> curriedArgs = null)
            {
                Contract.Requires(func != null);

                m_func = func;
                Name = name;
                MinArity = minArity;
                MaxArity = maxArity;
                m_curriedArgs = (curriedArgs ?? CollectionUtilities.EmptyArray<Result>()).ToArray();
            }

            /// <nodoc />
            public Result Apply(Evaluator eval, IEnumerable<Result> args) => Apply(eval, args.ToArray());

            /// <nodoc />
            public Result Apply(Evaluator eval, Result[] args)
            {
                var argCount = args.Length;
                if (argCount < MinArity)
                {
                    return new Function(
                        m_func, 
                        Name,
                        minArity: MinArity - argCount,
                        maxArity: MaxArity != null ? MaxArity.Value - argCount : MaxArity,
                        curriedArgs: m_curriedArgs.Concat(args));
                }

                return m_func(new Args(eval, Name, m_curriedArgs.Concat(args).ToArray()));
            }
        }

        /// <summary>
        /// Object resolver delegate type.
        /// </summary>
        public delegate ObjectInfo ObjectResolver(object obj);

        private readonly Stack<(Env, Expr)> m_evalStack = new Stack<(Env, Expr)>();

        private Env TopEnv => m_evalStack.Any() ? m_evalStack.Peek().Item1 : null;

        /// <nodoc />
        public Result Eval(Env env, Expr expr, string context = null)
        {
            m_evalStack.Push((env, expr));
            try
            {
                switch (expr)
                {
                    case Selector selector:
                        return env.Current
                            .Select(obj => env.ResolveObject(obj))
                            .SelectMany(obj => obj.Properties.Where(p => selector.PropertyNames.Contains(p.Name)))
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
                        if (array.IsEmpty)
                        {
                            return array;
                        }

                        var begin = IEval(env, rangeExpr.Begin);
                        var end = rangeExpr.End != null
                            ? IEval(env, rangeExpr.End)
                            : begin;

                        if (begin < 0)
                        {
                            begin += array.Count;
                        }

                        if (end < 0)
                        {
                            end += array.Count;
                        }

                        if (begin > end || begin < 0 || begin >= array.Count || end < 0 || end >= array.Count)
                        {
                            return Result.Empty;
                        }

                        return array.ToList().GetRange(index: begin, count: end - begin + 1);

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

                    case FuncAppExpr funcExpr:
                        var funcResult = Eval(env, funcExpr.Func);
                        var function = ToFunc(funcResult, funcExpr.Func);
                        return function.Apply(this, funcExpr.Args.Select(arg => Eval(env, arg)));

                    case RootExpr rootExpr:
                        return Result.Scalar(env.Root);

                    case IntLit intLit:
                        return intLit.Value;

                    case StrLit strLit:
                        return strLit.Value;

                    case RegexLit regexLit:
                        return regexLit.Value;

                    case UnaryExpr ue:
                        return EvalUnaryExpr(env, ue);

                    case BinaryExpr be:
                        return EvalBinaryExpr(env, be);

                    default:
                        throw new Exception("Evaluation not implemented for type: " + expr?.GetType().FullName);
                }
            }
            finally
            {
                m_evalStack.Pop();
            }
        }

        private int IEval(Env env, Expr expr) => ToInt(Eval(env, expr), source: expr);
        private bool BEval(Env env, Expr expr) => ToBool(Eval(env, expr), source: expr);

        private Result EvalUnaryExpr(Env env, UnaryExpr expr)
        {
            var result = Eval(env, expr);
            switch (expr.Op.Type)
            {
                case JPathLexer.NOT:   return !ToBool(result, expr);
                case JPathLexer.MINUS: return -ToInt(result, expr);

                default:
                    throw ApplyError(expr.Op);
            }
        }

        private Result EvalBinaryExpr(Env env, BinaryExpr expr)
        {
            var lhs = expr.Lhs;
            var rhs = expr.Rhs;
            switch (expr.Op.Type)
            {
                case JPathLexer.GTE: return IEval(lhs) >= IEval(rhs);
                case JPathLexer.GT:  return IEval(lhs) >  IEval(rhs);
                case JPathLexer.LTE: return IEval(lhs) <= IEval(rhs);
                case JPathLexer.LT:  return IEval(lhs) <  IEval(rhs);
                case JPathLexer.EQ:  return Eval(lhs).Equals(Eval(rhs));
                case JPathLexer.NEQ: return !Eval(lhs).Equals(Eval(rhs));

                case JPathLexer.AND: return BEval(lhs) && BEval(rhs);
                case JPathLexer.OR:  return BEval(lhs) || BEval(rhs);
                case JPathLexer.XOR: return BEval(lhs) != BEval(rhs);
                case JPathLexer.IFF: return BEval(lhs) == BEval(rhs);

                case JPathLexer.PLUS:  return IEval(lhs) + IEval(rhs);
                case JPathLexer.MINUS: return IEval(lhs) - IEval(rhs);
                case JPathLexer.TIMES: return IEval(lhs) * IEval(rhs);
                case JPathLexer.DIV:   return IEval(lhs) / IEval(rhs);
                case JPathLexer.MOD:   return IEval(lhs) % IEval(rhs);

                case JPathLexer.MATCH:  return Matches(Eval(lhs), Eval(rhs));
                case JPathLexer.NMATCH: return !Matches(Eval(lhs), Eval(rhs));

                default:
                    throw ApplyError(expr.Op);
            }

            int IEval(Expr e) => this.IEval(env, e);
            bool BEval(Expr e) => this.BEval(env, e);
            Result Eval(Expr e) => this.Eval(env, e);
        }

        /// <summary>
        /// Whether the value in <paramref name="lhs"/> matches the value in <paramref name="rhs"/>.
        /// </summary>
        /// <param name="lhs">Can be any value.</param>
        /// <param name="rhs">Must be a scalar string or regular expression</param>
        /// <returns></returns>
        public bool Matches(Result lhs, Result rhs)
        {
            if (!lhs.IsScalar)
            {
                return false;
            }
            var lhsStr = PreviewObj(ToScalar(lhs));
            return Matches(lhsStr, rhs);
        }

        /// <summary>
        /// Whether the value in <paramref name="lhs"/> matches the value in <paramref name="rhs"/>.
        /// </summary>
        /// <param name="lhsStr">String to check</param>
        /// <param name="rhs">Must be a scalar string or regular expression</param>
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

        /// <summary>
        /// Uses the current environment to resolve <paramref name="obj"/> and returns its "preview" string.
        /// 
        /// Every object can be resolved to something, so this function never fails.
        /// </summary>
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

        /// <summary>
        /// Returns the single value if <paramref name="value"/> is scalar; otherwise throws.
        /// </summary>
        public object ToScalar(Result value)
        {
            if (!value.IsScalar)
            {
                throw Error("Expected a scalar value, got a vector of size " + value.Count);
            }

            return value.Value.First();
        }

        /// <summary>
        /// Converts <paramref name="obj"/> to int if possible; otherwise throws.
        /// 
        /// A <see cref="Result"/> can be converted only if it is a scalar value.
        /// Other than that, only numeric values can be converted to int.
        /// </summary>
        public int ToInt(object obj, Expr source = null)
        {
            switch (obj)
            {
                case Result r when r.IsScalar: return ToInt(ToScalar(r), source);
                case int i:                    return i;
                case long l:                   return (int)l;
                case byte b:                   return b;
                case short s:                  return s;
                default:
                    throw TypeError(obj, "int", source);
            }
        }

        /// <summary>
        /// Converts <paramref name="obj"/> to <see cref="Function"/> if possible; otherwise throws.
        /// 
        /// A <see cref="Result"/> can be converted only if it is a scalar value.
        /// Other than that, only a <see cref="Function"/> object can be converted to string.
        /// </summary>
        public Function ToFunc(object obj, Expr source = null)
        {
            switch (obj)
            {
                case Result r when r.IsScalar: return ToFunc(ToScalar(r), source);
                case Function f:               return f;
                default:
                    throw TypeError(obj, "function", source);
            }
        }

        /// <summary>
        /// Converts <paramref name="obj"/> to string if possible; otherwise throws.
        /// 
        /// A <see cref="Result"/> can be converted only if it is a scalar value.
        /// Other than that, only a string can be converted to string.
        /// </summary>
        public string ToString(object obj, Expr source = null)
        {
            switch (obj)
            {
                case Result r when r.IsScalar: return ToString(ToScalar(r), source);
                case string s:                 return s;
                default:
                    throw TypeError(obj, "string", source);
            }
        }

        /// <summary>
        /// Converts <paramref name="obj"/> to bool if possible; otherwise throws.
        /// 
        /// A <see cref="Result"/> can be converted only if it is a scalar value.
        /// Other than that, the following values are converted to true:
        ///   - an integer that is different from 0
        ///   - a non-empty string
        ///   - a non-empty collection
        ///   - the <code>true</code> boolean constant
        /// </summary>
        public bool ToBool(object obj, Expr source = null)
        {
            if (obj == null)
            {
                return false;
            }

            switch (obj)
            {
                case Result r when r.IsScalar: return ToBool(ToScalar(r), source);
                case IEnumerable<object> arr:  return arr.Any();
                case string str:               return !string.IsNullOrEmpty(str);
                case bool b:                   return b;
                case int i:                    return i != 0;
                default:
                    throw TypeError(obj, "bool", source);
            }
        }

        private string PreviewArray(Result result)
        {
            return "[" + Environment.NewLine +
                    string.Join(string.Empty, result.Select(PreviewObj).Select(str => Environment.NewLine + "  " + str)) +
                    Environment.NewLine + "]";
        }

        private Exception ApplyError(IToken op)
        {
            return Error($"Cannot apply operator '{op.Text}' (token: {op})");
        }

        private Exception TypeError(object obj, string expectedType, Expr source = null)
        {
            var objPreview = PreviewObj(obj);
            var message = $"Cannot convert '{objPreview}' of type {obj?.GetType().Name} to {expectedType}.";
            if (source != null)
            {
                message += $"  This value was obtained by evaluating expression: {source.Print()}";
            }

            return Error(message);
        }

        private Exception Error(string message)
        {
            return new Exception(message);
        }
    }
}
