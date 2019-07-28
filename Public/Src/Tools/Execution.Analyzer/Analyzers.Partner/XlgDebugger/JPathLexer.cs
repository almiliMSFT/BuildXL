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
		NMATCH=21, MINUS=22, IntLit=23, StrLit=24, RegExLit=25, ID=26;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "WS", "NOT", "AND", 
		"OR", "XOR", "IFF", "GTE", "LTE", "GT", "LT", "EQ", "NEQ", "MATCH", "NMATCH", 
		"MINUS", "IntLit", "StrLit", "RegExLit", "ID"
	};


	public JPathLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public JPathLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'$'", "'..'", "'.'", "'['", "']'", "'('", "')'", null, "'not'", 
		"'and'", "'or'", "'xor'", "'iff'", "'>='", "'<='", "'>'", "'<'", "'='", 
		"'!='", "'~'", "'!~'", "'-'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, "WS", "NOT", "AND", "OR", 
		"XOR", "IFF", "GTE", "LTE", "GT", "LT", "EQ", "NEQ", "MATCH", "NMATCH", 
		"MINUS", "IntLit", "StrLit", "RegExLit", "ID"
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
		'\x5964', '\x2', '\x1C', '\xAF', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', 
		'\x3', '\b', '\x3', '\t', '\x6', '\t', 'H', '\n', '\t', '\r', '\t', '\xE', 
		'\t', 'I', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', 
		'\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', 
		'\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', '\x3', '\x10', 
		'\x3', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', '\x12', '\x3', '\x12', 
		'\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', 
		'\x3', '\x15', '\x3', '\x15', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', 
		'\x3', '\x17', '\x3', '\x17', '\x3', '\x18', '\x3', '\x18', '\a', '\x18', 
		'y', '\n', '\x18', '\f', '\x18', '\xE', '\x18', '|', '\v', '\x18', '\x3', 
		'\x19', '\x3', '\x19', '\a', '\x19', '\x80', '\n', '\x19', '\f', '\x19', 
		'\xE', '\x19', '\x83', '\v', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', 
		'\x19', '\a', '\x19', '\x88', '\n', '\x19', '\f', '\x19', '\xE', '\x19', 
		'\x8B', '\v', '\x19', '\x3', '\x19', '\x5', '\x19', '\x8E', '\n', '\x19', 
		'\x3', '\x1A', '\x3', '\x1A', '\x6', '\x1A', '\x92', '\n', '\x1A', '\r', 
		'\x1A', '\xE', '\x1A', '\x93', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', 
		'\x6', '\x1A', '\x99', '\n', '\x1A', '\r', '\x1A', '\xE', '\x1A', '\x9A', 
		'\x3', '\x1A', '\x5', '\x1A', '\x9E', '\n', '\x1A', '\x3', '\x1B', '\x3', 
		'\x1B', '\a', '\x1B', '\xA2', '\n', '\x1B', '\f', '\x1B', '\xE', '\x1B', 
		'\xA5', '\v', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x6', '\x1B', '\xA9', 
		'\n', '\x1B', '\r', '\x1B', '\xE', '\x1B', '\xAA', '\x3', '\x1B', '\x5', 
		'\x1B', '\xAE', '\n', '\x1B', '\x2', '\x2', '\x1C', '\x3', '\x3', '\x5', 
		'\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\t', 
		'\x11', '\n', '\x13', '\v', '\x15', '\f', '\x17', '\r', '\x19', '\xE', 
		'\x1B', '\xF', '\x1D', '\x10', '\x1F', '\x11', '!', '\x12', '#', '\x13', 
		'%', '\x14', '\'', '\x15', ')', '\x16', '+', '\x17', '-', '\x18', '/', 
		'\x19', '\x31', '\x1A', '\x33', '\x1B', '\x35', '\x1C', '\x3', '\x2', 
		'\f', '\x5', '\x2', '\v', '\f', '\xF', '\xF', '\"', '\"', '\x3', '\x2', 
		'\x33', ';', '\x3', '\x2', '\x32', ';', '\x3', '\x2', ')', ')', '\x3', 
		'\x2', '$', '$', '\x3', '\x2', '\x31', '\x31', '\x3', '\x2', '#', '#', 
		'\x4', '\x2', '\x43', '\\', '\x63', '|', '\x6', '\x2', '\x32', ';', '\x43', 
		'\\', '\x61', '\x61', '\x63', '|', '\x3', '\x2', '\x62', '\x62', '\x2', 
		'\xB9', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', '\x3', 
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
		'\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', '\x2', '\x2', '\x3', 
		'\x37', '\x3', '\x2', '\x2', '\x2', '\x5', '\x39', '\x3', '\x2', '\x2', 
		'\x2', '\a', '<', '\x3', '\x2', '\x2', '\x2', '\t', '>', '\x3', '\x2', 
		'\x2', '\x2', '\v', '@', '\x3', '\x2', '\x2', '\x2', '\r', '\x42', '\x3', 
		'\x2', '\x2', '\x2', '\xF', '\x44', '\x3', '\x2', '\x2', '\x2', '\x11', 
		'G', '\x3', '\x2', '\x2', '\x2', '\x13', 'M', '\x3', '\x2', '\x2', '\x2', 
		'\x15', 'Q', '\x3', '\x2', '\x2', '\x2', '\x17', 'U', '\x3', '\x2', '\x2', 
		'\x2', '\x19', 'X', '\x3', '\x2', '\x2', '\x2', '\x1B', '\\', '\x3', '\x2', 
		'\x2', '\x2', '\x1D', '`', '\x3', '\x2', '\x2', '\x2', '\x1F', '\x63', 
		'\x3', '\x2', '\x2', '\x2', '!', '\x66', '\x3', '\x2', '\x2', '\x2', '#', 
		'h', '\x3', '\x2', '\x2', '\x2', '%', 'j', '\x3', '\x2', '\x2', '\x2', 
		'\'', 'l', '\x3', '\x2', '\x2', '\x2', ')', 'o', '\x3', '\x2', '\x2', 
		'\x2', '+', 'q', '\x3', '\x2', '\x2', '\x2', '-', 't', '\x3', '\x2', '\x2', 
		'\x2', '/', 'v', '\x3', '\x2', '\x2', '\x2', '\x31', '\x8D', '\x3', '\x2', 
		'\x2', '\x2', '\x33', '\x9D', '\x3', '\x2', '\x2', '\x2', '\x35', '\xAD', 
		'\x3', '\x2', '\x2', '\x2', '\x37', '\x38', '\a', '&', '\x2', '\x2', '\x38', 
		'\x4', '\x3', '\x2', '\x2', '\x2', '\x39', ':', '\a', '\x30', '\x2', '\x2', 
		':', ';', '\a', '\x30', '\x2', '\x2', ';', '\x6', '\x3', '\x2', '\x2', 
		'\x2', '<', '=', '\a', '\x30', '\x2', '\x2', '=', '\b', '\x3', '\x2', 
		'\x2', '\x2', '>', '?', '\a', ']', '\x2', '\x2', '?', '\n', '\x3', '\x2', 
		'\x2', '\x2', '@', '\x41', '\a', '_', '\x2', '\x2', '\x41', '\f', '\x3', 
		'\x2', '\x2', '\x2', '\x42', '\x43', '\a', '*', '\x2', '\x2', '\x43', 
		'\xE', '\x3', '\x2', '\x2', '\x2', '\x44', '\x45', '\a', '+', '\x2', '\x2', 
		'\x45', '\x10', '\x3', '\x2', '\x2', '\x2', '\x46', 'H', '\t', '\x2', 
		'\x2', '\x2', 'G', '\x46', '\x3', '\x2', '\x2', '\x2', 'H', 'I', '\x3', 
		'\x2', '\x2', '\x2', 'I', 'G', '\x3', '\x2', '\x2', '\x2', 'I', 'J', '\x3', 
		'\x2', '\x2', '\x2', 'J', 'K', '\x3', '\x2', '\x2', '\x2', 'K', 'L', '\b', 
		'\t', '\x2', '\x2', 'L', '\x12', '\x3', '\x2', '\x2', '\x2', 'M', 'N', 
		'\a', 'p', '\x2', '\x2', 'N', 'O', '\a', 'q', '\x2', '\x2', 'O', 'P', 
		'\a', 'v', '\x2', '\x2', 'P', '\x14', '\x3', '\x2', '\x2', '\x2', 'Q', 
		'R', '\a', '\x63', '\x2', '\x2', 'R', 'S', '\a', 'p', '\x2', '\x2', 'S', 
		'T', '\a', '\x66', '\x2', '\x2', 'T', '\x16', '\x3', '\x2', '\x2', '\x2', 
		'U', 'V', '\a', 'q', '\x2', '\x2', 'V', 'W', '\a', 't', '\x2', '\x2', 
		'W', '\x18', '\x3', '\x2', '\x2', '\x2', 'X', 'Y', '\a', 'z', '\x2', '\x2', 
		'Y', 'Z', '\a', 'q', '\x2', '\x2', 'Z', '[', '\a', 't', '\x2', '\x2', 
		'[', '\x1A', '\x3', '\x2', '\x2', '\x2', '\\', ']', '\a', 'k', '\x2', 
		'\x2', ']', '^', '\a', 'h', '\x2', '\x2', '^', '_', '\a', 'h', '\x2', 
		'\x2', '_', '\x1C', '\x3', '\x2', '\x2', '\x2', '`', '\x61', '\a', '@', 
		'\x2', '\x2', '\x61', '\x62', '\a', '?', '\x2', '\x2', '\x62', '\x1E', 
		'\x3', '\x2', '\x2', '\x2', '\x63', '\x64', '\a', '>', '\x2', '\x2', '\x64', 
		'\x65', '\a', '?', '\x2', '\x2', '\x65', ' ', '\x3', '\x2', '\x2', '\x2', 
		'\x66', 'g', '\a', '@', '\x2', '\x2', 'g', '\"', '\x3', '\x2', '\x2', 
		'\x2', 'h', 'i', '\a', '>', '\x2', '\x2', 'i', '$', '\x3', '\x2', '\x2', 
		'\x2', 'j', 'k', '\a', '?', '\x2', '\x2', 'k', '&', '\x3', '\x2', '\x2', 
		'\x2', 'l', 'm', '\a', '#', '\x2', '\x2', 'm', 'n', '\a', '?', '\x2', 
		'\x2', 'n', '(', '\x3', '\x2', '\x2', '\x2', 'o', 'p', '\a', '\x80', '\x2', 
		'\x2', 'p', '*', '\x3', '\x2', '\x2', '\x2', 'q', 'r', '\a', '#', '\x2', 
		'\x2', 'r', 's', '\a', '\x80', '\x2', '\x2', 's', ',', '\x3', '\x2', '\x2', 
		'\x2', 't', 'u', '\a', '/', '\x2', '\x2', 'u', '.', '\x3', '\x2', '\x2', 
		'\x2', 'v', 'z', '\t', '\x3', '\x2', '\x2', 'w', 'y', '\t', '\x4', '\x2', 
		'\x2', 'x', 'w', '\x3', '\x2', '\x2', '\x2', 'y', '|', '\x3', '\x2', '\x2', 
		'\x2', 'z', 'x', '\x3', '\x2', '\x2', '\x2', 'z', '{', '\x3', '\x2', '\x2', 
		'\x2', '{', '\x30', '\x3', '\x2', '\x2', '\x2', '|', 'z', '\x3', '\x2', 
		'\x2', '\x2', '}', '\x81', '\a', ')', '\x2', '\x2', '~', '\x80', '\n', 
		'\x5', '\x2', '\x2', '\x7F', '~', '\x3', '\x2', '\x2', '\x2', '\x80', 
		'\x83', '\x3', '\x2', '\x2', '\x2', '\x81', '\x7F', '\x3', '\x2', '\x2', 
		'\x2', '\x81', '\x82', '\x3', '\x2', '\x2', '\x2', '\x82', '\x84', '\x3', 
		'\x2', '\x2', '\x2', '\x83', '\x81', '\x3', '\x2', '\x2', '\x2', '\x84', 
		'\x8E', '\a', ')', '\x2', '\x2', '\x85', '\x89', '\a', '$', '\x2', '\x2', 
		'\x86', '\x88', '\n', '\x6', '\x2', '\x2', '\x87', '\x86', '\x3', '\x2', 
		'\x2', '\x2', '\x88', '\x8B', '\x3', '\x2', '\x2', '\x2', '\x89', '\x87', 
		'\x3', '\x2', '\x2', '\x2', '\x89', '\x8A', '\x3', '\x2', '\x2', '\x2', 
		'\x8A', '\x8C', '\x3', '\x2', '\x2', '\x2', '\x8B', '\x89', '\x3', '\x2', 
		'\x2', '\x2', '\x8C', '\x8E', '\a', '$', '\x2', '\x2', '\x8D', '}', '\x3', 
		'\x2', '\x2', '\x2', '\x8D', '\x85', '\x3', '\x2', '\x2', '\x2', '\x8E', 
		'\x32', '\x3', '\x2', '\x2', '\x2', '\x8F', '\x91', '\a', '\x31', '\x2', 
		'\x2', '\x90', '\x92', '\n', '\a', '\x2', '\x2', '\x91', '\x90', '\x3', 
		'\x2', '\x2', '\x2', '\x92', '\x93', '\x3', '\x2', '\x2', '\x2', '\x93', 
		'\x91', '\x3', '\x2', '\x2', '\x2', '\x93', '\x94', '\x3', '\x2', '\x2', 
		'\x2', '\x94', '\x95', '\x3', '\x2', '\x2', '\x2', '\x95', '\x9E', '\a', 
		'\x31', '\x2', '\x2', '\x96', '\x98', '\a', '#', '\x2', '\x2', '\x97', 
		'\x99', '\n', '\b', '\x2', '\x2', '\x98', '\x97', '\x3', '\x2', '\x2', 
		'\x2', '\x99', '\x9A', '\x3', '\x2', '\x2', '\x2', '\x9A', '\x98', '\x3', 
		'\x2', '\x2', '\x2', '\x9A', '\x9B', '\x3', '\x2', '\x2', '\x2', '\x9B', 
		'\x9C', '\x3', '\x2', '\x2', '\x2', '\x9C', '\x9E', '\a', '#', '\x2', 
		'\x2', '\x9D', '\x8F', '\x3', '\x2', '\x2', '\x2', '\x9D', '\x96', '\x3', 
		'\x2', '\x2', '\x2', '\x9E', '\x34', '\x3', '\x2', '\x2', '\x2', '\x9F', 
		'\xA3', '\t', '\t', '\x2', '\x2', '\xA0', '\xA2', '\t', '\n', '\x2', '\x2', 
		'\xA1', '\xA0', '\x3', '\x2', '\x2', '\x2', '\xA2', '\xA5', '\x3', '\x2', 
		'\x2', '\x2', '\xA3', '\xA1', '\x3', '\x2', '\x2', '\x2', '\xA3', '\xA4', 
		'\x3', '\x2', '\x2', '\x2', '\xA4', '\xAE', '\x3', '\x2', '\x2', '\x2', 
		'\xA5', '\xA3', '\x3', '\x2', '\x2', '\x2', '\xA6', '\xA8', '\a', '\x62', 
		'\x2', '\x2', '\xA7', '\xA9', '\n', '\v', '\x2', '\x2', '\xA8', '\xA7', 
		'\x3', '\x2', '\x2', '\x2', '\xA9', '\xAA', '\x3', '\x2', '\x2', '\x2', 
		'\xAA', '\xA8', '\x3', '\x2', '\x2', '\x2', '\xAA', '\xAB', '\x3', '\x2', 
		'\x2', '\x2', '\xAB', '\xAC', '\x3', '\x2', '\x2', '\x2', '\xAC', '\xAE', 
		'\a', '\x62', '\x2', '\x2', '\xAD', '\x9F', '\x3', '\x2', '\x2', '\x2', 
		'\xAD', '\xA6', '\x3', '\x2', '\x2', '\x2', '\xAE', '\x36', '\x3', '\x2', 
		'\x2', '\x2', '\xE', '\x2', 'I', 'z', '\x81', '\x89', '\x8D', '\x93', 
		'\x9A', '\x9D', '\xA3', '\xAA', '\xAD', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace BuildXL.Execution.Analyzer.JPath
