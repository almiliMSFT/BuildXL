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
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class JPathLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, WS=14, NOT=15, AND=16, OR=17, XOR=18, 
		IFF=19, GTE=20, LTE=21, GT=22, LT=23, EQ=24, NEQ=25, MATCH=26, NMATCH=27, 
		MINUS=28, PLUS=29, TIMES=30, DIV=31, MOD=32, CONCAT=33, INTERSECT=34, 
		IntLit=35, StrLit=36, RegExLit=37, VarID=38, RootID=39, EscID=40, Switch=41;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "WS", "NOT", "AND", "OR", "XOR", "IFF", 
		"GTE", "LTE", "GT", "LT", "EQ", "NEQ", "MATCH", "NMATCH", "MINUS", "PLUS", 
		"TIMES", "DIV", "MOD", "CONCAT", "INTERSECT", "IntLit", "StrLit", "RegExLit", 
		"IdFragment", "VarID", "RootID", "EscID", "Switch"
	};


	public JPathLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public JPathLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'$'", "'.'", "'['", "']'", "'..'", "'#'", "','", 
		"'|'", "'let'", "':='", "'in'", null, "'not'", "'and'", "'or'", "'xor'", 
		"'iff'", "'>='", "'<='", "'>'", "'<'", "'='", "'!='", "'~'", "'!~'", "'-'", 
		"'+'", "'*'", "'/'", "'%'", "'++'", "'&'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, "WS", "NOT", "AND", "OR", "XOR", "IFF", "GTE", "LTE", "GT", 
		"LT", "EQ", "NEQ", "MATCH", "NMATCH", "MINUS", "PLUS", "TIMES", "DIV", 
		"MOD", "CONCAT", "INTERSECT", "IntLit", "StrLit", "RegExLit", "VarID", 
		"RootID", "EscID", "Switch"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "JPath.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static JPathLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '+', '\xF4', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x4', '*', '\t', '*', '\x4', '+', '\t', '+', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', 
		'\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', 
		'\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', 
		'\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', '\r', 
		'\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', '\x6', '\xF', 
		'x', '\n', '\xF', '\r', '\xF', '\xE', '\xF', 'y', '\x3', '\xF', '\x3', 
		'\xF', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', 
		'\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x12', '\x3', 
		'\x12', '\x3', '\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', 
		'\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', 
		'\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x16', '\x3', '\x16', '\x3', 
		'\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', '\x3', '\x18', '\x3', 
		'\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', 
		'\x1B', '\x3', '\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', 
		'\x1D', '\x3', '\x1D', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1F', '\x3', 
		'\x1F', '\x3', ' ', '\x3', ' ', '\x3', '!', '\x3', '!', '\x3', '\"', '\x3', 
		'\"', '\x3', '\"', '\x3', '#', '\x3', '#', '\x3', '$', '\x6', '$', '\xB5', 
		'\n', '$', '\r', '$', '\xE', '$', '\xB6', '\x3', '%', '\x3', '%', '\a', 
		'%', '\xBB', '\n', '%', '\f', '%', '\xE', '%', '\xBE', '\v', '%', '\x3', 
		'%', '\x3', '%', '\x3', '%', '\a', '%', '\xC3', '\n', '%', '\f', '%', 
		'\xE', '%', '\xC6', '\v', '%', '\x3', '%', '\x5', '%', '\xC9', '\n', '%', 
		'\x3', '&', '\x3', '&', '\x6', '&', '\xCD', '\n', '&', '\r', '&', '\xE', 
		'&', '\xCE', '\x3', '&', '\x3', '&', '\x3', '&', '\x6', '&', '\xD4', '\n', 
		'&', '\r', '&', '\xE', '&', '\xD5', '\x3', '&', '\x5', '&', '\xD9', '\n', 
		'&', '\x3', '\'', '\x3', '\'', '\a', '\'', '\xDD', '\n', '\'', '\f', '\'', 
		'\xE', '\'', '\xE0', '\v', '\'', '\x3', '(', '\x3', '(', '\x3', ')', '\x3', 
		')', '\x3', ')', '\x3', '*', '\x3', '*', '\x6', '*', '\xE9', '\n', '*', 
		'\r', '*', '\xE', '*', '\xEA', '\x3', '*', '\x3', '*', '\x3', '+', '\x3', 
		'+', '\x6', '+', '\xF1', '\n', '+', '\r', '+', '\xE', '+', '\xF2', '\x2', 
		'\x2', ',', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', 
		'\a', '\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', '\f', 
		'\x17', '\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', '\x11', 
		'!', '\x12', '#', '\x13', '%', '\x14', '\'', '\x15', ')', '\x16', '+', 
		'\x17', '-', '\x18', '/', '\x19', '\x31', '\x1A', '\x33', '\x1B', '\x35', 
		'\x1C', '\x37', '\x1D', '\x39', '\x1E', ';', '\x1F', '=', ' ', '?', '!', 
		'\x41', '\"', '\x43', '#', '\x45', '$', 'G', '%', 'I', '&', 'K', '\'', 
		'M', '\x2', 'O', '(', 'Q', ')', 'S', '*', 'U', '+', '\x3', '\x2', '\f', 
		'\x5', '\x2', '\v', '\f', '\xF', '\xF', '\"', '\"', '\x3', '\x2', '\x32', 
		';', '\x3', '\x2', ')', ')', '\x3', '\x2', '$', '$', '\x3', '\x2', '\x31', 
		'\x31', '\x3', '\x2', '#', '#', '\x4', '\x2', '\x43', '\\', '\x63', '|', 
		'\x6', '\x2', '\x32', ';', '\x43', '\\', '\x61', '\x61', '\x63', '|', 
		'\x3', '\x2', '\x62', '\x62', '\x6', '\x2', ')', ')', '\x32', ';', '\x43', 
		'\\', '\x63', '|', '\x2', '\xFD', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x13', '\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', '\'', '\x3', 
		'\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', '\x2', '+', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'/', '\x3', '\x2', '\x2', '\x2', '\x2', '\x31', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x33', '\x3', '\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x37', '\x3', '\x2', '\x2', '\x2', '\x2', '\x39', 
		'\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'=', '\x3', '\x2', '\x2', '\x2', '\x2', '?', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x41', '\x3', '\x2', '\x2', '\x2', '\x2', '\x43', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x45', '\x3', '\x2', '\x2', '\x2', '\x2', 'G', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'I', '\x3', '\x2', '\x2', '\x2', '\x2', 'K', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'O', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'Q', '\x3', '\x2', '\x2', '\x2', '\x2', 'S', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'U', '\x3', '\x2', '\x2', '\x2', '\x3', 'W', '\x3', '\x2', '\x2', 
		'\x2', '\x5', 'Y', '\x3', '\x2', '\x2', '\x2', '\a', '[', '\x3', '\x2', 
		'\x2', '\x2', '\t', ']', '\x3', '\x2', '\x2', '\x2', '\v', '_', '\x3', 
		'\x2', '\x2', '\x2', '\r', '\x61', '\x3', '\x2', '\x2', '\x2', '\xF', 
		'\x63', '\x3', '\x2', '\x2', '\x2', '\x11', '\x66', '\x3', '\x2', '\x2', 
		'\x2', '\x13', 'h', '\x3', '\x2', '\x2', '\x2', '\x15', 'j', '\x3', '\x2', 
		'\x2', '\x2', '\x17', 'l', '\x3', '\x2', '\x2', '\x2', '\x19', 'p', '\x3', 
		'\x2', '\x2', '\x2', '\x1B', 's', '\x3', '\x2', '\x2', '\x2', '\x1D', 
		'w', '\x3', '\x2', '\x2', '\x2', '\x1F', '}', '\x3', '\x2', '\x2', '\x2', 
		'!', '\x81', '\x3', '\x2', '\x2', '\x2', '#', '\x85', '\x3', '\x2', '\x2', 
		'\x2', '%', '\x88', '\x3', '\x2', '\x2', '\x2', '\'', '\x8C', '\x3', '\x2', 
		'\x2', '\x2', ')', '\x90', '\x3', '\x2', '\x2', '\x2', '+', '\x93', '\x3', 
		'\x2', '\x2', '\x2', '-', '\x96', '\x3', '\x2', '\x2', '\x2', '/', '\x98', 
		'\x3', '\x2', '\x2', '\x2', '\x31', '\x9A', '\x3', '\x2', '\x2', '\x2', 
		'\x33', '\x9C', '\x3', '\x2', '\x2', '\x2', '\x35', '\x9F', '\x3', '\x2', 
		'\x2', '\x2', '\x37', '\xA1', '\x3', '\x2', '\x2', '\x2', '\x39', '\xA4', 
		'\x3', '\x2', '\x2', '\x2', ';', '\xA6', '\x3', '\x2', '\x2', '\x2', '=', 
		'\xA8', '\x3', '\x2', '\x2', '\x2', '?', '\xAA', '\x3', '\x2', '\x2', 
		'\x2', '\x41', '\xAC', '\x3', '\x2', '\x2', '\x2', '\x43', '\xAE', '\x3', 
		'\x2', '\x2', '\x2', '\x45', '\xB1', '\x3', '\x2', '\x2', '\x2', 'G', 
		'\xB4', '\x3', '\x2', '\x2', '\x2', 'I', '\xC8', '\x3', '\x2', '\x2', 
		'\x2', 'K', '\xD8', '\x3', '\x2', '\x2', '\x2', 'M', '\xDA', '\x3', '\x2', 
		'\x2', '\x2', 'O', '\xE1', '\x3', '\x2', '\x2', '\x2', 'Q', '\xE3', '\x3', 
		'\x2', '\x2', '\x2', 'S', '\xE6', '\x3', '\x2', '\x2', '\x2', 'U', '\xEE', 
		'\x3', '\x2', '\x2', '\x2', 'W', 'X', '\a', '*', '\x2', '\x2', 'X', '\x4', 
		'\x3', '\x2', '\x2', '\x2', 'Y', 'Z', '\a', '+', '\x2', '\x2', 'Z', '\x6', 
		'\x3', '\x2', '\x2', '\x2', '[', '\\', '\a', '&', '\x2', '\x2', '\\', 
		'\b', '\x3', '\x2', '\x2', '\x2', ']', '^', '\a', '\x30', '\x2', '\x2', 
		'^', '\n', '\x3', '\x2', '\x2', '\x2', '_', '`', '\a', ']', '\x2', '\x2', 
		'`', '\f', '\x3', '\x2', '\x2', '\x2', '\x61', '\x62', '\a', '_', '\x2', 
		'\x2', '\x62', '\xE', '\x3', '\x2', '\x2', '\x2', '\x63', '\x64', '\a', 
		'\x30', '\x2', '\x2', '\x64', '\x65', '\a', '\x30', '\x2', '\x2', '\x65', 
		'\x10', '\x3', '\x2', '\x2', '\x2', '\x66', 'g', '\a', '%', '\x2', '\x2', 
		'g', '\x12', '\x3', '\x2', '\x2', '\x2', 'h', 'i', '\a', '.', '\x2', '\x2', 
		'i', '\x14', '\x3', '\x2', '\x2', '\x2', 'j', 'k', '\a', '~', '\x2', '\x2', 
		'k', '\x16', '\x3', '\x2', '\x2', '\x2', 'l', 'm', '\a', 'n', '\x2', '\x2', 
		'm', 'n', '\a', 'g', '\x2', '\x2', 'n', 'o', '\a', 'v', '\x2', '\x2', 
		'o', '\x18', '\x3', '\x2', '\x2', '\x2', 'p', 'q', '\a', '<', '\x2', '\x2', 
		'q', 'r', '\a', '?', '\x2', '\x2', 'r', '\x1A', '\x3', '\x2', '\x2', '\x2', 
		's', 't', '\a', 'k', '\x2', '\x2', 't', 'u', '\a', 'p', '\x2', '\x2', 
		'u', '\x1C', '\x3', '\x2', '\x2', '\x2', 'v', 'x', '\t', '\x2', '\x2', 
		'\x2', 'w', 'v', '\x3', '\x2', '\x2', '\x2', 'x', 'y', '\x3', '\x2', '\x2', 
		'\x2', 'y', 'w', '\x3', '\x2', '\x2', '\x2', 'y', 'z', '\x3', '\x2', '\x2', 
		'\x2', 'z', '{', '\x3', '\x2', '\x2', '\x2', '{', '|', '\b', '\xF', '\x2', 
		'\x2', '|', '\x1E', '\x3', '\x2', '\x2', '\x2', '}', '~', '\a', 'p', '\x2', 
		'\x2', '~', '\x7F', '\a', 'q', '\x2', '\x2', '\x7F', '\x80', '\a', 'v', 
		'\x2', '\x2', '\x80', ' ', '\x3', '\x2', '\x2', '\x2', '\x81', '\x82', 
		'\a', '\x63', '\x2', '\x2', '\x82', '\x83', '\a', 'p', '\x2', '\x2', '\x83', 
		'\x84', '\a', '\x66', '\x2', '\x2', '\x84', '\"', '\x3', '\x2', '\x2', 
		'\x2', '\x85', '\x86', '\a', 'q', '\x2', '\x2', '\x86', '\x87', '\a', 
		't', '\x2', '\x2', '\x87', '$', '\x3', '\x2', '\x2', '\x2', '\x88', '\x89', 
		'\a', 'z', '\x2', '\x2', '\x89', '\x8A', '\a', 'q', '\x2', '\x2', '\x8A', 
		'\x8B', '\a', 't', '\x2', '\x2', '\x8B', '&', '\x3', '\x2', '\x2', '\x2', 
		'\x8C', '\x8D', '\a', 'k', '\x2', '\x2', '\x8D', '\x8E', '\a', 'h', '\x2', 
		'\x2', '\x8E', '\x8F', '\a', 'h', '\x2', '\x2', '\x8F', '(', '\x3', '\x2', 
		'\x2', '\x2', '\x90', '\x91', '\a', '@', '\x2', '\x2', '\x91', '\x92', 
		'\a', '?', '\x2', '\x2', '\x92', '*', '\x3', '\x2', '\x2', '\x2', '\x93', 
		'\x94', '\a', '>', '\x2', '\x2', '\x94', '\x95', '\a', '?', '\x2', '\x2', 
		'\x95', ',', '\x3', '\x2', '\x2', '\x2', '\x96', '\x97', '\a', '@', '\x2', 
		'\x2', '\x97', '.', '\x3', '\x2', '\x2', '\x2', '\x98', '\x99', '\a', 
		'>', '\x2', '\x2', '\x99', '\x30', '\x3', '\x2', '\x2', '\x2', '\x9A', 
		'\x9B', '\a', '?', '\x2', '\x2', '\x9B', '\x32', '\x3', '\x2', '\x2', 
		'\x2', '\x9C', '\x9D', '\a', '#', '\x2', '\x2', '\x9D', '\x9E', '\a', 
		'?', '\x2', '\x2', '\x9E', '\x34', '\x3', '\x2', '\x2', '\x2', '\x9F', 
		'\xA0', '\a', '\x80', '\x2', '\x2', '\xA0', '\x36', '\x3', '\x2', '\x2', 
		'\x2', '\xA1', '\xA2', '\a', '#', '\x2', '\x2', '\xA2', '\xA3', '\a', 
		'\x80', '\x2', '\x2', '\xA3', '\x38', '\x3', '\x2', '\x2', '\x2', '\xA4', 
		'\xA5', '\a', '/', '\x2', '\x2', '\xA5', ':', '\x3', '\x2', '\x2', '\x2', 
		'\xA6', '\xA7', '\a', '-', '\x2', '\x2', '\xA7', '<', '\x3', '\x2', '\x2', 
		'\x2', '\xA8', '\xA9', '\a', ',', '\x2', '\x2', '\xA9', '>', '\x3', '\x2', 
		'\x2', '\x2', '\xAA', '\xAB', '\a', '\x31', '\x2', '\x2', '\xAB', '@', 
		'\x3', '\x2', '\x2', '\x2', '\xAC', '\xAD', '\a', '\'', '\x2', '\x2', 
		'\xAD', '\x42', '\x3', '\x2', '\x2', '\x2', '\xAE', '\xAF', '\a', '-', 
		'\x2', '\x2', '\xAF', '\xB0', '\a', '-', '\x2', '\x2', '\xB0', '\x44', 
		'\x3', '\x2', '\x2', '\x2', '\xB1', '\xB2', '\a', '(', '\x2', '\x2', '\xB2', 
		'\x46', '\x3', '\x2', '\x2', '\x2', '\xB3', '\xB5', '\t', '\x3', '\x2', 
		'\x2', '\xB4', '\xB3', '\x3', '\x2', '\x2', '\x2', '\xB5', '\xB6', '\x3', 
		'\x2', '\x2', '\x2', '\xB6', '\xB4', '\x3', '\x2', '\x2', '\x2', '\xB6', 
		'\xB7', '\x3', '\x2', '\x2', '\x2', '\xB7', 'H', '\x3', '\x2', '\x2', 
		'\x2', '\xB8', '\xBC', '\a', ')', '\x2', '\x2', '\xB9', '\xBB', '\n', 
		'\x4', '\x2', '\x2', '\xBA', '\xB9', '\x3', '\x2', '\x2', '\x2', '\xBB', 
		'\xBE', '\x3', '\x2', '\x2', '\x2', '\xBC', '\xBA', '\x3', '\x2', '\x2', 
		'\x2', '\xBC', '\xBD', '\x3', '\x2', '\x2', '\x2', '\xBD', '\xBF', '\x3', 
		'\x2', '\x2', '\x2', '\xBE', '\xBC', '\x3', '\x2', '\x2', '\x2', '\xBF', 
		'\xC9', '\a', ')', '\x2', '\x2', '\xC0', '\xC4', '\a', '$', '\x2', '\x2', 
		'\xC1', '\xC3', '\n', '\x5', '\x2', '\x2', '\xC2', '\xC1', '\x3', '\x2', 
		'\x2', '\x2', '\xC3', '\xC6', '\x3', '\x2', '\x2', '\x2', '\xC4', '\xC2', 
		'\x3', '\x2', '\x2', '\x2', '\xC4', '\xC5', '\x3', '\x2', '\x2', '\x2', 
		'\xC5', '\xC7', '\x3', '\x2', '\x2', '\x2', '\xC6', '\xC4', '\x3', '\x2', 
		'\x2', '\x2', '\xC7', '\xC9', '\a', '$', '\x2', '\x2', '\xC8', '\xB8', 
		'\x3', '\x2', '\x2', '\x2', '\xC8', '\xC0', '\x3', '\x2', '\x2', '\x2', 
		'\xC9', 'J', '\x3', '\x2', '\x2', '\x2', '\xCA', '\xCC', '\a', '\x31', 
		'\x2', '\x2', '\xCB', '\xCD', '\n', '\x6', '\x2', '\x2', '\xCC', '\xCB', 
		'\x3', '\x2', '\x2', '\x2', '\xCD', '\xCE', '\x3', '\x2', '\x2', '\x2', 
		'\xCE', '\xCC', '\x3', '\x2', '\x2', '\x2', '\xCE', '\xCF', '\x3', '\x2', 
		'\x2', '\x2', '\xCF', '\xD0', '\x3', '\x2', '\x2', '\x2', '\xD0', '\xD9', 
		'\a', '\x31', '\x2', '\x2', '\xD1', '\xD3', '\a', '#', '\x2', '\x2', '\xD2', 
		'\xD4', '\n', '\a', '\x2', '\x2', '\xD3', '\xD2', '\x3', '\x2', '\x2', 
		'\x2', '\xD4', '\xD5', '\x3', '\x2', '\x2', '\x2', '\xD5', '\xD3', '\x3', 
		'\x2', '\x2', '\x2', '\xD5', '\xD6', '\x3', '\x2', '\x2', '\x2', '\xD6', 
		'\xD7', '\x3', '\x2', '\x2', '\x2', '\xD7', '\xD9', '\a', '#', '\x2', 
		'\x2', '\xD8', '\xCA', '\x3', '\x2', '\x2', '\x2', '\xD8', '\xD1', '\x3', 
		'\x2', '\x2', '\x2', '\xD9', 'L', '\x3', '\x2', '\x2', '\x2', '\xDA', 
		'\xDE', '\t', '\b', '\x2', '\x2', '\xDB', '\xDD', '\t', '\t', '\x2', '\x2', 
		'\xDC', '\xDB', '\x3', '\x2', '\x2', '\x2', '\xDD', '\xE0', '\x3', '\x2', 
		'\x2', '\x2', '\xDE', '\xDC', '\x3', '\x2', '\x2', '\x2', '\xDE', '\xDF', 
		'\x3', '\x2', '\x2', '\x2', '\xDF', 'N', '\x3', '\x2', '\x2', '\x2', '\xE0', 
		'\xDE', '\x3', '\x2', '\x2', '\x2', '\xE1', '\xE2', '\x5', 'M', '\'', 
		'\x2', '\xE2', 'P', '\x3', '\x2', '\x2', '\x2', '\xE3', '\xE4', '\a', 
		'&', '\x2', '\x2', '\xE4', '\xE5', '\x5', 'M', '\'', '\x2', '\xE5', 'R', 
		'\x3', '\x2', '\x2', '\x2', '\xE6', '\xE8', '\a', '\x62', '\x2', '\x2', 
		'\xE7', '\xE9', '\n', '\n', '\x2', '\x2', '\xE8', '\xE7', '\x3', '\x2', 
		'\x2', '\x2', '\xE9', '\xEA', '\x3', '\x2', '\x2', '\x2', '\xEA', '\xE8', 
		'\x3', '\x2', '\x2', '\x2', '\xEA', '\xEB', '\x3', '\x2', '\x2', '\x2', 
		'\xEB', '\xEC', '\x3', '\x2', '\x2', '\x2', '\xEC', '\xED', '\a', '\x62', 
		'\x2', '\x2', '\xED', 'T', '\x3', '\x2', '\x2', '\x2', '\xEE', '\xF0', 
		'\a', '/', '\x2', '\x2', '\xEF', '\xF1', '\t', '\v', '\x2', '\x2', '\xF0', 
		'\xEF', '\x3', '\x2', '\x2', '\x2', '\xF1', '\xF2', '\x3', '\x2', '\x2', 
		'\x2', '\xF2', '\xF0', '\x3', '\x2', '\x2', '\x2', '\xF2', '\xF3', '\x3', 
		'\x2', '\x2', '\x2', '\xF3', 'V', '\x3', '\x2', '\x2', '\x2', '\xE', '\x2', 
		'y', '\xB6', '\xBC', '\xC4', '\xC8', '\xCE', '\xD5', '\xD8', '\xDE', '\xEA', 
		'\xF2', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace BuildXL.Execution.Analyzer.JPath
