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
	/// Enter a parse tree produced by <see cref="JPathParser.unaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryOp([NotNull] JPathParser.UnaryOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.unaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryOp([NotNull] JPathParser.UnaryOpContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="JPathParser.binaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinaryOp([NotNull] JPathParser.BinaryOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="JPathParser.binaryOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinaryOp([NotNull] JPathParser.BinaryOpContext context);
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
	/// Enter a parse tree produced by the <c>RegExLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRegExLitExpr([NotNull] JPathParser.RegExLitExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>RegExLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRegExLitExpr([NotNull] JPathParser.RegExLitExprContext context);
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
	/// Enter a parse tree produced by the <c>IntLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntLitExpr([NotNull] JPathParser.IntLitExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>IntLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntLitExpr([NotNull] JPathParser.IntLitExprContext context);
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
	/// Enter a parse tree produced by the <c>BinaryExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinaryExpr([NotNull] JPathParser.BinaryExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>BinaryExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinaryExpr([NotNull] JPathParser.BinaryExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>StrLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStrLitExpr([NotNull] JPathParser.StrLitExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>StrLitExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStrLitExpr([NotNull] JPathParser.StrLitExprContext context);
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
	/// Enter a parse tree produced by the <c>UnaryExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryExpr([NotNull] JPathParser.UnaryExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>UnaryExpr</c>
	/// labeled alternative in <see cref="JPathParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryExpr([NotNull] JPathParser.UnaryExprContext context);
}
} // namespace BuildXL.Execution.Analyzer.JPath
