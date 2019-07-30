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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IJPathListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class JPathBaseListener : IJPathListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.intBinaryOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIntBinaryOp([NotNull] JPathParser.IntBinaryOpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.intBinaryOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIntBinaryOp([NotNull] JPathParser.IntBinaryOpContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.intUnaryOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIntUnaryOp([NotNull] JPathParser.IntUnaryOpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.intUnaryOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIntUnaryOp([NotNull] JPathParser.IntUnaryOpContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.boolBinaryOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBoolBinaryOp([NotNull] JPathParser.BoolBinaryOpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.boolBinaryOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBoolBinaryOp([NotNull] JPathParser.BoolBinaryOpContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.logicBinaryOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLogicBinaryOp([NotNull] JPathParser.LogicBinaryOpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.logicBinaryOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLogicBinaryOp([NotNull] JPathParser.LogicBinaryOpContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.logicUnaryOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLogicUnaryOp([NotNull] JPathParser.LogicUnaryOpContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.logicUnaryOp"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLogicUnaryOp([NotNull] JPathParser.LogicUnaryOpContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>BinaryIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBinaryIntExpr([NotNull] JPathParser.BinaryIntExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>BinaryIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBinaryIntExpr([NotNull] JPathParser.BinaryIntExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>ExprIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExprIntExpr([NotNull] JPathParser.ExprIntExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>ExprIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExprIntExpr([NotNull] JPathParser.ExprIntExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>UnaryIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterUnaryIntExpr([NotNull] JPathParser.UnaryIntExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>UnaryIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitUnaryIntExpr([NotNull] JPathParser.UnaryIntExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>SubIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSubIntExpr([NotNull] JPathParser.SubIntExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>SubIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSubIntExpr([NotNull] JPathParser.SubIntExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>BinaryBoolExpr</c>
	/// labeled alternative in <see cref="JPathParser.boolExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBinaryBoolExpr([NotNull] JPathParser.BinaryBoolExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>BinaryBoolExpr</c>
	/// labeled alternative in <see cref="JPathParser.boolExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBinaryBoolExpr([NotNull] JPathParser.BinaryBoolExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>SubBoolExpr</c>
	/// labeled alternative in <see cref="JPathParser.boolExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSubBoolExpr([NotNull] JPathParser.SubBoolExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>SubBoolExpr</c>
	/// labeled alternative in <see cref="JPathParser.boolExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSubBoolExpr([NotNull] JPathParser.SubBoolExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>BoolLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBoolLogicExpr([NotNull] JPathParser.BoolLogicExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>BoolLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBoolLogicExpr([NotNull] JPathParser.BoolLogicExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>UnaryLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterUnaryLogicExpr([NotNull] JPathParser.UnaryLogicExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>UnaryLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitUnaryLogicExpr([NotNull] JPathParser.UnaryLogicExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>SubLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSubLogicExpr([NotNull] JPathParser.SubLogicExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>SubLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSubLogicExpr([NotNull] JPathParser.SubLogicExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>BinaryLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBinaryLogicExpr([NotNull] JPathParser.BinaryLogicExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>BinaryLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBinaryLogicExpr([NotNull] JPathParser.BinaryLogicExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>IdSelector</c>
	/// labeled alternative in <see cref="JPathParser.selector"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIdSelector([NotNull] JPathParser.IdSelectorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>IdSelector</c>
	/// labeled alternative in <see cref="JPathParser.selector"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIdSelector([NotNull] JPathParser.IdSelectorContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>EscIdSelector</c>
	/// labeled alternative in <see cref="JPathParser.selector"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEscIdSelector([NotNull] JPathParser.EscIdSelectorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>EscIdSelector</c>
	/// labeled alternative in <see cref="JPathParser.selector"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEscIdSelector([NotNull] JPathParser.EscIdSelectorContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.func"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunc([NotNull] JPathParser.FuncContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.func"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunc([NotNull] JPathParser.FuncContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>MapExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMapExpr([NotNull] JPathParser.MapExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>MapExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMapExpr([NotNull] JPathParser.MapExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>RegExLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRegExLitExpr([NotNull] JPathParser.RegExLitExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>RegExLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRegExLitExpr([NotNull] JPathParser.RegExLitExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>SelectorExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSelectorExpr([NotNull] JPathParser.SelectorExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>SelectorExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSelectorExpr([NotNull] JPathParser.SelectorExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>FilterExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFilterExpr([NotNull] JPathParser.FilterExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>FilterExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFilterExpr([NotNull] JPathParser.FilterExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>RootExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRootExpr([NotNull] JPathParser.RootExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>RootExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRootExpr([NotNull] JPathParser.RootExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>IntLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIntLitExpr([NotNull] JPathParser.IntLitExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>IntLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIntLitExpr([NotNull] JPathParser.IntLitExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>SubExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSubExpr([NotNull] JPathParser.SubExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>SubExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSubExpr([NotNull] JPathParser.SubExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>PipeExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPipeExpr([NotNull] JPathParser.PipeExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>PipeExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPipeExpr([NotNull] JPathParser.PipeExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>StrLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStrLitExpr([NotNull] JPathParser.StrLitExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>StrLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStrLitExpr([NotNull] JPathParser.StrLitExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>RangeExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRangeExpr([NotNull] JPathParser.RangeExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>RangeExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRangeExpr([NotNull] JPathParser.RangeExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>FuncExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFuncExpr([NotNull] JPathParser.FuncExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>FuncExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFuncExpr([NotNull] JPathParser.FuncExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>IndexExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIndexExpr([NotNull] JPathParser.IndexExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>IndexExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIndexExpr([NotNull] JPathParser.IndexExprContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
} // namespace BuildXL.Execution.Analyzer.JPath
