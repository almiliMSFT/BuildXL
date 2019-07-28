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
		T__0=1, T__1=2, T__2=3, T__3=4, ID=5, WS=6, GTE=7, LTE=8, GT=9, LT=10, 
		EQ=11, NEQ=12, MATCH=13, NMATCH=14, IntLit=15, StrLit=16, RegExLit=17;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "ID", "WS", "GTE", "LTE", "GT", "LT", 
		"EQ", "NEQ", "MATCH", "NMATCH", "IntLit", "StrLit", "RegExLit"
	};


	public JPathLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public JPathLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'.'", "'['", "']'", "'..'", null, null, "'>='", "'<='", "'>'", 
		"'<'", "'='", "'!='", "'~'", "'!~'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, "ID", "WS", "GTE", "LTE", "GT", "LT", "EQ", 
		"NEQ", "MATCH", "NMATCH", "IntLit", "StrLit", "RegExLit"
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
		'\x5964', '\x2', '\x13', 'q', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x3', '\x2', '\x3', 
		'\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\a', '\x6', 
		'\x31', '\n', '\x6', '\f', '\x6', '\xE', '\x6', '\x34', '\v', '\x6', '\x3', 
		'\a', '\x6', '\a', '\x37', '\n', '\a', '\r', '\a', '\xE', '\a', '\x38', 
		'\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', 
		'\t', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\v', 
		'\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', 
		'\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\x10', '\x3', '\x10', '\a', '\x10', 'S', '\n', '\x10', '\f', '\x10', 
		'\xE', '\x10', 'V', '\v', '\x10', '\x3', '\x11', '\x3', '\x11', '\a', 
		'\x11', 'Z', '\n', '\x11', '\f', '\x11', '\xE', '\x11', ']', '\v', '\x11', 
		'\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\a', '\x11', '\x62', '\n', 
		'\x11', '\f', '\x11', '\xE', '\x11', '\x65', '\v', '\x11', '\x3', '\x11', 
		'\x5', '\x11', 'h', '\n', '\x11', '\x3', '\x12', '\x3', '\x12', '\x6', 
		'\x12', 'l', '\n', '\x12', '\r', '\x12', '\xE', '\x12', 'm', '\x3', '\x12', 
		'\x3', '\x12', '\x2', '\x2', '\x13', '\x3', '\x3', '\x5', '\x4', '\a', 
		'\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', 
		'\x13', '\v', '\x15', '\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', 
		'\x1D', '\x10', '\x1F', '\x11', '!', '\x12', '#', '\x13', '\x3', '\x2', 
		'\n', '\x4', '\x2', '\x43', '\\', '\x63', '|', '\x6', '\x2', '\x32', ';', 
		'\x43', '\\', '\x61', '\x61', '\x63', '|', '\x5', '\x2', '\v', '\f', '\xF', 
		'\xF', '\"', '\"', '\x3', '\x2', '\x33', ';', '\x3', '\x2', '\x32', ';', 
		'\x4', '\x2', ')', ')', '`', '`', '\x4', '\x2', '$', '$', '`', '`', '\x4', 
		'\x2', '\x31', '\x31', '`', '`', '\x2', 'w', '\x2', '\x3', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\xF', '\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x19', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', 
		'\x3', '\x2', '\x2', '\x2', '\x3', '%', '\x3', '\x2', '\x2', '\x2', '\x5', 
		'\'', '\x3', '\x2', '\x2', '\x2', '\a', ')', '\x3', '\x2', '\x2', '\x2', 
		'\t', '+', '\x3', '\x2', '\x2', '\x2', '\v', '.', '\x3', '\x2', '\x2', 
		'\x2', '\r', '\x36', '\x3', '\x2', '\x2', '\x2', '\xF', '<', '\x3', '\x2', 
		'\x2', '\x2', '\x11', '?', '\x3', '\x2', '\x2', '\x2', '\x13', '\x42', 
		'\x3', '\x2', '\x2', '\x2', '\x15', '\x44', '\x3', '\x2', '\x2', '\x2', 
		'\x17', '\x46', '\x3', '\x2', '\x2', '\x2', '\x19', 'H', '\x3', '\x2', 
		'\x2', '\x2', '\x1B', 'K', '\x3', '\x2', '\x2', '\x2', '\x1D', 'M', '\x3', 
		'\x2', '\x2', '\x2', '\x1F', 'P', '\x3', '\x2', '\x2', '\x2', '!', 'g', 
		'\x3', '\x2', '\x2', '\x2', '#', 'i', '\x3', '\x2', '\x2', '\x2', '%', 
		'&', '\a', '\x30', '\x2', '\x2', '&', '\x4', '\x3', '\x2', '\x2', '\x2', 
		'\'', '(', '\a', ']', '\x2', '\x2', '(', '\x6', '\x3', '\x2', '\x2', '\x2', 
		')', '*', '\a', '_', '\x2', '\x2', '*', '\b', '\x3', '\x2', '\x2', '\x2', 
		'+', ',', '\a', '\x30', '\x2', '\x2', ',', '-', '\a', '\x30', '\x2', '\x2', 
		'-', '\n', '\x3', '\x2', '\x2', '\x2', '.', '\x32', '\t', '\x2', '\x2', 
		'\x2', '/', '\x31', '\t', '\x3', '\x2', '\x2', '\x30', '/', '\x3', '\x2', 
		'\x2', '\x2', '\x31', '\x34', '\x3', '\x2', '\x2', '\x2', '\x32', '\x30', 
		'\x3', '\x2', '\x2', '\x2', '\x32', '\x33', '\x3', '\x2', '\x2', '\x2', 
		'\x33', '\f', '\x3', '\x2', '\x2', '\x2', '\x34', '\x32', '\x3', '\x2', 
		'\x2', '\x2', '\x35', '\x37', '\t', '\x4', '\x2', '\x2', '\x36', '\x35', 
		'\x3', '\x2', '\x2', '\x2', '\x37', '\x38', '\x3', '\x2', '\x2', '\x2', 
		'\x38', '\x36', '\x3', '\x2', '\x2', '\x2', '\x38', '\x39', '\x3', '\x2', 
		'\x2', '\x2', '\x39', ':', '\x3', '\x2', '\x2', '\x2', ':', ';', '\b', 
		'\a', '\x2', '\x2', ';', '\xE', '\x3', '\x2', '\x2', '\x2', '<', '=', 
		'\a', '@', '\x2', '\x2', '=', '>', '\a', '?', '\x2', '\x2', '>', '\x10', 
		'\x3', '\x2', '\x2', '\x2', '?', '@', '\a', '>', '\x2', '\x2', '@', '\x41', 
		'\a', '?', '\x2', '\x2', '\x41', '\x12', '\x3', '\x2', '\x2', '\x2', '\x42', 
		'\x43', '\a', '@', '\x2', '\x2', '\x43', '\x14', '\x3', '\x2', '\x2', 
		'\x2', '\x44', '\x45', '\a', '>', '\x2', '\x2', '\x45', '\x16', '\x3', 
		'\x2', '\x2', '\x2', '\x46', 'G', '\a', '?', '\x2', '\x2', 'G', '\x18', 
		'\x3', '\x2', '\x2', '\x2', 'H', 'I', '\a', '#', '\x2', '\x2', 'I', 'J', 
		'\a', '?', '\x2', '\x2', 'J', '\x1A', '\x3', '\x2', '\x2', '\x2', 'K', 
		'L', '\a', '\x80', '\x2', '\x2', 'L', '\x1C', '\x3', '\x2', '\x2', '\x2', 
		'M', 'N', '\a', '#', '\x2', '\x2', 'N', 'O', '\a', '\x80', '\x2', '\x2', 
		'O', '\x1E', '\x3', '\x2', '\x2', '\x2', 'P', 'T', '\t', '\x5', '\x2', 
		'\x2', 'Q', 'S', '\t', '\x6', '\x2', '\x2', 'R', 'Q', '\x3', '\x2', '\x2', 
		'\x2', 'S', 'V', '\x3', '\x2', '\x2', '\x2', 'T', 'R', '\x3', '\x2', '\x2', 
		'\x2', 'T', 'U', '\x3', '\x2', '\x2', '\x2', 'U', ' ', '\x3', '\x2', '\x2', 
		'\x2', 'V', 'T', '\x3', '\x2', '\x2', '\x2', 'W', '[', '\a', ')', '\x2', 
		'\x2', 'X', 'Z', '\t', '\a', '\x2', '\x2', 'Y', 'X', '\x3', '\x2', '\x2', 
		'\x2', 'Z', ']', '\x3', '\x2', '\x2', '\x2', '[', 'Y', '\x3', '\x2', '\x2', 
		'\x2', '[', '\\', '\x3', '\x2', '\x2', '\x2', '\\', '^', '\x3', '\x2', 
		'\x2', '\x2', ']', '[', '\x3', '\x2', '\x2', '\x2', '^', 'h', '\a', ')', 
		'\x2', '\x2', '_', '\x63', '\a', '$', '\x2', '\x2', '`', '\x62', '\t', 
		'\b', '\x2', '\x2', '\x61', '`', '\x3', '\x2', '\x2', '\x2', '\x62', '\x65', 
		'\x3', '\x2', '\x2', '\x2', '\x63', '\x61', '\x3', '\x2', '\x2', '\x2', 
		'\x63', '\x64', '\x3', '\x2', '\x2', '\x2', '\x64', '\x66', '\x3', '\x2', 
		'\x2', '\x2', '\x65', '\x63', '\x3', '\x2', '\x2', '\x2', '\x66', 'h', 
		'\a', '$', '\x2', '\x2', 'g', 'W', '\x3', '\x2', '\x2', '\x2', 'g', '_', 
		'\x3', '\x2', '\x2', '\x2', 'h', '\"', '\x3', '\x2', '\x2', '\x2', 'i', 
		'k', '\a', '\x31', '\x2', '\x2', 'j', 'l', '\t', '\t', '\x2', '\x2', 'k', 
		'j', '\x3', '\x2', '\x2', '\x2', 'l', 'm', '\x3', '\x2', '\x2', '\x2', 
		'm', 'k', '\x3', '\x2', '\x2', '\x2', 'm', 'n', '\x3', '\x2', '\x2', '\x2', 
		'n', 'o', '\x3', '\x2', '\x2', '\x2', 'o', 'p', '\a', '\x31', '\x2', '\x2', 
		'p', '$', '\x3', '\x2', '\x2', '\x2', '\n', '\x2', '\x32', '\x38', 'T', 
		'[', '\x63', 'g', 'm', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace BuildXL.Execution.Analyzer.JPath
