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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="JPathParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IJPathListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.intBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntBinaryOp([NotNull] JPathParser.IntBinaryOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.intBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntBinaryOp([NotNull] JPathParser.IntBinaryOpContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.intUnaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntUnaryOp([NotNull] JPathParser.IntUnaryOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.intUnaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntUnaryOp([NotNull] JPathParser.IntUnaryOpContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.boolBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolBinaryOp([NotNull] JPathParser.BoolBinaryOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.boolBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolBinaryOp([NotNull] JPathParser.BoolBinaryOpContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.logicBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogicBinaryOp([NotNull] JPathParser.LogicBinaryOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.logicBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogicBinaryOp([NotNull] JPathParser.LogicBinaryOpContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.logicUnaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLogicUnaryOp([NotNull] JPathParser.LogicUnaryOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.logicUnaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLogicUnaryOp([NotNull] JPathParser.LogicUnaryOpContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.arrayBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayBinaryOp([NotNull] JPathParser.ArrayBinaryOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.arrayBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayBinaryOp([NotNull] JPathParser.ArrayBinaryOpContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.anyBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnyBinaryOp([NotNull] JPathParser.AnyBinaryOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.anyBinaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnyBinaryOp([NotNull] JPathParser.AnyBinaryOpContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>BinaryIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinaryIntExpr([NotNull] JPathParser.BinaryIntExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>BinaryIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinaryIntExpr([NotNull] JPathParser.BinaryIntExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>ExprIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExprIntExpr([NotNull] JPathParser.ExprIntExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ExprIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExprIntExpr([NotNull] JPathParser.ExprIntExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>UnaryIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryIntExpr([NotNull] JPathParser.UnaryIntExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>UnaryIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryIntExpr([NotNull] JPathParser.UnaryIntExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>SubIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSubIntExpr([NotNull] JPathParser.SubIntExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>SubIntExpr</c>
	/// labeled alternative in <see cref="JPathParser.intExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSubIntExpr([NotNull] JPathParser.SubIntExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>BinaryBoolExpr</c>
	/// labeled alternative in <see cref="JPathParser.boolExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinaryBoolExpr([NotNull] JPathParser.BinaryBoolExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>BinaryBoolExpr</c>
	/// labeled alternative in <see cref="JPathParser.boolExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinaryBoolExpr([NotNull] JPathParser.BinaryBoolExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>SubBoolExpr</c>
	/// labeled alternative in <see cref="JPathParser.boolExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSubBoolExpr([NotNull] JPathParser.SubBoolExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>SubBoolExpr</c>
	/// labeled alternative in <see cref="JPathParser.boolExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSubBoolExpr([NotNull] JPathParser.SubBoolExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>BoolLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolLogicExpr([NotNull] JPathParser.BoolLogicExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>BoolLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolLogicExpr([NotNull] JPathParser.BoolLogicExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>UnaryLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryLogicExpr([NotNull] JPathParser.UnaryLogicExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>UnaryLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryLogicExpr([NotNull] JPathParser.UnaryLogicExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>SubLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSubLogicExpr([NotNull] JPathParser.SubLogicExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>SubLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSubLogicExpr([NotNull] JPathParser.SubLogicExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>BinaryLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinaryLogicExpr([NotNull] JPathParser.BinaryLogicExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>BinaryLogicExpr</c>
	/// labeled alternative in <see cref="JPathParser.logicExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinaryLogicExpr([NotNull] JPathParser.BinaryLogicExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>VarId</c>
	/// labeled alternative in <see cref="JPathParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVarId([NotNull] JPathParser.VarIdContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>VarId</c>
	/// labeled alternative in <see cref="JPathParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVarId([NotNull] JPathParser.VarIdContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>EscId</c>
	/// labeled alternative in <see cref="JPathParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEscId([NotNull] JPathParser.EscIdContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>EscId</c>
	/// labeled alternative in <see cref="JPathParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEscId([NotNull] JPathParser.EscIdContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>RootId</c>
	/// labeled alternative in <see cref="JPathParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRootId([NotNull] JPathParser.RootIdContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>RootId</c>
	/// labeled alternative in <see cref="JPathParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRootId([NotNull] JPathParser.RootIdContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>IdSelector</c>
	/// labeled alternative in <see cref="JPathParser.selector"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdSelector([NotNull] JPathParser.IdSelectorContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>IdSelector</c>
	/// labeled alternative in <see cref="JPathParser.selector"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdSelector([NotNull] JPathParser.IdSelectorContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>UnionSelector</c>
	/// labeled alternative in <see cref="JPathParser.selector"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnionSelector([NotNull] JPathParser.UnionSelectorContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>UnionSelector</c>
	/// labeled alternative in <see cref="JPathParser.selector"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnionSelector([NotNull] JPathParser.UnionSelectorContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>StrLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStrLitExpr([NotNull] JPathParser.StrLitExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>StrLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStrLitExpr([NotNull] JPathParser.StrLitExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>RegExLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRegExLitExpr([NotNull] JPathParser.RegExLitExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>RegExLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRegExLitExpr([NotNull] JPathParser.RegExLitExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>IntLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntLitExpr([NotNull] JPathParser.IntLitExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>IntLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntLitExpr([NotNull] JPathParser.IntLitExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>MapExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMapExpr([NotNull] JPathParser.MapExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>MapExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMapExpr([NotNull] JPathParser.MapExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>FuncOptExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncOptExpr([NotNull] JPathParser.FuncOptExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>FuncOptExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncOptExpr([NotNull] JPathParser.FuncOptExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>CardinalityExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCardinalityExpr([NotNull] JPathParser.CardinalityExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>CardinalityExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCardinalityExpr([NotNull] JPathParser.CardinalityExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>LetExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLetExpr([NotNull] JPathParser.LetExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>LetExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLetExpr([NotNull] JPathParser.LetExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>FuncAppExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncAppExpr([NotNull] JPathParser.FuncAppExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>FuncAppExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncAppExpr([NotNull] JPathParser.FuncAppExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>SubExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSubExpr([NotNull] JPathParser.SubExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>SubExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSubExpr([NotNull] JPathParser.SubExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>BinExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinExpr([NotNull] JPathParser.BinExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>BinExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinExpr([NotNull] JPathParser.BinExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>RangeExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRangeExpr([NotNull] JPathParser.RangeExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>RangeExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRangeExpr([NotNull] JPathParser.RangeExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>IndexExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndexExpr([NotNull] JPathParser.IndexExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>IndexExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndexExpr([NotNull] JPathParser.IndexExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>SelectorExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSelectorExpr([NotNull] JPathParser.SelectorExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>SelectorExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSelectorExpr([NotNull] JPathParser.SelectorExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>FilterExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFilterExpr([NotNull] JPathParser.FilterExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>FilterExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFilterExpr([NotNull] JPathParser.FilterExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>RootExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRootExpr([NotNull] JPathParser.RootExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>RootExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRootExpr([NotNull] JPathParser.RootExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>PipeExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPipeExpr([NotNull] JPathParser.PipeExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>PipeExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPipeExpr([NotNull] JPathParser.PipeExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>LiteralExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteralExpr([NotNull] JPathParser.LiteralExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>LiteralExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteralExpr([NotNull] JPathParser.LiteralExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>FuncAppExprParen</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncAppExprParen([NotNull] JPathParser.FuncAppExprParenContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>FuncAppExprParen</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncAppExprParen([NotNull] JPathParser.FuncAppExprParenContext context);
}
} // namespace BuildXL.Execution.Analyzer.JPath
