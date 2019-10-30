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
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, WS=20, NOT=21, AND=22, OR=23, XOR=24, IFF=25, GTE=26, 
		LTE=27, GT=28, LT=29, EQ=30, NEQ=31, MATCH=32, NMATCH=33, MINUS=34, PLUS=35, 
		TIMES=36, DIV=37, MOD=38, UNION=39, DIFFERENCE=40, INTERSECT=41, IntLit=42, 
		StrLit=43, RegExLit=44, PropertyId=45, VarId=46, EscID=47, Opt=48;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "WS", "NOT", "AND", "OR", "XOR", "IFF", "GTE", "LTE", 
		"GT", "LT", "EQ", "NEQ", "MATCH", "NMATCH", "MINUS", "PLUS", "TIMES", 
		"DIV", "MOD", "UNION", "DIFFERENCE", "INTERSECT", "IntLit", "StrLit", 
		"RegExLit", "IdFragment", "PropertyId", "VarId", "EscID", "Opt"
	};


	public JPathLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public JPathLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "':'", "'{'", "','", "'}'", "'$'", "'.'", "'['", "']'", "'..'", 
		"'#'", "'('", "')'", "'|'", "'|>'", "'|>>'", "'let'", "':='", "'in'", 
		"';'", null, "'not'", "'and'", "'or'", "'xor'", "'iff'", "'>='", "'<='", 
		"'>'", "'<'", "'='", "'!='", "'~'", "'!~'", "'-'", "'+'", "'*'", "'/'", 
		"'%'", "'++'", "'--'", "'&'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, "WS", "NOT", "AND", "OR", 
		"XOR", "IFF", "GTE", "LTE", "GT", "LT", "EQ", "NEQ", "MATCH", "NMATCH", 
		"MINUS", "PLUS", "TIMES", "DIV", "MOD", "UNION", "DIFFERENCE", "INTERSECT", 
		"IntLit", "StrLit", "RegExLit", "PropertyId", "VarId", "EscID", "Opt"
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
		'\x5964', '\x2', '\x32', '\x117', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
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
		'\t', ')', '\x4', '*', '\t', '*', '\x4', '+', '\t', '+', '\x4', ',', '\t', 
		',', '\x4', '-', '\t', '-', '\x4', '.', '\t', '.', '\x4', '/', '\t', '/', 
		'\x4', '\x30', '\t', '\x30', '\x4', '\x31', '\t', '\x31', '\x4', '\x32', 
		'\t', '\x32', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', 
		'\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\v', 
		'\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', '\x3', 
		'\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x12', '\x3', '\x12', '\x3', 
		'\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', 
		'\x14', '\x3', '\x15', '\x6', '\x15', '\x95', '\n', '\x15', '\r', '\x15', 
		'\xE', '\x15', '\x96', '\x3', '\x15', '\x3', '\x15', '\x3', '\x16', '\x3', 
		'\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', 
		'\x17', '\x3', '\x17', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', 
		'\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', 
		'\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1B', '\x3', '\x1B', '\x3', 
		'\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x3', 
		'\x1D', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1F', '\x3', '\x1F', '\x3', 
		' ', '\x3', ' ', '\x3', ' ', '\x3', '!', '\x3', '!', '\x3', '\"', '\x3', 
		'\"', '\x3', '\"', '\x3', '#', '\x3', '#', '\x3', '$', '\x3', '$', '\x3', 
		'%', '\x3', '%', '\x3', '&', '\x3', '&', '\x3', '\'', '\x3', '\'', '\x3', 
		'(', '\x3', '(', '\x3', '(', '\x3', ')', '\x3', ')', '\x3', ')', '\x3', 
		'*', '\x3', '*', '\x3', '+', '\x5', '+', '\xD5', '\n', '+', '\x3', '+', 
		'\x6', '+', '\xD8', '\n', '+', '\r', '+', '\xE', '+', '\xD9', '\x3', ',', 
		'\x3', ',', '\a', ',', '\xDE', '\n', ',', '\f', ',', '\xE', ',', '\xE1', 
		'\v', ',', '\x3', ',', '\x3', ',', '\x3', ',', '\a', ',', '\xE6', '\n', 
		',', '\f', ',', '\xE', ',', '\xE9', '\v', ',', '\x3', ',', '\x5', ',', 
		'\xEC', '\n', ',', '\x3', '-', '\x3', '-', '\x6', '-', '\xF0', '\n', '-', 
		'\r', '-', '\xE', '-', '\xF1', '\x3', '-', '\x3', '-', '\x3', '-', '\x6', 
		'-', '\xF7', '\n', '-', '\r', '-', '\xE', '-', '\xF8', '\x3', '-', '\x5', 
		'-', '\xFC', '\n', '-', '\x3', '.', '\x3', '.', '\a', '.', '\x100', '\n', 
		'.', '\f', '.', '\xE', '.', '\x103', '\v', '.', '\x3', '/', '\x3', '/', 
		'\x3', '\x30', '\x3', '\x30', '\x3', '\x30', '\x3', '\x31', '\x3', '\x31', 
		'\x6', '\x31', '\x10C', '\n', '\x31', '\r', '\x31', '\xE', '\x31', '\x10D', 
		'\x3', '\x31', '\x3', '\x31', '\x3', '\x32', '\x3', '\x32', '\x6', '\x32', 
		'\x114', '\n', '\x32', '\r', '\x32', '\xE', '\x32', '\x115', '\x2', '\x2', 
		'\x33', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', '\v', '\a', 
		'\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', '\f', '\x17', 
		'\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', '\x11', '!', 
		'\x12', '#', '\x13', '%', '\x14', '\'', '\x15', ')', '\x16', '+', '\x17', 
		'-', '\x18', '/', '\x19', '\x31', '\x1A', '\x33', '\x1B', '\x35', '\x1C', 
		'\x37', '\x1D', '\x39', '\x1E', ';', '\x1F', '=', ' ', '?', '!', '\x41', 
		'\"', '\x43', '#', '\x45', '$', 'G', '%', 'I', '&', 'K', '\'', 'M', '(', 
		'O', ')', 'Q', '*', 'S', '+', 'U', ',', 'W', '-', 'Y', '.', '[', '\x2', 
		']', '/', '_', '\x30', '\x61', '\x31', '\x63', '\x32', '\x3', '\x2', '\f', 
		'\x5', '\x2', '\v', '\f', '\xF', '\xF', '\"', '\"', '\x3', '\x2', '\x32', 
		';', '\x3', '\x2', ')', ')', '\x3', '\x2', '$', '$', '\x3', '\x2', '\x31', 
		'\x31', '\x3', '\x2', '#', '#', '\x5', '\x2', '\x43', '\\', '\x61', '\x61', 
		'\x63', '|', '\x6', '\x2', '\x32', ';', '\x43', '\\', '\x61', '\x61', 
		'\x63', '|', '\x3', '\x2', '\x62', '\x62', '\x6', '\x2', ')', ')', '\x32', 
		';', '\x43', '\\', '\x63', '|', '\x2', '\x121', '\x2', '\x3', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\xF', '\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x19', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\'', '\x3', '\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '+', '\x3', '\x2', '\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '/', '\x3', '\x2', '\x2', '\x2', '\x2', '\x31', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x33', '\x3', '\x2', '\x2', '\x2', '\x2', '\x35', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x37', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x39', '\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '=', '\x3', '\x2', '\x2', '\x2', '\x2', '?', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x41', '\x3', '\x2', '\x2', '\x2', '\x2', '\x43', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x45', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'G', '\x3', '\x2', '\x2', '\x2', '\x2', 'I', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'K', '\x3', '\x2', '\x2', '\x2', '\x2', 'M', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'O', '\x3', '\x2', '\x2', '\x2', '\x2', 'Q', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'S', '\x3', '\x2', '\x2', '\x2', '\x2', 'U', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'W', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'Y', '\x3', '\x2', '\x2', '\x2', '\x2', ']', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '_', '\x3', '\x2', '\x2', '\x2', '\x2', '\x61', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x63', '\x3', '\x2', '\x2', '\x2', '\x3', '\x65', '\x3', 
		'\x2', '\x2', '\x2', '\x5', 'g', '\x3', '\x2', '\x2', '\x2', '\a', 'i', 
		'\x3', '\x2', '\x2', '\x2', '\t', 'k', '\x3', '\x2', '\x2', '\x2', '\v', 
		'm', '\x3', '\x2', '\x2', '\x2', '\r', 'o', '\x3', '\x2', '\x2', '\x2', 
		'\xF', 'q', '\x3', '\x2', '\x2', '\x2', '\x11', 's', '\x3', '\x2', '\x2', 
		'\x2', '\x13', 'u', '\x3', '\x2', '\x2', '\x2', '\x15', 'x', '\x3', '\x2', 
		'\x2', '\x2', '\x17', 'z', '\x3', '\x2', '\x2', '\x2', '\x19', '|', '\x3', 
		'\x2', '\x2', '\x2', '\x1B', '~', '\x3', '\x2', '\x2', '\x2', '\x1D', 
		'\x80', '\x3', '\x2', '\x2', '\x2', '\x1F', '\x83', '\x3', '\x2', '\x2', 
		'\x2', '!', '\x87', '\x3', '\x2', '\x2', '\x2', '#', '\x8B', '\x3', '\x2', 
		'\x2', '\x2', '%', '\x8E', '\x3', '\x2', '\x2', '\x2', '\'', '\x91', '\x3', 
		'\x2', '\x2', '\x2', ')', '\x94', '\x3', '\x2', '\x2', '\x2', '+', '\x9A', 
		'\x3', '\x2', '\x2', '\x2', '-', '\x9E', '\x3', '\x2', '\x2', '\x2', '/', 
		'\xA2', '\x3', '\x2', '\x2', '\x2', '\x31', '\xA5', '\x3', '\x2', '\x2', 
		'\x2', '\x33', '\xA9', '\x3', '\x2', '\x2', '\x2', '\x35', '\xAD', '\x3', 
		'\x2', '\x2', '\x2', '\x37', '\xB0', '\x3', '\x2', '\x2', '\x2', '\x39', 
		'\xB3', '\x3', '\x2', '\x2', '\x2', ';', '\xB5', '\x3', '\x2', '\x2', 
		'\x2', '=', '\xB7', '\x3', '\x2', '\x2', '\x2', '?', '\xB9', '\x3', '\x2', 
		'\x2', '\x2', '\x41', '\xBC', '\x3', '\x2', '\x2', '\x2', '\x43', '\xBE', 
		'\x3', '\x2', '\x2', '\x2', '\x45', '\xC1', '\x3', '\x2', '\x2', '\x2', 
		'G', '\xC3', '\x3', '\x2', '\x2', '\x2', 'I', '\xC5', '\x3', '\x2', '\x2', 
		'\x2', 'K', '\xC7', '\x3', '\x2', '\x2', '\x2', 'M', '\xC9', '\x3', '\x2', 
		'\x2', '\x2', 'O', '\xCB', '\x3', '\x2', '\x2', '\x2', 'Q', '\xCE', '\x3', 
		'\x2', '\x2', '\x2', 'S', '\xD1', '\x3', '\x2', '\x2', '\x2', 'U', '\xD4', 
		'\x3', '\x2', '\x2', '\x2', 'W', '\xEB', '\x3', '\x2', '\x2', '\x2', 'Y', 
		'\xFB', '\x3', '\x2', '\x2', '\x2', '[', '\xFD', '\x3', '\x2', '\x2', 
		'\x2', ']', '\x104', '\x3', '\x2', '\x2', '\x2', '_', '\x106', '\x3', 
		'\x2', '\x2', '\x2', '\x61', '\x109', '\x3', '\x2', '\x2', '\x2', '\x63', 
		'\x111', '\x3', '\x2', '\x2', '\x2', '\x65', '\x66', '\a', '<', '\x2', 
		'\x2', '\x66', '\x4', '\x3', '\x2', '\x2', '\x2', 'g', 'h', '\a', '}', 
		'\x2', '\x2', 'h', '\x6', '\x3', '\x2', '\x2', '\x2', 'i', 'j', '\a', 
		'.', '\x2', '\x2', 'j', '\b', '\x3', '\x2', '\x2', '\x2', 'k', 'l', '\a', 
		'\x7F', '\x2', '\x2', 'l', '\n', '\x3', '\x2', '\x2', '\x2', 'm', 'n', 
		'\a', '&', '\x2', '\x2', 'n', '\f', '\x3', '\x2', '\x2', '\x2', 'o', 'p', 
		'\a', '\x30', '\x2', '\x2', 'p', '\xE', '\x3', '\x2', '\x2', '\x2', 'q', 
		'r', '\a', ']', '\x2', '\x2', 'r', '\x10', '\x3', '\x2', '\x2', '\x2', 
		's', 't', '\a', '_', '\x2', '\x2', 't', '\x12', '\x3', '\x2', '\x2', '\x2', 
		'u', 'v', '\a', '\x30', '\x2', '\x2', 'v', 'w', '\a', '\x30', '\x2', '\x2', 
		'w', '\x14', '\x3', '\x2', '\x2', '\x2', 'x', 'y', '\a', '%', '\x2', '\x2', 
		'y', '\x16', '\x3', '\x2', '\x2', '\x2', 'z', '{', '\a', '*', '\x2', '\x2', 
		'{', '\x18', '\x3', '\x2', '\x2', '\x2', '|', '}', '\a', '+', '\x2', '\x2', 
		'}', '\x1A', '\x3', '\x2', '\x2', '\x2', '~', '\x7F', '\a', '~', '\x2', 
		'\x2', '\x7F', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x80', '\x81', '\a', 
		'~', '\x2', '\x2', '\x81', '\x82', '\a', '@', '\x2', '\x2', '\x82', '\x1E', 
		'\x3', '\x2', '\x2', '\x2', '\x83', '\x84', '\a', '~', '\x2', '\x2', '\x84', 
		'\x85', '\a', '@', '\x2', '\x2', '\x85', '\x86', '\a', '@', '\x2', '\x2', 
		'\x86', ' ', '\x3', '\x2', '\x2', '\x2', '\x87', '\x88', '\a', 'n', '\x2', 
		'\x2', '\x88', '\x89', '\a', 'g', '\x2', '\x2', '\x89', '\x8A', '\a', 
		'v', '\x2', '\x2', '\x8A', '\"', '\x3', '\x2', '\x2', '\x2', '\x8B', '\x8C', 
		'\a', '<', '\x2', '\x2', '\x8C', '\x8D', '\a', '?', '\x2', '\x2', '\x8D', 
		'$', '\x3', '\x2', '\x2', '\x2', '\x8E', '\x8F', '\a', 'k', '\x2', '\x2', 
		'\x8F', '\x90', '\a', 'p', '\x2', '\x2', '\x90', '&', '\x3', '\x2', '\x2', 
		'\x2', '\x91', '\x92', '\a', '=', '\x2', '\x2', '\x92', '(', '\x3', '\x2', 
		'\x2', '\x2', '\x93', '\x95', '\t', '\x2', '\x2', '\x2', '\x94', '\x93', 
		'\x3', '\x2', '\x2', '\x2', '\x95', '\x96', '\x3', '\x2', '\x2', '\x2', 
		'\x96', '\x94', '\x3', '\x2', '\x2', '\x2', '\x96', '\x97', '\x3', '\x2', 
		'\x2', '\x2', '\x97', '\x98', '\x3', '\x2', '\x2', '\x2', '\x98', '\x99', 
		'\b', '\x15', '\x2', '\x2', '\x99', '*', '\x3', '\x2', '\x2', '\x2', '\x9A', 
		'\x9B', '\a', 'p', '\x2', '\x2', '\x9B', '\x9C', '\a', 'q', '\x2', '\x2', 
		'\x9C', '\x9D', '\a', 'v', '\x2', '\x2', '\x9D', ',', '\x3', '\x2', '\x2', 
		'\x2', '\x9E', '\x9F', '\a', '\x63', '\x2', '\x2', '\x9F', '\xA0', '\a', 
		'p', '\x2', '\x2', '\xA0', '\xA1', '\a', '\x66', '\x2', '\x2', '\xA1', 
		'.', '\x3', '\x2', '\x2', '\x2', '\xA2', '\xA3', '\a', 'q', '\x2', '\x2', 
		'\xA3', '\xA4', '\a', 't', '\x2', '\x2', '\xA4', '\x30', '\x3', '\x2', 
		'\x2', '\x2', '\xA5', '\xA6', '\a', 'z', '\x2', '\x2', '\xA6', '\xA7', 
		'\a', 'q', '\x2', '\x2', '\xA7', '\xA8', '\a', 't', '\x2', '\x2', '\xA8', 
		'\x32', '\x3', '\x2', '\x2', '\x2', '\xA9', '\xAA', '\a', 'k', '\x2', 
		'\x2', '\xAA', '\xAB', '\a', 'h', '\x2', '\x2', '\xAB', '\xAC', '\a', 
		'h', '\x2', '\x2', '\xAC', '\x34', '\x3', '\x2', '\x2', '\x2', '\xAD', 
		'\xAE', '\a', '@', '\x2', '\x2', '\xAE', '\xAF', '\a', '?', '\x2', '\x2', 
		'\xAF', '\x36', '\x3', '\x2', '\x2', '\x2', '\xB0', '\xB1', '\a', '>', 
		'\x2', '\x2', '\xB1', '\xB2', '\a', '?', '\x2', '\x2', '\xB2', '\x38', 
		'\x3', '\x2', '\x2', '\x2', '\xB3', '\xB4', '\a', '@', '\x2', '\x2', '\xB4', 
		':', '\x3', '\x2', '\x2', '\x2', '\xB5', '\xB6', '\a', '>', '\x2', '\x2', 
		'\xB6', '<', '\x3', '\x2', '\x2', '\x2', '\xB7', '\xB8', '\a', '?', '\x2', 
		'\x2', '\xB8', '>', '\x3', '\x2', '\x2', '\x2', '\xB9', '\xBA', '\a', 
		'#', '\x2', '\x2', '\xBA', '\xBB', '\a', '?', '\x2', '\x2', '\xBB', '@', 
		'\x3', '\x2', '\x2', '\x2', '\xBC', '\xBD', '\a', '\x80', '\x2', '\x2', 
		'\xBD', '\x42', '\x3', '\x2', '\x2', '\x2', '\xBE', '\xBF', '\a', '#', 
		'\x2', '\x2', '\xBF', '\xC0', '\a', '\x80', '\x2', '\x2', '\xC0', '\x44', 
		'\x3', '\x2', '\x2', '\x2', '\xC1', '\xC2', '\a', '/', '\x2', '\x2', '\xC2', 
		'\x46', '\x3', '\x2', '\x2', '\x2', '\xC3', '\xC4', '\a', '-', '\x2', 
		'\x2', '\xC4', 'H', '\x3', '\x2', '\x2', '\x2', '\xC5', '\xC6', '\a', 
		',', '\x2', '\x2', '\xC6', 'J', '\x3', '\x2', '\x2', '\x2', '\xC7', '\xC8', 
		'\a', '\x31', '\x2', '\x2', '\xC8', 'L', '\x3', '\x2', '\x2', '\x2', '\xC9', 
		'\xCA', '\a', '\'', '\x2', '\x2', '\xCA', 'N', '\x3', '\x2', '\x2', '\x2', 
		'\xCB', '\xCC', '\a', '-', '\x2', '\x2', '\xCC', '\xCD', '\a', '-', '\x2', 
		'\x2', '\xCD', 'P', '\x3', '\x2', '\x2', '\x2', '\xCE', '\xCF', '\a', 
		'/', '\x2', '\x2', '\xCF', '\xD0', '\a', '/', '\x2', '\x2', '\xD0', 'R', 
		'\x3', '\x2', '\x2', '\x2', '\xD1', '\xD2', '\a', '(', '\x2', '\x2', '\xD2', 
		'T', '\x3', '\x2', '\x2', '\x2', '\xD3', '\xD5', '\a', '/', '\x2', '\x2', 
		'\xD4', '\xD3', '\x3', '\x2', '\x2', '\x2', '\xD4', '\xD5', '\x3', '\x2', 
		'\x2', '\x2', '\xD5', '\xD7', '\x3', '\x2', '\x2', '\x2', '\xD6', '\xD8', 
		'\t', '\x3', '\x2', '\x2', '\xD7', '\xD6', '\x3', '\x2', '\x2', '\x2', 
		'\xD8', '\xD9', '\x3', '\x2', '\x2', '\x2', '\xD9', '\xD7', '\x3', '\x2', 
		'\x2', '\x2', '\xD9', '\xDA', '\x3', '\x2', '\x2', '\x2', '\xDA', 'V', 
		'\x3', '\x2', '\x2', '\x2', '\xDB', '\xDF', '\a', ')', '\x2', '\x2', '\xDC', 
		'\xDE', '\n', '\x4', '\x2', '\x2', '\xDD', '\xDC', '\x3', '\x2', '\x2', 
		'\x2', '\xDE', '\xE1', '\x3', '\x2', '\x2', '\x2', '\xDF', '\xDD', '\x3', 
		'\x2', '\x2', '\x2', '\xDF', '\xE0', '\x3', '\x2', '\x2', '\x2', '\xE0', 
		'\xE2', '\x3', '\x2', '\x2', '\x2', '\xE1', '\xDF', '\x3', '\x2', '\x2', 
		'\x2', '\xE2', '\xEC', '\a', ')', '\x2', '\x2', '\xE3', '\xE7', '\a', 
		'$', '\x2', '\x2', '\xE4', '\xE6', '\n', '\x5', '\x2', '\x2', '\xE5', 
		'\xE4', '\x3', '\x2', '\x2', '\x2', '\xE6', '\xE9', '\x3', '\x2', '\x2', 
		'\x2', '\xE7', '\xE5', '\x3', '\x2', '\x2', '\x2', '\xE7', '\xE8', '\x3', 
		'\x2', '\x2', '\x2', '\xE8', '\xEA', '\x3', '\x2', '\x2', '\x2', '\xE9', 
		'\xE7', '\x3', '\x2', '\x2', '\x2', '\xEA', '\xEC', '\a', '$', '\x2', 
		'\x2', '\xEB', '\xDB', '\x3', '\x2', '\x2', '\x2', '\xEB', '\xE3', '\x3', 
		'\x2', '\x2', '\x2', '\xEC', 'X', '\x3', '\x2', '\x2', '\x2', '\xED', 
		'\xEF', '\a', '\x31', '\x2', '\x2', '\xEE', '\xF0', '\n', '\x6', '\x2', 
		'\x2', '\xEF', '\xEE', '\x3', '\x2', '\x2', '\x2', '\xF0', '\xF1', '\x3', 
		'\x2', '\x2', '\x2', '\xF1', '\xEF', '\x3', '\x2', '\x2', '\x2', '\xF1', 
		'\xF2', '\x3', '\x2', '\x2', '\x2', '\xF2', '\xF3', '\x3', '\x2', '\x2', 
		'\x2', '\xF3', '\xFC', '\a', '\x31', '\x2', '\x2', '\xF4', '\xF6', '\a', 
		'#', '\x2', '\x2', '\xF5', '\xF7', '\n', '\a', '\x2', '\x2', '\xF6', '\xF5', 
		'\x3', '\x2', '\x2', '\x2', '\xF7', '\xF8', '\x3', '\x2', '\x2', '\x2', 
		'\xF8', '\xF6', '\x3', '\x2', '\x2', '\x2', '\xF8', '\xF9', '\x3', '\x2', 
		'\x2', '\x2', '\xF9', '\xFA', '\x3', '\x2', '\x2', '\x2', '\xFA', '\xFC', 
		'\a', '#', '\x2', '\x2', '\xFB', '\xED', '\x3', '\x2', '\x2', '\x2', '\xFB', 
		'\xF4', '\x3', '\x2', '\x2', '\x2', '\xFC', 'Z', '\x3', '\x2', '\x2', 
		'\x2', '\xFD', '\x101', '\t', '\b', '\x2', '\x2', '\xFE', '\x100', '\t', 
		'\t', '\x2', '\x2', '\xFF', '\xFE', '\x3', '\x2', '\x2', '\x2', '\x100', 
		'\x103', '\x3', '\x2', '\x2', '\x2', '\x101', '\xFF', '\x3', '\x2', '\x2', 
		'\x2', '\x101', '\x102', '\x3', '\x2', '\x2', '\x2', '\x102', '\\', '\x3', 
		'\x2', '\x2', '\x2', '\x103', '\x101', '\x3', '\x2', '\x2', '\x2', '\x104', 
		'\x105', '\x5', '[', '.', '\x2', '\x105', '^', '\x3', '\x2', '\x2', '\x2', 
		'\x106', '\x107', '\a', '&', '\x2', '\x2', '\x107', '\x108', '\x5', '[', 
		'.', '\x2', '\x108', '`', '\x3', '\x2', '\x2', '\x2', '\x109', '\x10B', 
		'\a', '\x62', '\x2', '\x2', '\x10A', '\x10C', '\n', '\n', '\x2', '\x2', 
		'\x10B', '\x10A', '\x3', '\x2', '\x2', '\x2', '\x10C', '\x10D', '\x3', 
		'\x2', '\x2', '\x2', '\x10D', '\x10B', '\x3', '\x2', '\x2', '\x2', '\x10D', 
		'\x10E', '\x3', '\x2', '\x2', '\x2', '\x10E', '\x10F', '\x3', '\x2', '\x2', 
		'\x2', '\x10F', '\x110', '\a', '\x62', '\x2', '\x2', '\x110', '\x62', 
		'\x3', '\x2', '\x2', '\x2', '\x111', '\x113', '\a', '/', '\x2', '\x2', 
		'\x112', '\x114', '\t', '\v', '\x2', '\x2', '\x113', '\x112', '\x3', '\x2', 
		'\x2', '\x2', '\x114', '\x115', '\x3', '\x2', '\x2', '\x2', '\x115', '\x113', 
		'\x3', '\x2', '\x2', '\x2', '\x115', '\x116', '\x3', '\x2', '\x2', '\x2', 
		'\x116', '\x64', '\x3', '\x2', '\x2', '\x2', '\xF', '\x2', '\x96', '\xD4', 
		'\xD9', '\xDF', '\xE7', '\xEB', '\xF1', '\xF8', '\xFB', '\x101', '\x10D', 
		'\x115', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace BuildXL.Execution.Analyzer.JPath
