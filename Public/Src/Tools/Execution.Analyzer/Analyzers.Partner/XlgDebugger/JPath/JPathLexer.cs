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
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, WS=8, NOT=9, AND=10, 
		OR=11, XOR=12, IFF=13, GTE=14, LTE=15, GT=16, LT=17, EQ=18, NEQ=19, MATCH=20, 
		NMATCH=21, MINUS=22, PLUS=23, TIMES=24, DIV=25, MOD=26, IntLit=27, StrLit=28, 
		RegExLit=29, ID=30;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "WS", "NOT", "AND", 
		"OR", "XOR", "IFF", "GTE", "LTE", "GT", "LT", "EQ", "NEQ", "MATCH", "NMATCH", 
		"MINUS", "PLUS", "TIMES", "DIV", "MOD", "IntLit", "StrLit", "RegExDelim1", 
		"RegExDelim2", "RegExLit", "ID"
	};


	public JPathLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public JPathLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'$'", "'.'", "'['", "']'", "'..'", null, "'not'", 
		"'and'", "'or'", "'xor'", "'iff'", "'>='", "'<='", "'>'", "'<'", "'='", 
		"'!='", "'~'", "'!~'", "'-'", "'+'", "'*'", "'/'", "'%'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, "WS", "NOT", "AND", "OR", 
		"XOR", "IFF", "GTE", "LTE", "GT", "LT", "EQ", "NEQ", "MATCH", "NMATCH", 
		"MINUS", "PLUS", "TIMES", "DIV", "MOD", "IntLit", "StrLit", "RegExLit", 
		"ID"
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
		'\x5964', '\x2', ' ', '\xC7', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
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
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', 
		'\x3', '\b', '\x3', '\b', '\x3', '\t', '\x6', '\t', 'T', '\n', '\t', '\r', 
		'\t', '\xE', '\t', 'U', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', 
		'\n', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', '\x3', '\v', 
		'\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', 
		'\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', 
		'\x3', '\x10', '\x3', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', '\x12', 
		'\x3', '\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', '\x14', 
		'\x3', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', '\x16', '\x3', '\x16', 
		'\x3', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', '\x3', '\x18', 
		'\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1B', 
		'\x3', '\x1B', '\x3', '\x1C', '\x6', '\x1C', '\x8C', '\n', '\x1C', '\r', 
		'\x1C', '\xE', '\x1C', '\x8D', '\x3', '\x1D', '\x3', '\x1D', '\a', '\x1D', 
		'\x92', '\n', '\x1D', '\f', '\x1D', '\xE', '\x1D', '\x95', '\v', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\a', '\x1D', '\x9A', '\n', 
		'\x1D', '\f', '\x1D', '\xE', '\x1D', '\x9D', '\v', '\x1D', '\x3', '\x1D', 
		'\x5', '\x1D', '\xA0', '\n', '\x1D', '\x3', '\x1E', '\x3', '\x1E', '\x3', 
		'\x1F', '\x3', '\x1F', '\x3', ' ', '\x3', ' ', '\x6', ' ', '\xA8', '\n', 
		' ', '\r', ' ', '\xE', ' ', '\xA9', '\x3', ' ', '\x3', ' ', '\x3', ' ', 
		'\x3', ' ', '\x6', ' ', '\xB0', '\n', ' ', '\r', ' ', '\xE', ' ', '\xB1', 
		'\x3', ' ', '\x3', ' ', '\x5', ' ', '\xB6', '\n', ' ', '\x3', '!', '\x3', 
		'!', '\a', '!', '\xBA', '\n', '!', '\f', '!', '\xE', '!', '\xBD', '\v', 
		'!', '\x3', '!', '\x3', '!', '\x6', '!', '\xC1', '\n', '!', '\r', '!', 
		'\xE', '!', '\xC2', '\x3', '!', '\x5', '!', '\xC6', '\n', '!', '\x2', 
		'\x2', '\"', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', 
		'\a', '\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', '\f', 
		'\x17', '\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', '\x11', 
		'!', '\x12', '#', '\x13', '%', '\x14', '\'', '\x15', ')', '\x16', '+', 
		'\x17', '-', '\x18', '/', '\x19', '\x31', '\x1A', '\x33', '\x1B', '\x35', 
		'\x1C', '\x37', '\x1D', '\x39', '\x1E', ';', '\x2', '=', '\x2', '?', '\x1F', 
		'\x41', ' ', '\x3', '\x2', '\v', '\x5', '\x2', '\v', '\f', '\xF', '\xF', 
		'\"', '\"', '\x3', '\x2', '\x32', ';', '\x3', '\x2', ')', ')', '\x3', 
		'\x2', '$', '$', '\x3', '\x2', '\x31', '\x31', '\x3', '\x2', '#', '#', 
		'\x4', '\x2', '\x43', '\\', '\x63', '|', '\x6', '\x2', '\x32', ';', '\x43', 
		'\\', '\x61', '\x61', '\x63', '|', '\x3', '\x2', '\x62', '\x62', '\x2', 
		'\xCF', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\t', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', '\x2', '\x17', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x2', '!', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', '\x2', '\x2', '%', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\'', '\x3', '\x2', '\x2', '\x2', '\x2', 
		')', '\x3', '\x2', '\x2', '\x2', '\x2', '+', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '-', '\x3', '\x2', '\x2', '\x2', '\x2', '/', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x31', '\x3', '\x2', '\x2', '\x2', '\x2', '\x33', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x37', '\x3', '\x2', '\x2', '\x2', '\x2', '\x39', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '?', '\x3', '\x2', '\x2', '\x2', '\x2', '\x41', '\x3', '\x2', 
		'\x2', '\x2', '\x3', '\x43', '\x3', '\x2', '\x2', '\x2', '\x5', '\x45', 
		'\x3', '\x2', '\x2', '\x2', '\a', 'G', '\x3', '\x2', '\x2', '\x2', '\t', 
		'I', '\x3', '\x2', '\x2', '\x2', '\v', 'K', '\x3', '\x2', '\x2', '\x2', 
		'\r', 'M', '\x3', '\x2', '\x2', '\x2', '\xF', 'O', '\x3', '\x2', '\x2', 
		'\x2', '\x11', 'S', '\x3', '\x2', '\x2', '\x2', '\x13', 'Y', '\x3', '\x2', 
		'\x2', '\x2', '\x15', ']', '\x3', '\x2', '\x2', '\x2', '\x17', '\x61', 
		'\x3', '\x2', '\x2', '\x2', '\x19', '\x64', '\x3', '\x2', '\x2', '\x2', 
		'\x1B', 'h', '\x3', '\x2', '\x2', '\x2', '\x1D', 'l', '\x3', '\x2', '\x2', 
		'\x2', '\x1F', 'o', '\x3', '\x2', '\x2', '\x2', '!', 'r', '\x3', '\x2', 
		'\x2', '\x2', '#', 't', '\x3', '\x2', '\x2', '\x2', '%', 'v', '\x3', '\x2', 
		'\x2', '\x2', '\'', 'x', '\x3', '\x2', '\x2', '\x2', ')', '{', '\x3', 
		'\x2', '\x2', '\x2', '+', '}', '\x3', '\x2', '\x2', '\x2', '-', '\x80', 
		'\x3', '\x2', '\x2', '\x2', '/', '\x82', '\x3', '\x2', '\x2', '\x2', '\x31', 
		'\x84', '\x3', '\x2', '\x2', '\x2', '\x33', '\x86', '\x3', '\x2', '\x2', 
		'\x2', '\x35', '\x88', '\x3', '\x2', '\x2', '\x2', '\x37', '\x8B', '\x3', 
		'\x2', '\x2', '\x2', '\x39', '\x9F', '\x3', '\x2', '\x2', '\x2', ';', 
		'\xA1', '\x3', '\x2', '\x2', '\x2', '=', '\xA3', '\x3', '\x2', '\x2', 
		'\x2', '?', '\xB5', '\x3', '\x2', '\x2', '\x2', '\x41', '\xC5', '\x3', 
		'\x2', '\x2', '\x2', '\x43', '\x44', '\a', '*', '\x2', '\x2', '\x44', 
		'\x4', '\x3', '\x2', '\x2', '\x2', '\x45', '\x46', '\a', '+', '\x2', '\x2', 
		'\x46', '\x6', '\x3', '\x2', '\x2', '\x2', 'G', 'H', '\a', '&', '\x2', 
		'\x2', 'H', '\b', '\x3', '\x2', '\x2', '\x2', 'I', 'J', '\a', '\x30', 
		'\x2', '\x2', 'J', '\n', '\x3', '\x2', '\x2', '\x2', 'K', 'L', '\a', ']', 
		'\x2', '\x2', 'L', '\f', '\x3', '\x2', '\x2', '\x2', 'M', 'N', '\a', '_', 
		'\x2', '\x2', 'N', '\xE', '\x3', '\x2', '\x2', '\x2', 'O', 'P', '\a', 
		'\x30', '\x2', '\x2', 'P', 'Q', '\a', '\x30', '\x2', '\x2', 'Q', '\x10', 
		'\x3', '\x2', '\x2', '\x2', 'R', 'T', '\t', '\x2', '\x2', '\x2', 'S', 
		'R', '\x3', '\x2', '\x2', '\x2', 'T', 'U', '\x3', '\x2', '\x2', '\x2', 
		'U', 'S', '\x3', '\x2', '\x2', '\x2', 'U', 'V', '\x3', '\x2', '\x2', '\x2', 
		'V', 'W', '\x3', '\x2', '\x2', '\x2', 'W', 'X', '\b', '\t', '\x2', '\x2', 
		'X', '\x12', '\x3', '\x2', '\x2', '\x2', 'Y', 'Z', '\a', 'p', '\x2', '\x2', 
		'Z', '[', '\a', 'q', '\x2', '\x2', '[', '\\', '\a', 'v', '\x2', '\x2', 
		'\\', '\x14', '\x3', '\x2', '\x2', '\x2', ']', '^', '\a', '\x63', '\x2', 
		'\x2', '^', '_', '\a', 'p', '\x2', '\x2', '_', '`', '\a', '\x66', '\x2', 
		'\x2', '`', '\x16', '\x3', '\x2', '\x2', '\x2', '\x61', '\x62', '\a', 
		'q', '\x2', '\x2', '\x62', '\x63', '\a', 't', '\x2', '\x2', '\x63', '\x18', 
		'\x3', '\x2', '\x2', '\x2', '\x64', '\x65', '\a', 'z', '\x2', '\x2', '\x65', 
		'\x66', '\a', 'q', '\x2', '\x2', '\x66', 'g', '\a', 't', '\x2', '\x2', 
		'g', '\x1A', '\x3', '\x2', '\x2', '\x2', 'h', 'i', '\a', 'k', '\x2', '\x2', 
		'i', 'j', '\a', 'h', '\x2', '\x2', 'j', 'k', '\a', 'h', '\x2', '\x2', 
		'k', '\x1C', '\x3', '\x2', '\x2', '\x2', 'l', 'm', '\a', '@', '\x2', '\x2', 
		'm', 'n', '\a', '?', '\x2', '\x2', 'n', '\x1E', '\x3', '\x2', '\x2', '\x2', 
		'o', 'p', '\a', '>', '\x2', '\x2', 'p', 'q', '\a', '?', '\x2', '\x2', 
		'q', ' ', '\x3', '\x2', '\x2', '\x2', 'r', 's', '\a', '@', '\x2', '\x2', 
		's', '\"', '\x3', '\x2', '\x2', '\x2', 't', 'u', '\a', '>', '\x2', '\x2', 
		'u', '$', '\x3', '\x2', '\x2', '\x2', 'v', 'w', '\a', '?', '\x2', '\x2', 
		'w', '&', '\x3', '\x2', '\x2', '\x2', 'x', 'y', '\a', '#', '\x2', '\x2', 
		'y', 'z', '\a', '?', '\x2', '\x2', 'z', '(', '\x3', '\x2', '\x2', '\x2', 
		'{', '|', '\a', '\x80', '\x2', '\x2', '|', '*', '\x3', '\x2', '\x2', '\x2', 
		'}', '~', '\a', '#', '\x2', '\x2', '~', '\x7F', '\a', '\x80', '\x2', '\x2', 
		'\x7F', ',', '\x3', '\x2', '\x2', '\x2', '\x80', '\x81', '\a', '/', '\x2', 
		'\x2', '\x81', '.', '\x3', '\x2', '\x2', '\x2', '\x82', '\x83', '\a', 
		'-', '\x2', '\x2', '\x83', '\x30', '\x3', '\x2', '\x2', '\x2', '\x84', 
		'\x85', '\a', ',', '\x2', '\x2', '\x85', '\x32', '\x3', '\x2', '\x2', 
		'\x2', '\x86', '\x87', '\a', '\x31', '\x2', '\x2', '\x87', '\x34', '\x3', 
		'\x2', '\x2', '\x2', '\x88', '\x89', '\a', '\'', '\x2', '\x2', '\x89', 
		'\x36', '\x3', '\x2', '\x2', '\x2', '\x8A', '\x8C', '\t', '\x3', '\x2', 
		'\x2', '\x8B', '\x8A', '\x3', '\x2', '\x2', '\x2', '\x8C', '\x8D', '\x3', 
		'\x2', '\x2', '\x2', '\x8D', '\x8B', '\x3', '\x2', '\x2', '\x2', '\x8D', 
		'\x8E', '\x3', '\x2', '\x2', '\x2', '\x8E', '\x38', '\x3', '\x2', '\x2', 
		'\x2', '\x8F', '\x93', '\a', ')', '\x2', '\x2', '\x90', '\x92', '\n', 
		'\x4', '\x2', '\x2', '\x91', '\x90', '\x3', '\x2', '\x2', '\x2', '\x92', 
		'\x95', '\x3', '\x2', '\x2', '\x2', '\x93', '\x91', '\x3', '\x2', '\x2', 
		'\x2', '\x93', '\x94', '\x3', '\x2', '\x2', '\x2', '\x94', '\x96', '\x3', 
		'\x2', '\x2', '\x2', '\x95', '\x93', '\x3', '\x2', '\x2', '\x2', '\x96', 
		'\xA0', '\a', ')', '\x2', '\x2', '\x97', '\x9B', '\a', '$', '\x2', '\x2', 
		'\x98', '\x9A', '\n', '\x5', '\x2', '\x2', '\x99', '\x98', '\x3', '\x2', 
		'\x2', '\x2', '\x9A', '\x9D', '\x3', '\x2', '\x2', '\x2', '\x9B', '\x99', 
		'\x3', '\x2', '\x2', '\x2', '\x9B', '\x9C', '\x3', '\x2', '\x2', '\x2', 
		'\x9C', '\x9E', '\x3', '\x2', '\x2', '\x2', '\x9D', '\x9B', '\x3', '\x2', 
		'\x2', '\x2', '\x9E', '\xA0', '\a', '$', '\x2', '\x2', '\x9F', '\x8F', 
		'\x3', '\x2', '\x2', '\x2', '\x9F', '\x97', '\x3', '\x2', '\x2', '\x2', 
		'\xA0', ':', '\x3', '\x2', '\x2', '\x2', '\xA1', '\xA2', '\a', '\x31', 
		'\x2', '\x2', '\xA2', '<', '\x3', '\x2', '\x2', '\x2', '\xA3', '\xA4', 
		'\a', '#', '\x2', '\x2', '\xA4', '>', '\x3', '\x2', '\x2', '\x2', '\xA5', 
		'\xA7', '\x5', ';', '\x1E', '\x2', '\xA6', '\xA8', '\n', '\x6', '\x2', 
		'\x2', '\xA7', '\xA6', '\x3', '\x2', '\x2', '\x2', '\xA8', '\xA9', '\x3', 
		'\x2', '\x2', '\x2', '\xA9', '\xA7', '\x3', '\x2', '\x2', '\x2', '\xA9', 
		'\xAA', '\x3', '\x2', '\x2', '\x2', '\xAA', '\xAB', '\x3', '\x2', '\x2', 
		'\x2', '\xAB', '\xAC', '\x5', ';', '\x1E', '\x2', '\xAC', '\xB6', '\x3', 
		'\x2', '\x2', '\x2', '\xAD', '\xAF', '\x5', '=', '\x1F', '\x2', '\xAE', 
		'\xB0', '\n', '\a', '\x2', '\x2', '\xAF', '\xAE', '\x3', '\x2', '\x2', 
		'\x2', '\xB0', '\xB1', '\x3', '\x2', '\x2', '\x2', '\xB1', '\xAF', '\x3', 
		'\x2', '\x2', '\x2', '\xB1', '\xB2', '\x3', '\x2', '\x2', '\x2', '\xB2', 
		'\xB3', '\x3', '\x2', '\x2', '\x2', '\xB3', '\xB4', '\x5', '=', '\x1F', 
		'\x2', '\xB4', '\xB6', '\x3', '\x2', '\x2', '\x2', '\xB5', '\xA5', '\x3', 
		'\x2', '\x2', '\x2', '\xB5', '\xAD', '\x3', '\x2', '\x2', '\x2', '\xB6', 
		'@', '\x3', '\x2', '\x2', '\x2', '\xB7', '\xBB', '\t', '\b', '\x2', '\x2', 
		'\xB8', '\xBA', '\t', '\t', '\x2', '\x2', '\xB9', '\xB8', '\x3', '\x2', 
		'\x2', '\x2', '\xBA', '\xBD', '\x3', '\x2', '\x2', '\x2', '\xBB', '\xB9', 
		'\x3', '\x2', '\x2', '\x2', '\xBB', '\xBC', '\x3', '\x2', '\x2', '\x2', 
		'\xBC', '\xC6', '\x3', '\x2', '\x2', '\x2', '\xBD', '\xBB', '\x3', '\x2', 
		'\x2', '\x2', '\xBE', '\xC0', '\a', '\x62', '\x2', '\x2', '\xBF', '\xC1', 
		'\n', '\n', '\x2', '\x2', '\xC0', '\xBF', '\x3', '\x2', '\x2', '\x2', 
		'\xC1', '\xC2', '\x3', '\x2', '\x2', '\x2', '\xC2', '\xC0', '\x3', '\x2', 
		'\x2', '\x2', '\xC2', '\xC3', '\x3', '\x2', '\x2', '\x2', '\xC3', '\xC4', 
		'\x3', '\x2', '\x2', '\x2', '\xC4', '\xC6', '\a', '\x62', '\x2', '\x2', 
		'\xC5', '\xB7', '\x3', '\x2', '\x2', '\x2', '\xC5', '\xBE', '\x3', '\x2', 
		'\x2', '\x2', '\xC6', '\x42', '\x3', '\x2', '\x2', '\x2', '\xE', '\x2', 
		'U', '\x8D', '\x93', '\x9B', '\x9F', '\xA9', '\xB1', '\xB5', '\xBB', '\xC2', 
		'\xC5', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace BuildXL.Execution.Analyzer.JPath
