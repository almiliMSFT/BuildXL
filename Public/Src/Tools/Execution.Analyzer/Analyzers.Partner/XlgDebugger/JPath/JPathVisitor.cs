//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from JPath.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace BuildXL.Execution.Analyzer.JPath {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="JPathParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IJPathVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="JPathParser.intBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntBinaryOp([NotNull] JPathParser.IntBinaryOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JPathParser.intUnaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntUnaryOp([NotNull] JPathParser.IntUnaryOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JPathParser.boolBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolBinaryOp([NotNull] JPathParser.BoolBinaryOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JPathParser.logicBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicBinaryOp([NotNull] JPathParser.LogicBinaryOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JPathParser.logicUnaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicUnaryOp([NotNull] JPathParser.LogicUnaryOpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BinaryIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryIntExpr([NotNull] JPathParser.BinaryIntExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ExprIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExprIntExpr([NotNull] JPathParser.ExprIntExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>UnaryIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryIntExpr([NotNull] JPathParser.UnaryIntExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SubIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubIntExpr([NotNull] JPathParser.SubIntExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BinaryBoolExpr</c>
	/// labeled alternative in <see cref="JPathParser.boolExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryBoolExpr([NotNull] JPathParser.BinaryBoolExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SubBoolExpr</c>
	/// labeled alternative in <see cref="JPathParser.boolExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubBoolExpr([NotNull] JPathParser.SubBoolExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BoolLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolLogicExpr([NotNull] JPathParser.BoolLogicExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>UnaryLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryLogicExpr([NotNull] JPathParser.UnaryLogicExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SubLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubLogicExpr([NotNull] JPathParser.SubLogicExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BinaryLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryLogicExpr([NotNull] JPathParser.BinaryLogicExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>IdSelector</c>
	/// labeled alternative in <see cref="JPathParser.selector"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdSelector([NotNull] JPathParser.IdSelectorContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>EscIdSelector</c>
	/// labeled alternative in <see cref="JPathParser.selector"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEscIdSelector([NotNull] JPathParser.EscIdSelectorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JPathParser.argList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgList([NotNull] JPathParser.ArgListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JPathParser.func"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc([NotNull] JPathParser.FuncContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>MapExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMapExpr([NotNull] JPathParser.MapExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>RegExLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRegExLitExpr([NotNull] JPathParser.RegExLitExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SelectorExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSelectorExpr([NotNull] JPathParser.SelectorExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>FilterExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFilterExpr([NotNull] JPathParser.FilterExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>RootExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRootExpr([NotNull] JPathParser.RootExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>IntLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntLitExpr([NotNull] JPathParser.IntLitExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SubExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubExpr([NotNull] JPathParser.SubExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>PipeExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPipeExpr([NotNull] JPathParser.PipeExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>StrLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStrLitExpr([NotNull] JPathParser.StrLitExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>RangeExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRangeExpr([NotNull] JPathParser.RangeExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>FuncExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFuncExpr([NotNull] JPathParser.FuncExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>IndexExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndexExpr([NotNull] JPathParser.IndexExprContext context);
}
} // namespace BuildXL.Execution.Analyzer.JPath
