// Generated from /Users/almili/work/almiliMSFT/BuildXL/Public/Src/Tools/Execution.Analyzer/Analyzers.Core/XlgDebugger/JPath/JPath.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class JPathParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, WS=11, NOT=12, AND=13, OR=14, XOR=15, IFF=16, GTE=17, LTE=18, 
		GT=19, LT=20, EQ=21, NEQ=22, MATCH=23, NMATCH=24, MINUS=25, PLUS=26, TIMES=27, 
		DIV=28, MOD=29, CONCAT=30, INTERSECT=31, IntLit=32, StrLit=33, RegExLit=34, 
		VarID=35, RootID=36, ESC_ID=37;
	public static final int
		RULE_intBinaryOp = 0, RULE_intUnaryOp = 1, RULE_boolBinaryOp = 2, RULE_logicBinaryOp = 3, 
		RULE_logicUnaryOp = 4, RULE_arrayBinaryOp = 5, RULE_anyBinaryOp = 6, RULE_intExpr = 7, 
		RULE_boolExpr = 8, RULE_logicExpr = 9, RULE_id = 10, RULE_selector = 11, 
		RULE_expr = 12;
	public static final String[] ruleNames = {
		"intBinaryOp", "intUnaryOp", "boolBinaryOp", "logicBinaryOp", "logicUnaryOp", 
		"arrayBinaryOp", "anyBinaryOp", "intExpr", "boolExpr", "logicExpr", "id", 
		"selector", "expr"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'('", "')'", "'$'", "'.'", "'['", "']'", "'..'", "'#'", "','", 
		"'|'", null, "'not'", "'and'", "'or'", "'xor'", "'iff'", "'>='", "'<='", 
		"'>'", "'<'", "'='", "'!='", "'~'", "'!~'", "'-'", "'+'", "'*'", "'/'", 
		"'%'", "'++'", "'&'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, null, null, null, null, null, null, null, null, null, null, "WS", 
		"NOT", "AND", "OR", "XOR", "IFF", "GTE", "LTE", "GT", "LT", "EQ", "NEQ", 
		"MATCH", "NMATCH", "MINUS", "PLUS", "TIMES", "DIV", "MOD", "CONCAT", "INTERSECT", 
		"IntLit", "StrLit", "RegExLit", "VarID", "RootID", "ESC_ID"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "JPath.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public JPathParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class IntBinaryOpContext extends ParserRuleContext {
		public Token Token;
		public TerminalNode PLUS() { return getToken(JPathParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(JPathParser.MINUS, 0); }
		public TerminalNode TIMES() { return getToken(JPathParser.TIMES, 0); }
		public TerminalNode DIV() { return getToken(JPathParser.DIV, 0); }
		public TerminalNode MOD() { return getToken(JPathParser.MOD, 0); }
		public IntBinaryOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_intBinaryOp; }
	}

	public final IntBinaryOpContext intBinaryOp() throws RecognitionException {
		IntBinaryOpContext _localctx = new IntBinaryOpContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_intBinaryOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(26);
			((IntBinaryOpContext)_localctx).Token = _input.LT(1);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << MINUS) | (1L << PLUS) | (1L << TIMES) | (1L << DIV) | (1L << MOD))) != 0)) ) {
				((IntBinaryOpContext)_localctx).Token = (Token)_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IntUnaryOpContext extends ParserRuleContext {
		public Token Token;
		public TerminalNode MINUS() { return getToken(JPathParser.MINUS, 0); }
		public IntUnaryOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_intUnaryOp; }
	}

	public final IntUnaryOpContext intUnaryOp() throws RecognitionException {
		IntUnaryOpContext _localctx = new IntUnaryOpContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_intUnaryOp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(28);
			((IntUnaryOpContext)_localctx).Token = match(MINUS);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BoolBinaryOpContext extends ParserRuleContext {
		public Token Token;
		public TerminalNode GTE() { return getToken(JPathParser.GTE, 0); }
		public TerminalNode GT() { return getToken(JPathParser.GT, 0); }
		public TerminalNode LTE() { return getToken(JPathParser.LTE, 0); }
		public TerminalNode LT() { return getToken(JPathParser.LT, 0); }
		public TerminalNode EQ() { return getToken(JPathParser.EQ, 0); }
		public TerminalNode NEQ() { return getToken(JPathParser.NEQ, 0); }
		public TerminalNode MATCH() { return getToken(JPathParser.MATCH, 0); }
		public TerminalNode NMATCH() { return getToken(JPathParser.NMATCH, 0); }
		public BoolBinaryOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolBinaryOp; }
	}

	public final BoolBinaryOpContext boolBinaryOp() throws RecognitionException {
		BoolBinaryOpContext _localctx = new BoolBinaryOpContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_boolBinaryOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(30);
			((BoolBinaryOpContext)_localctx).Token = _input.LT(1);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << GTE) | (1L << LTE) | (1L << GT) | (1L << LT) | (1L << EQ) | (1L << NEQ) | (1L << MATCH) | (1L << NMATCH))) != 0)) ) {
				((BoolBinaryOpContext)_localctx).Token = (Token)_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LogicBinaryOpContext extends ParserRuleContext {
		public Token Token;
		public TerminalNode AND() { return getToken(JPathParser.AND, 0); }
		public TerminalNode OR() { return getToken(JPathParser.OR, 0); }
		public TerminalNode XOR() { return getToken(JPathParser.XOR, 0); }
		public TerminalNode IFF() { return getToken(JPathParser.IFF, 0); }
		public LogicBinaryOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logicBinaryOp; }
	}

	public final LogicBinaryOpContext logicBinaryOp() throws RecognitionException {
		LogicBinaryOpContext _localctx = new LogicBinaryOpContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_logicBinaryOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(32);
			((LogicBinaryOpContext)_localctx).Token = _input.LT(1);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << AND) | (1L << OR) | (1L << XOR) | (1L << IFF))) != 0)) ) {
				((LogicBinaryOpContext)_localctx).Token = (Token)_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LogicUnaryOpContext extends ParserRuleContext {
		public Token Token;
		public TerminalNode NOT() { return getToken(JPathParser.NOT, 0); }
		public LogicUnaryOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logicUnaryOp; }
	}

	public final LogicUnaryOpContext logicUnaryOp() throws RecognitionException {
		LogicUnaryOpContext _localctx = new LogicUnaryOpContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_logicUnaryOp);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(34);
			((LogicUnaryOpContext)_localctx).Token = match(NOT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArrayBinaryOpContext extends ParserRuleContext {
		public Token Token;
		public TerminalNode CONCAT() { return getToken(JPathParser.CONCAT, 0); }
		public TerminalNode INTERSECT() { return getToken(JPathParser.INTERSECT, 0); }
		public ArrayBinaryOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arrayBinaryOp; }
	}

	public final ArrayBinaryOpContext arrayBinaryOp() throws RecognitionException {
		ArrayBinaryOpContext _localctx = new ArrayBinaryOpContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_arrayBinaryOp);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(36);
			((ArrayBinaryOpContext)_localctx).Token = _input.LT(1);
			_la = _input.LA(1);
			if ( !(_la==CONCAT || _la==INTERSECT) ) {
				((ArrayBinaryOpContext)_localctx).Token = (Token)_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AnyBinaryOpContext extends ParserRuleContext {
		public IntBinaryOpContext intBinaryOp() {
			return getRuleContext(IntBinaryOpContext.class,0);
		}
		public BoolBinaryOpContext boolBinaryOp() {
			return getRuleContext(BoolBinaryOpContext.class,0);
		}
		public LogicBinaryOpContext logicBinaryOp() {
			return getRuleContext(LogicBinaryOpContext.class,0);
		}
		public ArrayBinaryOpContext arrayBinaryOp() {
			return getRuleContext(ArrayBinaryOpContext.class,0);
		}
		public AnyBinaryOpContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_anyBinaryOp; }
	}

	public final AnyBinaryOpContext anyBinaryOp() throws RecognitionException {
		AnyBinaryOpContext _localctx = new AnyBinaryOpContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_anyBinaryOp);
		try {
			setState(42);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case MINUS:
			case PLUS:
			case TIMES:
			case DIV:
			case MOD:
				enterOuterAlt(_localctx, 1);
				{
				setState(38);
				intBinaryOp();
				}
				break;
			case GTE:
			case LTE:
			case GT:
			case LT:
			case EQ:
			case NEQ:
			case MATCH:
			case NMATCH:
				enterOuterAlt(_localctx, 2);
				{
				setState(39);
				boolBinaryOp();
				}
				break;
			case AND:
			case OR:
			case XOR:
			case IFF:
				enterOuterAlt(_localctx, 3);
				{
				setState(40);
				logicBinaryOp();
				}
				break;
			case CONCAT:
			case INTERSECT:
				enterOuterAlt(_localctx, 4);
				{
				setState(41);
				arrayBinaryOp();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IntExprContext extends ParserRuleContext {
		public IntExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_intExpr; }
	 
		public IntExprContext() { }
		public void copyFrom(IntExprContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class BinaryIntExprContext extends IntExprContext {
		public IntExprContext Lhs;
		public IntBinaryOpContext Op;
		public IntExprContext Rhs;
		public List<IntExprContext> intExpr() {
			return getRuleContexts(IntExprContext.class);
		}
		public IntExprContext intExpr(int i) {
			return getRuleContext(IntExprContext.class,i);
		}
		public IntBinaryOpContext intBinaryOp() {
			return getRuleContext(IntBinaryOpContext.class,0);
		}
		public BinaryIntExprContext(IntExprContext ctx) { copyFrom(ctx); }
	}
	public static class ExprIntExprContext extends IntExprContext {
		public ExprContext Expr;
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public ExprIntExprContext(IntExprContext ctx) { copyFrom(ctx); }
	}
	public static class UnaryIntExprContext extends IntExprContext {
		public IntUnaryOpContext Op;
		public IntExprContext Sub;
		public IntUnaryOpContext intUnaryOp() {
			return getRuleContext(IntUnaryOpContext.class,0);
		}
		public IntExprContext intExpr() {
			return getRuleContext(IntExprContext.class,0);
		}
		public UnaryIntExprContext(IntExprContext ctx) { copyFrom(ctx); }
	}
	public static class SubIntExprContext extends IntExprContext {
		public IntExprContext Sub;
		public IntExprContext intExpr() {
			return getRuleContext(IntExprContext.class,0);
		}
		public SubIntExprContext(IntExprContext ctx) { copyFrom(ctx); }
	}

	public final IntExprContext intExpr() throws RecognitionException {
		return intExpr(0);
	}

	private IntExprContext intExpr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		IntExprContext _localctx = new IntExprContext(_ctx, _parentState);
		IntExprContext _prevctx = _localctx;
		int _startState = 14;
		enterRecursionRule(_localctx, 14, RULE_intExpr, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(53);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				{
				_localctx = new ExprIntExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(45);
				((ExprIntExprContext)_localctx).Expr = expr(0);
				}
				break;
			case 2:
				{
				_localctx = new UnaryIntExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(46);
				((UnaryIntExprContext)_localctx).Op = intUnaryOp();
				setState(47);
				((UnaryIntExprContext)_localctx).Sub = intExpr(3);
				}
				break;
			case 3:
				{
				_localctx = new SubIntExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(49);
				match(T__0);
				setState(50);
				((SubIntExprContext)_localctx).Sub = intExpr(0);
				setState(51);
				match(T__1);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(61);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new BinaryIntExprContext(new IntExprContext(_parentctx, _parentState));
					((BinaryIntExprContext)_localctx).Lhs = _prevctx;
					pushNewRecursionContext(_localctx, _startState, RULE_intExpr);
					setState(55);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(56);
					((BinaryIntExprContext)_localctx).Op = intBinaryOp();
					setState(57);
					((BinaryIntExprContext)_localctx).Rhs = intExpr(3);
					}
					} 
				}
				setState(63);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class BoolExprContext extends ParserRuleContext {
		public BoolExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolExpr; }
	 
		public BoolExprContext() { }
		public void copyFrom(BoolExprContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class BinaryBoolExprContext extends BoolExprContext {
		public IntExprContext Lhs;
		public BoolBinaryOpContext Op;
		public IntExprContext Rhs;
		public List<IntExprContext> intExpr() {
			return getRuleContexts(IntExprContext.class);
		}
		public IntExprContext intExpr(int i) {
			return getRuleContext(IntExprContext.class,i);
		}
		public BoolBinaryOpContext boolBinaryOp() {
			return getRuleContext(BoolBinaryOpContext.class,0);
		}
		public BinaryBoolExprContext(BoolExprContext ctx) { copyFrom(ctx); }
	}
	public static class SubBoolExprContext extends BoolExprContext {
		public BoolExprContext Sub;
		public BoolExprContext boolExpr() {
			return getRuleContext(BoolExprContext.class,0);
		}
		public SubBoolExprContext(BoolExprContext ctx) { copyFrom(ctx); }
	}

	public final BoolExprContext boolExpr() throws RecognitionException {
		BoolExprContext _localctx = new BoolExprContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_boolExpr);
		try {
			setState(72);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				_localctx = new BinaryBoolExprContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(64);
				((BinaryBoolExprContext)_localctx).Lhs = intExpr(0);
				setState(65);
				((BinaryBoolExprContext)_localctx).Op = boolBinaryOp();
				setState(66);
				((BinaryBoolExprContext)_localctx).Rhs = intExpr(0);
				}
				break;
			case 2:
				_localctx = new SubBoolExprContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(68);
				match(T__0);
				setState(69);
				((SubBoolExprContext)_localctx).Sub = boolExpr();
				setState(70);
				match(T__1);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LogicExprContext extends ParserRuleContext {
		public LogicExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logicExpr; }
	 
		public LogicExprContext() { }
		public void copyFrom(LogicExprContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class BoolLogicExprContext extends LogicExprContext {
		public BoolExprContext Expr;
		public BoolExprContext boolExpr() {
			return getRuleContext(BoolExprContext.class,0);
		}
		public BoolLogicExprContext(LogicExprContext ctx) { copyFrom(ctx); }
	}
	public static class UnaryLogicExprContext extends LogicExprContext {
		public LogicUnaryOpContext Op;
		public LogicExprContext Sub;
		public LogicUnaryOpContext logicUnaryOp() {
			return getRuleContext(LogicUnaryOpContext.class,0);
		}
		public LogicExprContext logicExpr() {
			return getRuleContext(LogicExprContext.class,0);
		}
		public UnaryLogicExprContext(LogicExprContext ctx) { copyFrom(ctx); }
	}
	public static class SubLogicExprContext extends LogicExprContext {
		public LogicExprContext Sub;
		public LogicExprContext logicExpr() {
			return getRuleContext(LogicExprContext.class,0);
		}
		public SubLogicExprContext(LogicExprContext ctx) { copyFrom(ctx); }
	}
	public static class BinaryLogicExprContext extends LogicExprContext {
		public LogicExprContext Lhs;
		public LogicBinaryOpContext Op;
		public LogicExprContext Rhs;
		public List<LogicExprContext> logicExpr() {
			return getRuleContexts(LogicExprContext.class);
		}
		public LogicExprContext logicExpr(int i) {
			return getRuleContext(LogicExprContext.class,i);
		}
		public LogicBinaryOpContext logicBinaryOp() {
			return getRuleContext(LogicBinaryOpContext.class,0);
		}
		public BinaryLogicExprContext(LogicExprContext ctx) { copyFrom(ctx); }
	}

	public final LogicExprContext logicExpr() throws RecognitionException {
		return logicExpr(0);
	}

	private LogicExprContext logicExpr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		LogicExprContext _localctx = new LogicExprContext(_ctx, _parentState);
		LogicExprContext _prevctx = _localctx;
		int _startState = 18;
		enterRecursionRule(_localctx, 18, RULE_logicExpr, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(83);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				{
				_localctx = new BoolLogicExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(75);
				((BoolLogicExprContext)_localctx).Expr = boolExpr();
				}
				break;
			case 2:
				{
				_localctx = new UnaryLogicExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(76);
				((UnaryLogicExprContext)_localctx).Op = logicUnaryOp();
				setState(77);
				((UnaryLogicExprContext)_localctx).Sub = logicExpr(2);
				}
				break;
			case 3:
				{
				_localctx = new SubLogicExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(79);
				match(T__0);
				setState(80);
				((SubLogicExprContext)_localctx).Sub = logicExpr(0);
				setState(81);
				match(T__1);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(91);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new BinaryLogicExprContext(new LogicExprContext(_parentctx, _parentState));
					((BinaryLogicExprContext)_localctx).Lhs = _prevctx;
					pushNewRecursionContext(_localctx, _startState, RULE_logicExpr);
					setState(85);
					if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
					setState(86);
					((BinaryLogicExprContext)_localctx).Op = logicBinaryOp();
					setState(87);
					((BinaryLogicExprContext)_localctx).Rhs = logicExpr(4);
					}
					} 
				}
				setState(93);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,5,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class IdContext extends ParserRuleContext {
		public IdContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_id; }
	 
		public IdContext() { }
		public void copyFrom(IdContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class EscIdSelectorContext extends IdContext {
		public Token PropertyName;
		public TerminalNode ESC_ID() { return getToken(JPathParser.ESC_ID, 0); }
		public EscIdSelectorContext(IdContext ctx) { copyFrom(ctx); }
	}
	public static class IdSelectorContext extends IdContext {
		public Token PropertyName;
		public TerminalNode VarID() { return getToken(JPathParser.VarID, 0); }
		public IdSelectorContext(IdContext ctx) { copyFrom(ctx); }
	}

	public final IdContext id() throws RecognitionException {
		IdContext _localctx = new IdContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_id);
		try {
			setState(96);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case VarID:
				_localctx = new IdSelectorContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(94);
				((IdSelectorContext)_localctx).PropertyName = match(VarID);
				}
				break;
			case ESC_ID:
				_localctx = new EscIdSelectorContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(95);
				((EscIdSelectorContext)_localctx).PropertyName = match(ESC_ID);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class SelectorContext extends ParserRuleContext {
		public SelectorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_selector; }
	 
		public SelectorContext() { }
		public void copyFrom(SelectorContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class RootIdSelectorContext extends SelectorContext {
		public Token RootPropertyName;
		public TerminalNode RootID() { return getToken(JPathParser.RootID, 0); }
		public RootIdSelectorContext(SelectorContext ctx) { copyFrom(ctx); }
	}
	public static class NameSelectorContext extends SelectorContext {
		public IdContext Name;
		public IdContext id() {
			return getRuleContext(IdContext.class,0);
		}
		public NameSelectorContext(SelectorContext ctx) { copyFrom(ctx); }
	}
	public static class UnionSelectorContext extends SelectorContext {
		public IdContext id;
		public List<IdContext> Names = new ArrayList<IdContext>();
		public List<IdContext> id() {
			return getRuleContexts(IdContext.class);
		}
		public IdContext id(int i) {
			return getRuleContext(IdContext.class,i);
		}
		public UnionSelectorContext(SelectorContext ctx) { copyFrom(ctx); }
	}

	public final SelectorContext selector() throws RecognitionException {
		SelectorContext _localctx = new SelectorContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_selector);
		int _la;
		try {
			setState(110);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case VarID:
			case ESC_ID:
				_localctx = new NameSelectorContext(_localctx);
				enterOuterAlt(_localctx, 1);
				{
				setState(98);
				((NameSelectorContext)_localctx).Name = id();
				}
				break;
			case RootID:
				_localctx = new RootIdSelectorContext(_localctx);
				enterOuterAlt(_localctx, 2);
				{
				setState(99);
				((RootIdSelectorContext)_localctx).RootPropertyName = match(RootID);
				}
				break;
			case T__0:
				_localctx = new UnionSelectorContext(_localctx);
				enterOuterAlt(_localctx, 3);
				{
				setState(100);
				match(T__0);
				setState(101);
				((UnionSelectorContext)_localctx).id = id();
				((UnionSelectorContext)_localctx).Names.add(((UnionSelectorContext)_localctx).id);
				setState(104); 
				_errHandler.sync(this);
				_la = _input.LA(1);
				do {
					{
					{
					setState(102);
					match(PLUS);
					setState(103);
					((UnionSelectorContext)_localctx).id = id();
					((UnionSelectorContext)_localctx).Names.add(((UnionSelectorContext)_localctx).id);
					}
					}
					setState(106); 
					_errHandler.sync(this);
					_la = _input.LA(1);
				} while ( _la==PLUS );
				setState(108);
				match(T__1);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExprContext extends ParserRuleContext {
		public ExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr; }
	 
		public ExprContext() { }
		public void copyFrom(ExprContext ctx) {
			super.copyFrom(ctx);
		}
	}
	public static class MapExprContext extends ExprContext {
		public ExprContext Lhs;
		public SelectorContext Selector;
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public SelectorContext selector() {
			return getRuleContext(SelectorContext.class,0);
		}
		public MapExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class CardinalityExprContext extends ExprContext {
		public ExprContext Sub;
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public CardinalityExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class FuncAppExprContext extends ExprContext {
		public ExprContext Func;
		public ExprContext expr;
		public List<ExprContext> Args = new ArrayList<ExprContext>();
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public FuncAppExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class SubExprContext extends ExprContext {
		public ExprContext Sub;
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public SubExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class BinExprContext extends ExprContext {
		public ExprContext Lhs;
		public AnyBinaryOpContext Op;
		public ExprContext Rhs;
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public AnyBinaryOpContext anyBinaryOp() {
			return getRuleContext(AnyBinaryOpContext.class,0);
		}
		public BinExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class RangeExprContext extends ExprContext {
		public ExprContext Lhs;
		public IntExprContext Begin;
		public IntExprContext End;
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public List<IntExprContext> intExpr() {
			return getRuleContexts(IntExprContext.class);
		}
		public IntExprContext intExpr(int i) {
			return getRuleContext(IntExprContext.class,i);
		}
		public RangeExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class IndexExprContext extends ExprContext {
		public ExprContext Lhs;
		public IntExprContext Index;
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public IntExprContext intExpr() {
			return getRuleContext(IntExprContext.class,0);
		}
		public IndexExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class RegExLitExprContext extends ExprContext {
		public Token Value;
		public TerminalNode RegExLit() { return getToken(JPathParser.RegExLit, 0); }
		public RegExLitExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class SelectorExprContext extends ExprContext {
		public SelectorContext Sub;
		public SelectorContext selector() {
			return getRuleContext(SelectorContext.class,0);
		}
		public SelectorExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class FilterExprContext extends ExprContext {
		public ExprContext Lhs;
		public LogicExprContext Filter;
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public LogicExprContext logicExpr() {
			return getRuleContext(LogicExprContext.class,0);
		}
		public FilterExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class RootExprContext extends ExprContext {
		public RootExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class IntLitExprContext extends ExprContext {
		public Token Value;
		public TerminalNode IntLit() { return getToken(JPathParser.IntLit, 0); }
		public IntLitExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class PipeExprContext extends ExprContext {
		public ExprContext Input;
		public ExprContext Func;
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public PipeExprContext(ExprContext ctx) { copyFrom(ctx); }
	}
	public static class StrLitExprContext extends ExprContext {
		public Token Value;
		public TerminalNode StrLit() { return getToken(JPathParser.StrLit, 0); }
		public StrLitExprContext(ExprContext ctx) { copyFrom(ctx); }
	}

	public final ExprContext expr() throws RecognitionException {
		return expr(0);
	}

	private ExprContext expr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExprContext _localctx = new ExprContext(_ctx, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 24;
		enterRecursionRule(_localctx, 24, RULE_expr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(124);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				{
				_localctx = new RootExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;

				setState(113);
				match(T__2);
				}
				break;
			case 2:
				{
				_localctx = new SelectorExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(114);
				((SelectorExprContext)_localctx).Sub = selector();
				}
				break;
			case 3:
				{
				_localctx = new StrLitExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(115);
				((StrLitExprContext)_localctx).Value = match(StrLit);
				}
				break;
			case 4:
				{
				_localctx = new RegExLitExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(116);
				((RegExLitExprContext)_localctx).Value = match(RegExLit);
				}
				break;
			case 5:
				{
				_localctx = new IntLitExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(117);
				((IntLitExprContext)_localctx).Value = match(IntLit);
				}
				break;
			case 6:
				{
				_localctx = new CardinalityExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(118);
				match(T__7);
				setState(119);
				((CardinalityExprContext)_localctx).Sub = expr(5);
				}
				break;
			case 7:
				{
				_localctx = new SubExprContext(_localctx);
				_ctx = _localctx;
				_prevctx = _localctx;
				setState(120);
				match(T__0);
				setState(121);
				((SubExprContext)_localctx).Sub = expr(0);
				setState(122);
				match(T__1);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(167);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,12,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(165);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,11,_ctx) ) {
					case 1:
						{
						_localctx = new PipeExprContext(new ExprContext(_parentctx, _parentState));
						((PipeExprContext)_localctx).Input = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(126);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(127);
						match(T__9);
						setState(128);
						((PipeExprContext)_localctx).Func = expr(4);
						}
						break;
					case 2:
						{
						_localctx = new BinExprContext(new ExprContext(_parentctx, _parentState));
						((BinExprContext)_localctx).Lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(129);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(130);
						((BinExprContext)_localctx).Op = anyBinaryOp();
						setState(131);
						((BinExprContext)_localctx).Rhs = expr(3);
						}
						break;
					case 3:
						{
						_localctx = new MapExprContext(new ExprContext(_parentctx, _parentState));
						((MapExprContext)_localctx).Lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(133);
						if (!(precpred(_ctx, 9))) throw new FailedPredicateException(this, "precpred(_ctx, 9)");
						setState(134);
						match(T__3);
						setState(135);
						((MapExprContext)_localctx).Selector = selector();
						}
						break;
					case 4:
						{
						_localctx = new FilterExprContext(new ExprContext(_parentctx, _parentState));
						((FilterExprContext)_localctx).Lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(136);
						if (!(precpred(_ctx, 8))) throw new FailedPredicateException(this, "precpred(_ctx, 8)");
						setState(137);
						match(T__4);
						setState(138);
						((FilterExprContext)_localctx).Filter = logicExpr(0);
						setState(139);
						match(T__5);
						}
						break;
					case 5:
						{
						_localctx = new IndexExprContext(new ExprContext(_parentctx, _parentState));
						((IndexExprContext)_localctx).Lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(141);
						if (!(precpred(_ctx, 7))) throw new FailedPredicateException(this, "precpred(_ctx, 7)");
						setState(142);
						match(T__4);
						setState(143);
						((IndexExprContext)_localctx).Index = intExpr(0);
						setState(144);
						match(T__5);
						}
						break;
					case 6:
						{
						_localctx = new RangeExprContext(new ExprContext(_parentctx, _parentState));
						((RangeExprContext)_localctx).Lhs = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(146);
						if (!(precpred(_ctx, 6))) throw new FailedPredicateException(this, "precpred(_ctx, 6)");
						setState(147);
						match(T__4);
						setState(148);
						((RangeExprContext)_localctx).Begin = intExpr(0);
						setState(149);
						match(T__6);
						setState(150);
						((RangeExprContext)_localctx).End = intExpr(0);
						setState(151);
						match(T__5);
						}
						break;
					case 7:
						{
						_localctx = new FuncAppExprContext(new ExprContext(_parentctx, _parentState));
						((FuncAppExprContext)_localctx).Func = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expr);
						setState(153);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(154);
						match(T__0);
						setState(155);
						((FuncAppExprContext)_localctx).expr = expr(0);
						((FuncAppExprContext)_localctx).Args.add(((FuncAppExprContext)_localctx).expr);
						setState(160);
						_errHandler.sync(this);
						_la = _input.LA(1);
						while (_la==T__8) {
							{
							{
							setState(156);
							match(T__8);
							setState(157);
							((FuncAppExprContext)_localctx).expr = expr(0);
							((FuncAppExprContext)_localctx).Args.add(((FuncAppExprContext)_localctx).expr);
							}
							}
							setState(162);
							_errHandler.sync(this);
							_la = _input.LA(1);
						}
						setState(163);
						match(T__1);
						}
						break;
					}
					} 
				}
				setState(169);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,12,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 7:
			return intExpr_sempred((IntExprContext)_localctx, predIndex);
		case 9:
			return logicExpr_sempred((LogicExprContext)_localctx, predIndex);
		case 12:
			return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean intExpr_sempred(IntExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean logicExpr_sempred(LogicExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 1:
			return precpred(_ctx, 3);
		}
		return true;
	}
	private boolean expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 2:
			return precpred(_ctx, 3);
		case 3:
			return precpred(_ctx, 2);
		case 4:
			return precpred(_ctx, 9);
		case 5:
			return precpred(_ctx, 8);
		case 6:
			return precpred(_ctx, 7);
		case 7:
			return precpred(_ctx, 6);
		case 8:
			return precpred(_ctx, 4);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\'\u00ad\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\3\2\3\2\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6"+
		"\3\7\3\7\3\b\3\b\3\b\3\b\5\b-\n\b\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t"+
		"\5\t8\n\t\3\t\3\t\3\t\3\t\7\t>\n\t\f\t\16\tA\13\t\3\n\3\n\3\n\3\n\3\n"+
		"\3\n\3\n\3\n\5\nK\n\n\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\5\13"+
		"V\n\13\3\13\3\13\3\13\3\13\7\13\\\n\13\f\13\16\13_\13\13\3\f\3\f\5\fc"+
		"\n\f\3\r\3\r\3\r\3\r\3\r\3\r\6\rk\n\r\r\r\16\rl\3\r\3\r\5\rq\n\r\3\16"+
		"\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\5\16\177\n\16"+
		"\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16"+
		"\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16"+
		"\3\16\3\16\3\16\3\16\7\16\u00a1\n\16\f\16\16\16\u00a4\13\16\3\16\3\16"+
		"\7\16\u00a8\n\16\f\16\16\16\u00ab\13\16\3\16\2\5\20\24\32\17\2\4\6\b\n"+
		"\f\16\20\22\24\26\30\32\2\6\3\2\33\37\3\2\23\32\3\2\17\22\3\2 !\2\u00bb"+
		"\2\34\3\2\2\2\4\36\3\2\2\2\6 \3\2\2\2\b\"\3\2\2\2\n$\3\2\2\2\f&\3\2\2"+
		"\2\16,\3\2\2\2\20\67\3\2\2\2\22J\3\2\2\2\24U\3\2\2\2\26b\3\2\2\2\30p\3"+
		"\2\2\2\32~\3\2\2\2\34\35\t\2\2\2\35\3\3\2\2\2\36\37\7\33\2\2\37\5\3\2"+
		"\2\2 !\t\3\2\2!\7\3\2\2\2\"#\t\4\2\2#\t\3\2\2\2$%\7\16\2\2%\13\3\2\2\2"+
		"&\'\t\5\2\2\'\r\3\2\2\2(-\5\2\2\2)-\5\6\4\2*-\5\b\5\2+-\5\f\7\2,(\3\2"+
		"\2\2,)\3\2\2\2,*\3\2\2\2,+\3\2\2\2-\17\3\2\2\2./\b\t\1\2/8\5\32\16\2\60"+
		"\61\5\4\3\2\61\62\5\20\t\5\628\3\2\2\2\63\64\7\3\2\2\64\65\5\20\t\2\65"+
		"\66\7\4\2\2\668\3\2\2\2\67.\3\2\2\2\67\60\3\2\2\2\67\63\3\2\2\28?\3\2"+
		"\2\29:\f\4\2\2:;\5\2\2\2;<\5\20\t\5<>\3\2\2\2=9\3\2\2\2>A\3\2\2\2?=\3"+
		"\2\2\2?@\3\2\2\2@\21\3\2\2\2A?\3\2\2\2BC\5\20\t\2CD\5\6\4\2DE\5\20\t\2"+
		"EK\3\2\2\2FG\7\3\2\2GH\5\22\n\2HI\7\4\2\2IK\3\2\2\2JB\3\2\2\2JF\3\2\2"+
		"\2K\23\3\2\2\2LM\b\13\1\2MV\5\22\n\2NO\5\n\6\2OP\5\24\13\4PV\3\2\2\2Q"+
		"R\7\3\2\2RS\5\24\13\2ST\7\4\2\2TV\3\2\2\2UL\3\2\2\2UN\3\2\2\2UQ\3\2\2"+
		"\2V]\3\2\2\2WX\f\5\2\2XY\5\b\5\2YZ\5\24\13\6Z\\\3\2\2\2[W\3\2\2\2\\_\3"+
		"\2\2\2][\3\2\2\2]^\3\2\2\2^\25\3\2\2\2_]\3\2\2\2`c\7%\2\2ac\7\'\2\2b`"+
		"\3\2\2\2ba\3\2\2\2c\27\3\2\2\2dq\5\26\f\2eq\7&\2\2fg\7\3\2\2gj\5\26\f"+
		"\2hi\7\34\2\2ik\5\26\f\2jh\3\2\2\2kl\3\2\2\2lj\3\2\2\2lm\3\2\2\2mn\3\2"+
		"\2\2no\7\4\2\2oq\3\2\2\2pd\3\2\2\2pe\3\2\2\2pf\3\2\2\2q\31\3\2\2\2rs\b"+
		"\16\1\2s\177\7\5\2\2t\177\5\30\r\2u\177\7#\2\2v\177\7$\2\2w\177\7\"\2"+
		"\2xy\7\n\2\2y\177\5\32\16\7z{\7\3\2\2{|\5\32\16\2|}\7\4\2\2}\177\3\2\2"+
		"\2~r\3\2\2\2~t\3\2\2\2~u\3\2\2\2~v\3\2\2\2~w\3\2\2\2~x\3\2\2\2~z\3\2\2"+
		"\2\177\u00a9\3\2\2\2\u0080\u0081\f\5\2\2\u0081\u0082\7\f\2\2\u0082\u00a8"+
		"\5\32\16\6\u0083\u0084\f\4\2\2\u0084\u0085\5\16\b\2\u0085\u0086\5\32\16"+
		"\5\u0086\u00a8\3\2\2\2\u0087\u0088\f\13\2\2\u0088\u0089\7\6\2\2\u0089"+
		"\u00a8\5\30\r\2\u008a\u008b\f\n\2\2\u008b\u008c\7\7\2\2\u008c\u008d\5"+
		"\24\13\2\u008d\u008e\7\b\2\2\u008e\u00a8\3\2\2\2\u008f\u0090\f\t\2\2\u0090"+
		"\u0091\7\7\2\2\u0091\u0092\5\20\t\2\u0092\u0093\7\b\2\2\u0093\u00a8\3"+
		"\2\2\2\u0094\u0095\f\b\2\2\u0095\u0096\7\7\2\2\u0096\u0097\5\20\t\2\u0097"+
		"\u0098\7\t\2\2\u0098\u0099\5\20\t\2\u0099\u009a\7\b\2\2\u009a\u00a8\3"+
		"\2\2\2\u009b\u009c\f\6\2\2\u009c\u009d\7\3\2\2\u009d\u00a2\5\32\16\2\u009e"+
		"\u009f\7\13\2\2\u009f\u00a1\5\32\16\2\u00a0\u009e\3\2\2\2\u00a1\u00a4"+
		"\3\2\2\2\u00a2\u00a0\3\2\2\2\u00a2\u00a3\3\2\2\2\u00a3\u00a5\3\2\2\2\u00a4"+
		"\u00a2\3\2\2\2\u00a5\u00a6\7\4\2\2\u00a6\u00a8\3\2\2\2\u00a7\u0080\3\2"+
		"\2\2\u00a7\u0083\3\2\2\2\u00a7\u0087\3\2\2\2\u00a7\u008a\3\2\2\2\u00a7"+
		"\u008f\3\2\2\2\u00a7\u0094\3\2\2\2\u00a7\u009b\3\2\2\2\u00a8\u00ab\3\2"+
		"\2\2\u00a9\u00a7\3\2\2\2\u00a9\u00aa\3\2\2\2\u00aa\33\3\2\2\2\u00ab\u00a9"+
		"\3\2\2\2\17,\67?JU]blp~\u00a2\u00a7\u00a9";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}