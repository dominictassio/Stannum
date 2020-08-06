//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from .\StannumLexer.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Stannum.Grammar {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class StannumLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		BREAK=1, CONTINUE=2, ELSE=3, FOR=4, IF=5, MATCH=6, RETURN=7, STRUCT=8, 
		VAR=9, WHILE=10, IDENTIFIER_START=11, NUMBER=12, STRING=13, Ampersand_Ampersand=14, 
		Asterisk=15, Asterisk_EqualsSign=16, AtSign=17, Colon=18, Colon_EqualsSign=19, 
		Comma=20, EqualsSign=21, EqualsSign_EqualsSign=22, EqualsSign_GreaterThanSign=23, 
		ExclamationMark=24, ExclamationMark_EqualsSign=25, GreaterThanSign=26, 
		GreaterThanSign_EqualsSign=27, HyphenMinus=28, HyphenMinus_EqualsSign=29, 
		HyphenMinus_GreaterThanSign=30, LeftBrace=31, LeftBracket=32, LeftParen=33, 
		LessThanSign=34, LessThanSign_EqualsSign=35, PercentSign=36, PercentSign_EqualsSign=37, 
		Period=38, PlusSign=39, PlusSign_EqualsSign=40, PlusSign_PlusSign=41, 
		QuestionMark_Period=42, QuestionMark_QuestionMark=43, RightBrace=44, RightBracket=45, 
		RightParen=46, Semicolon=47, Slash=48, Slash_EqualsSign=49, VerticleLine_VerticleLine=50, 
		WS=51, COMMENT=52, IDENTIFIER_REST=53;
	public const int
		IDENTIFIER_MODE=1;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE", "IDENTIFIER_MODE"
	};

	public static readonly string[] ruleNames = {
		"BREAK", "CONTINUE", "ELSE", "FOR", "IF", "MATCH", "RETURN", "STRUCT", 
		"VAR", "WHILE", "IDENTIFIER_START", "NUMBER", "STRING", "STRCHAR", "ESCSEQ", 
		"Ampersand_Ampersand", "Asterisk", "Asterisk_EqualsSign", "AtSign", "Colon", 
		"Colon_EqualsSign", "Comma", "EqualsSign", "EqualsSign_EqualsSign", "EqualsSign_GreaterThanSign", 
		"ExclamationMark", "ExclamationMark_EqualsSign", "GreaterThanSign", "GreaterThanSign_EqualsSign", 
		"HyphenMinus", "HyphenMinus_EqualsSign", "HyphenMinus_GreaterThanSign", 
		"LeftBrace", "LeftBracket", "LeftParen", "LessThanSign", "LessThanSign_EqualsSign", 
		"PercentSign", "PercentSign_EqualsSign", "Period", "PlusSign", "PlusSign_EqualsSign", 
		"PlusSign_PlusSign", "QuestionMark_Period", "QuestionMark_QuestionMark", 
		"RightBrace", "RightBracket", "RightParen", "Semicolon", "Slash", "Slash_EqualsSign", 
		"VerticleLine_VerticleLine", "WS", "COMMENT", "IDENTIFIER_REST"
	};


	public StannumLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public StannumLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'break'", "'continue'", "'else'", "'for'", "'if'", "'match'", "'return'", 
		"'struct'", "'var'", "'while'", null, null, null, "'&&'", "'*'", "'*='", 
		"'@'", "':'", "':='", "','", "'='", "'=='", "'=>'", "'!'", "'!='", "'>'", 
		"'>='", "'-'", "'-='", "'->'", "'{'", "'['", "'('", "'<'", "'<='", "'%'", 
		"'%='", "'.'", "'+'", "'+='", "'++'", "'?.'", "'??'", "'}'", "']'", "')'", 
		"';'", "'/'", "'/='", "'||'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "BREAK", "CONTINUE", "ELSE", "FOR", "IF", "MATCH", "RETURN", "STRUCT", 
		"VAR", "WHILE", "IDENTIFIER_START", "NUMBER", "STRING", "Ampersand_Ampersand", 
		"Asterisk", "Asterisk_EqualsSign", "AtSign", "Colon", "Colon_EqualsSign", 
		"Comma", "EqualsSign", "EqualsSign_EqualsSign", "EqualsSign_GreaterThanSign", 
		"ExclamationMark", "ExclamationMark_EqualsSign", "GreaterThanSign", "GreaterThanSign_EqualsSign", 
		"HyphenMinus", "HyphenMinus_EqualsSign", "HyphenMinus_GreaterThanSign", 
		"LeftBrace", "LeftBracket", "LeftParen", "LessThanSign", "LessThanSign_EqualsSign", 
		"PercentSign", "PercentSign_EqualsSign", "Period", "PlusSign", "PlusSign_EqualsSign", 
		"PlusSign_PlusSign", "QuestionMark_Period", "QuestionMark_QuestionMark", 
		"RightBrace", "RightBracket", "RightParen", "Semicolon", "Slash", "Slash_EqualsSign", 
		"VerticleLine_VerticleLine", "WS", "COMMENT", "IDENTIFIER_REST"
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

	public override string GrammarFileName { get { return "StannumLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static StannumLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\x37', '\x14A', '\b', '\x1', '\b', '\x1', '\x4', '\x2', 
		'\t', '\x2', '\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', 
		'\x5', '\t', '\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', 
		'\x4', '\b', '\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', 
		'\x4', '\v', '\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', 
		'\x4', '\xE', '\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', 
		'\x10', '\x4', '\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', 
		'\x13', '\t', '\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', 
		'\x15', '\x4', '\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', 
		'\x18', '\t', '\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', 
		'\x1A', '\x4', '\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', 
		'\x1D', '\t', '\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', 
		'\x1F', '\x4', ' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', 
		'\"', '\x4', '#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', 
		'%', '\x4', '&', '\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', 
		'(', '\x4', ')', '\t', ')', '\x4', '*', '\t', '*', '\x4', '+', '\t', '+', 
		'\x4', ',', '\t', ',', '\x4', '-', '\t', '-', '\x4', '.', '\t', '.', '\x4', 
		'/', '\t', '/', '\x4', '\x30', '\t', '\x30', '\x4', '\x31', '\t', '\x31', 
		'\x4', '\x32', '\t', '\x32', '\x4', '\x33', '\t', '\x33', '\x4', '\x34', 
		'\t', '\x34', '\x4', '\x35', '\t', '\x35', '\x4', '\x36', '\t', '\x36', 
		'\x4', '\x37', '\t', '\x37', '\x4', '\x38', '\t', '\x38', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', 
		'\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', 
		'\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', 
		'\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\n', 
		'\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', '\x3', 
		'\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', 
		'\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\a', '\r', '\xB2', 
		'\n', '\r', '\f', '\r', '\xE', '\r', '\xB5', '\v', '\r', '\x3', '\r', 
		'\x3', '\r', '\x3', '\r', '\a', '\r', '\xBA', '\n', '\r', '\f', '\r', 
		'\xE', '\r', '\xBD', '\v', '\r', '\x5', '\r', '\xBF', '\n', '\r', '\x3', 
		'\xE', '\x3', '\xE', '\a', '\xE', '\xC3', '\n', '\xE', '\f', '\xE', '\xE', 
		'\xE', '\xC6', '\v', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x5', '\xF', '\xCD', '\n', '\xF', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', 
		'\x10', '\x5', '\x10', '\xD5', '\n', '\x10', '\x3', '\x11', '\x3', '\x11', 
		'\x3', '\x11', '\x3', '\x12', '\x3', '\x12', '\x3', '\x13', '\x3', '\x13', 
		'\x3', '\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', 
		'\x3', '\x15', '\x3', '\x15', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', 
		'\x3', '\x17', '\x3', '\x17', '\x3', '\x18', '\x3', '\x18', '\x3', '\x19', 
		'\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', 
		'\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', 
		'\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', 
		'\x3', '\x1F', '\x3', '\x1F', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', 
		'!', '\x3', '!', '\x3', '!', '\x3', '\"', '\x3', '\"', '\x3', '#', '\x3', 
		'#', '\x3', '$', '\x3', '$', '\x3', '%', '\x3', '%', '\x3', '&', '\x3', 
		'&', '\x3', '&', '\x3', '\'', '\x3', '\'', '\x3', '(', '\x3', '(', '\x3', 
		'(', '\x3', ')', '\x3', ')', '\x3', '*', '\x3', '*', '\x3', '+', '\x3', 
		'+', '\x3', '+', '\x3', ',', '\x3', ',', '\x3', ',', '\x3', '-', '\x3', 
		'-', '\x3', '-', '\x3', '.', '\x3', '.', '\x3', '.', '\x3', '/', '\x3', 
		'/', '\x3', '\x30', '\x3', '\x30', '\x3', '\x31', '\x3', '\x31', '\x3', 
		'\x32', '\x3', '\x32', '\x3', '\x33', '\x3', '\x33', '\x3', '\x34', '\x3', 
		'\x34', '\x3', '\x34', '\x3', '\x35', '\x3', '\x35', '\x3', '\x35', '\x3', 
		'\x36', '\x6', '\x36', '\x135', '\n', '\x36', '\r', '\x36', '\xE', '\x36', 
		'\x136', '\x3', '\x36', '\x3', '\x36', '\x3', '\x37', '\x3', '\x37', '\a', 
		'\x37', '\x13D', '\n', '\x37', '\f', '\x37', '\xE', '\x37', '\x140', '\v', 
		'\x37', '\x3', '\x37', '\x3', '\x37', '\x3', '\x38', '\x6', '\x38', '\x145', 
		'\n', '\x38', '\r', '\x38', '\xE', '\x38', '\x146', '\x3', '\x38', '\x3', 
		'\x38', '\x2', '\x2', '\x39', '\x4', '\x3', '\x6', '\x4', '\b', '\x5', 
		'\n', '\x6', '\f', '\a', '\xE', '\b', '\x10', '\t', '\x12', '\n', '\x14', 
		'\v', '\x16', '\f', '\x18', '\r', '\x1A', '\xE', '\x1C', '\xF', '\x1E', 
		'\x2', ' ', '\x2', '\"', '\x10', '$', '\x11', '&', '\x12', '(', '\x13', 
		'*', '\x14', ',', '\x15', '.', '\x16', '\x30', '\x17', '\x32', '\x18', 
		'\x34', '\x19', '\x36', '\x1A', '\x38', '\x1B', ':', '\x1C', '<', '\x1D', 
		'>', '\x1E', '@', '\x1F', '\x42', ' ', '\x44', '!', '\x46', '\"', 'H', 
		'#', 'J', '$', 'L', '%', 'N', '&', 'P', '\'', 'R', '(', 'T', ')', 'V', 
		'*', 'X', '+', 'Z', ',', '\\', '-', '^', '.', '`', '/', '\x62', '\x30', 
		'\x64', '\x31', '\x66', '\x32', 'h', '\x33', 'j', '\x34', 'l', '\x35', 
		'n', '\x36', 'p', '\x37', '\x4', '\x2', '\x3', '\v', '\x5', '\x2', '\x43', 
		'\\', '\x61', '\x61', '\x63', '|', '\x3', '\x2', '\x32', ';', '\x4', '\x2', 
		'\x32', ';', '\x61', '\x61', '\x6', '\x2', '\f', '\f', '\xF', '\xF', '$', 
		'$', '^', '^', '\f', '\x2', '$', '$', ')', ')', '\x32', '\x32', '^', '^', 
		'\x63', '\x64', 'h', 'h', 'p', 'p', 't', 't', 'v', 'v', 'x', 'x', '\x5', 
		'\x2', '\x32', ';', '\x43', 'H', '\x63', 'h', '\x5', '\x2', '\v', '\f', 
		'\xF', '\xF', '\"', '\"', '\x4', '\x2', '\f', '\f', '\xE', '\xF', '\b', 
		'\x2', '\v', '\v', '\"', '\"', '\x32', ';', '\x43', '\\', '\x61', '\x61', 
		'\x63', '|', '\x2', '\x14F', '\x2', '\x4', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x6', '\x3', '\x2', '\x2', '\x2', '\x2', '\b', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\n', '\x3', '\x2', '\x2', '\x2', '\x2', '\f', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\xE', '\x3', '\x2', '\x2', '\x2', '\x2', '\x10', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x12', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x14', '\x3', '\x2', '\x2', '\x2', '\x2', '\x16', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x18', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1A', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x1C', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\"', '\x3', '\x2', '\x2', '\x2', '\x2', '$', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '&', '\x3', '\x2', '\x2', '\x2', '\x2', '(', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '*', '\x3', '\x2', '\x2', '\x2', '\x2', ',', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '.', '\x3', '\x2', '\x2', '\x2', '\x2', '\x30', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x32', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x34', '\x3', '\x2', '\x2', '\x2', '\x2', '\x36', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x38', '\x3', '\x2', '\x2', '\x2', '\x2', ':', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '<', '\x3', '\x2', '\x2', '\x2', '\x2', '>', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '@', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x42', '\x3', '\x2', '\x2', '\x2', '\x2', '\x44', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x46', '\x3', '\x2', '\x2', '\x2', '\x2', 'H', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'J', '\x3', '\x2', '\x2', '\x2', '\x2', 'L', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'N', '\x3', '\x2', '\x2', '\x2', '\x2', 'P', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'R', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'T', '\x3', '\x2', '\x2', '\x2', '\x2', 'V', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'X', '\x3', '\x2', '\x2', '\x2', '\x2', 'Z', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\\', '\x3', '\x2', '\x2', '\x2', '\x2', '^', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '`', '\x3', '\x2', '\x2', '\x2', '\x2', '\x62', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x64', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x66', '\x3', '\x2', '\x2', '\x2', '\x2', 'h', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'j', '\x3', '\x2', '\x2', '\x2', '\x2', 'l', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'n', '\x3', '\x2', '\x2', '\x2', '\x3', 'p', '\x3', '\x2', 
		'\x2', '\x2', '\x4', 'r', '\x3', '\x2', '\x2', '\x2', '\x6', 'x', '\x3', 
		'\x2', '\x2', '\x2', '\b', '\x81', '\x3', '\x2', '\x2', '\x2', '\n', '\x86', 
		'\x3', '\x2', '\x2', '\x2', '\f', '\x8A', '\x3', '\x2', '\x2', '\x2', 
		'\xE', '\x8D', '\x3', '\x2', '\x2', '\x2', '\x10', '\x93', '\x3', '\x2', 
		'\x2', '\x2', '\x12', '\x9A', '\x3', '\x2', '\x2', '\x2', '\x14', '\xA1', 
		'\x3', '\x2', '\x2', '\x2', '\x16', '\xA5', '\x3', '\x2', '\x2', '\x2', 
		'\x18', '\xAB', '\x3', '\x2', '\x2', '\x2', '\x1A', '\xAF', '\x3', '\x2', 
		'\x2', '\x2', '\x1C', '\xC0', '\x3', '\x2', '\x2', '\x2', '\x1E', '\xCC', 
		'\x3', '\x2', '\x2', '\x2', ' ', '\xD4', '\x3', '\x2', '\x2', '\x2', '\"', 
		'\xD6', '\x3', '\x2', '\x2', '\x2', '$', '\xD9', '\x3', '\x2', '\x2', 
		'\x2', '&', '\xDB', '\x3', '\x2', '\x2', '\x2', '(', '\xDE', '\x3', '\x2', 
		'\x2', '\x2', '*', '\xE2', '\x3', '\x2', '\x2', '\x2', ',', '\xE4', '\x3', 
		'\x2', '\x2', '\x2', '.', '\xE7', '\x3', '\x2', '\x2', '\x2', '\x30', 
		'\xE9', '\x3', '\x2', '\x2', '\x2', '\x32', '\xEB', '\x3', '\x2', '\x2', 
		'\x2', '\x34', '\xEE', '\x3', '\x2', '\x2', '\x2', '\x36', '\xF1', '\x3', 
		'\x2', '\x2', '\x2', '\x38', '\xF3', '\x3', '\x2', '\x2', '\x2', ':', 
		'\xF6', '\x3', '\x2', '\x2', '\x2', '<', '\xF8', '\x3', '\x2', '\x2', 
		'\x2', '>', '\xFB', '\x3', '\x2', '\x2', '\x2', '@', '\xFD', '\x3', '\x2', 
		'\x2', '\x2', '\x42', '\x100', '\x3', '\x2', '\x2', '\x2', '\x44', '\x103', 
		'\x3', '\x2', '\x2', '\x2', '\x46', '\x105', '\x3', '\x2', '\x2', '\x2', 
		'H', '\x107', '\x3', '\x2', '\x2', '\x2', 'J', '\x109', '\x3', '\x2', 
		'\x2', '\x2', 'L', '\x10B', '\x3', '\x2', '\x2', '\x2', 'N', '\x10E', 
		'\x3', '\x2', '\x2', '\x2', 'P', '\x110', '\x3', '\x2', '\x2', '\x2', 
		'R', '\x113', '\x3', '\x2', '\x2', '\x2', 'T', '\x115', '\x3', '\x2', 
		'\x2', '\x2', 'V', '\x117', '\x3', '\x2', '\x2', '\x2', 'X', '\x11A', 
		'\x3', '\x2', '\x2', '\x2', 'Z', '\x11D', '\x3', '\x2', '\x2', '\x2', 
		'\\', '\x120', '\x3', '\x2', '\x2', '\x2', '^', '\x123', '\x3', '\x2', 
		'\x2', '\x2', '`', '\x125', '\x3', '\x2', '\x2', '\x2', '\x62', '\x127', 
		'\x3', '\x2', '\x2', '\x2', '\x64', '\x129', '\x3', '\x2', '\x2', '\x2', 
		'\x66', '\x12B', '\x3', '\x2', '\x2', '\x2', 'h', '\x12D', '\x3', '\x2', 
		'\x2', '\x2', 'j', '\x130', '\x3', '\x2', '\x2', '\x2', 'l', '\x134', 
		'\x3', '\x2', '\x2', '\x2', 'n', '\x13A', '\x3', '\x2', '\x2', '\x2', 
		'p', '\x144', '\x3', '\x2', '\x2', '\x2', 'r', 's', '\a', '\x64', '\x2', 
		'\x2', 's', 't', '\a', 't', '\x2', '\x2', 't', 'u', '\a', 'g', '\x2', 
		'\x2', 'u', 'v', '\a', '\x63', '\x2', '\x2', 'v', 'w', '\a', 'm', '\x2', 
		'\x2', 'w', '\x5', '\x3', '\x2', '\x2', '\x2', 'x', 'y', '\a', '\x65', 
		'\x2', '\x2', 'y', 'z', '\a', 'q', '\x2', '\x2', 'z', '{', '\a', 'p', 
		'\x2', '\x2', '{', '|', '\a', 'v', '\x2', '\x2', '|', '}', '\a', 'k', 
		'\x2', '\x2', '}', '~', '\a', 'p', '\x2', '\x2', '~', '\x7F', '\a', 'w', 
		'\x2', '\x2', '\x7F', '\x80', '\a', 'g', '\x2', '\x2', '\x80', '\a', '\x3', 
		'\x2', '\x2', '\x2', '\x81', '\x82', '\a', 'g', '\x2', '\x2', '\x82', 
		'\x83', '\a', 'n', '\x2', '\x2', '\x83', '\x84', '\a', 'u', '\x2', '\x2', 
		'\x84', '\x85', '\a', 'g', '\x2', '\x2', '\x85', '\t', '\x3', '\x2', '\x2', 
		'\x2', '\x86', '\x87', '\a', 'h', '\x2', '\x2', '\x87', '\x88', '\a', 
		'q', '\x2', '\x2', '\x88', '\x89', '\a', 't', '\x2', '\x2', '\x89', '\v', 
		'\x3', '\x2', '\x2', '\x2', '\x8A', '\x8B', '\a', 'k', '\x2', '\x2', '\x8B', 
		'\x8C', '\a', 'h', '\x2', '\x2', '\x8C', '\r', '\x3', '\x2', '\x2', '\x2', 
		'\x8D', '\x8E', '\a', 'o', '\x2', '\x2', '\x8E', '\x8F', '\a', '\x63', 
		'\x2', '\x2', '\x8F', '\x90', '\a', 'v', '\x2', '\x2', '\x90', '\x91', 
		'\a', '\x65', '\x2', '\x2', '\x91', '\x92', '\a', 'j', '\x2', '\x2', '\x92', 
		'\xF', '\x3', '\x2', '\x2', '\x2', '\x93', '\x94', '\a', 't', '\x2', '\x2', 
		'\x94', '\x95', '\a', 'g', '\x2', '\x2', '\x95', '\x96', '\a', 'v', '\x2', 
		'\x2', '\x96', '\x97', '\a', 'w', '\x2', '\x2', '\x97', '\x98', '\a', 
		't', '\x2', '\x2', '\x98', '\x99', '\a', 'p', '\x2', '\x2', '\x99', '\x11', 
		'\x3', '\x2', '\x2', '\x2', '\x9A', '\x9B', '\a', 'u', '\x2', '\x2', '\x9B', 
		'\x9C', '\a', 'v', '\x2', '\x2', '\x9C', '\x9D', '\a', 't', '\x2', '\x2', 
		'\x9D', '\x9E', '\a', 'w', '\x2', '\x2', '\x9E', '\x9F', '\a', '\x65', 
		'\x2', '\x2', '\x9F', '\xA0', '\a', 'v', '\x2', '\x2', '\xA0', '\x13', 
		'\x3', '\x2', '\x2', '\x2', '\xA1', '\xA2', '\a', 'x', '\x2', '\x2', '\xA2', 
		'\xA3', '\a', '\x63', '\x2', '\x2', '\xA3', '\xA4', '\a', 't', '\x2', 
		'\x2', '\xA4', '\x15', '\x3', '\x2', '\x2', '\x2', '\xA5', '\xA6', '\a', 
		'y', '\x2', '\x2', '\xA6', '\xA7', '\a', 'j', '\x2', '\x2', '\xA7', '\xA8', 
		'\a', 'k', '\x2', '\x2', '\xA8', '\xA9', '\a', 'n', '\x2', '\x2', '\xA9', 
		'\xAA', '\a', 'g', '\x2', '\x2', '\xAA', '\x17', '\x3', '\x2', '\x2', 
		'\x2', '\xAB', '\xAC', '\t', '\x2', '\x2', '\x2', '\xAC', '\xAD', '\x3', 
		'\x2', '\x2', '\x2', '\xAD', '\xAE', '\b', '\f', '\x2', '\x2', '\xAE', 
		'\x19', '\x3', '\x2', '\x2', '\x2', '\xAF', '\xB3', '\t', '\x3', '\x2', 
		'\x2', '\xB0', '\xB2', '\t', '\x4', '\x2', '\x2', '\xB1', '\xB0', '\x3', 
		'\x2', '\x2', '\x2', '\xB2', '\xB5', '\x3', '\x2', '\x2', '\x2', '\xB3', 
		'\xB1', '\x3', '\x2', '\x2', '\x2', '\xB3', '\xB4', '\x3', '\x2', '\x2', 
		'\x2', '\xB4', '\xBE', '\x3', '\x2', '\x2', '\x2', '\xB5', '\xB3', '\x3', 
		'\x2', '\x2', '\x2', '\xB6', '\xB7', '\a', '\x30', '\x2', '\x2', '\xB7', 
		'\xBB', '\t', '\x3', '\x2', '\x2', '\xB8', '\xBA', '\t', '\x4', '\x2', 
		'\x2', '\xB9', '\xB8', '\x3', '\x2', '\x2', '\x2', '\xBA', '\xBD', '\x3', 
		'\x2', '\x2', '\x2', '\xBB', '\xB9', '\x3', '\x2', '\x2', '\x2', '\xBB', 
		'\xBC', '\x3', '\x2', '\x2', '\x2', '\xBC', '\xBF', '\x3', '\x2', '\x2', 
		'\x2', '\xBD', '\xBB', '\x3', '\x2', '\x2', '\x2', '\xBE', '\xB6', '\x3', 
		'\x2', '\x2', '\x2', '\xBE', '\xBF', '\x3', '\x2', '\x2', '\x2', '\xBF', 
		'\x1B', '\x3', '\x2', '\x2', '\x2', '\xC0', '\xC4', '\a', '$', '\x2', 
		'\x2', '\xC1', '\xC3', '\x5', '\x1E', '\xF', '\x2', '\xC2', '\xC1', '\x3', 
		'\x2', '\x2', '\x2', '\xC3', '\xC6', '\x3', '\x2', '\x2', '\x2', '\xC4', 
		'\xC2', '\x3', '\x2', '\x2', '\x2', '\xC4', '\xC5', '\x3', '\x2', '\x2', 
		'\x2', '\xC5', '\xC7', '\x3', '\x2', '\x2', '\x2', '\xC6', '\xC4', '\x3', 
		'\x2', '\x2', '\x2', '\xC7', '\xC8', '\a', '$', '\x2', '\x2', '\xC8', 
		'\x1D', '\x3', '\x2', '\x2', '\x2', '\xC9', '\xCD', '\n', '\x5', '\x2', 
		'\x2', '\xCA', '\xCB', '\a', '^', '\x2', '\x2', '\xCB', '\xCD', '\x5', 
		' ', '\x10', '\x2', '\xCC', '\xC9', '\x3', '\x2', '\x2', '\x2', '\xCC', 
		'\xCA', '\x3', '\x2', '\x2', '\x2', '\xCD', '\x1F', '\x3', '\x2', '\x2', 
		'\x2', '\xCE', '\xD5', '\t', '\x6', '\x2', '\x2', '\xCF', '\xD0', '\a', 
		'w', '\x2', '\x2', '\xD0', '\xD1', '\t', '\a', '\x2', '\x2', '\xD1', '\xD2', 
		'\t', '\a', '\x2', '\x2', '\xD2', '\xD3', '\t', '\a', '\x2', '\x2', '\xD3', 
		'\xD5', '\t', '\a', '\x2', '\x2', '\xD4', '\xCE', '\x3', '\x2', '\x2', 
		'\x2', '\xD4', '\xCF', '\x3', '\x2', '\x2', '\x2', '\xD5', '!', '\x3', 
		'\x2', '\x2', '\x2', '\xD6', '\xD7', '\a', '(', '\x2', '\x2', '\xD7', 
		'\xD8', '\a', '(', '\x2', '\x2', '\xD8', '#', '\x3', '\x2', '\x2', '\x2', 
		'\xD9', '\xDA', '\a', ',', '\x2', '\x2', '\xDA', '%', '\x3', '\x2', '\x2', 
		'\x2', '\xDB', '\xDC', '\a', ',', '\x2', '\x2', '\xDC', '\xDD', '\a', 
		'?', '\x2', '\x2', '\xDD', '\'', '\x3', '\x2', '\x2', '\x2', '\xDE', '\xDF', 
		'\a', '\x42', '\x2', '\x2', '\xDF', '\xE0', '\x3', '\x2', '\x2', '\x2', 
		'\xE0', '\xE1', '\b', '\x14', '\x2', '\x2', '\xE1', ')', '\x3', '\x2', 
		'\x2', '\x2', '\xE2', '\xE3', '\a', '<', '\x2', '\x2', '\xE3', '+', '\x3', 
		'\x2', '\x2', '\x2', '\xE4', '\xE5', '\a', '<', '\x2', '\x2', '\xE5', 
		'\xE6', '\a', '?', '\x2', '\x2', '\xE6', '-', '\x3', '\x2', '\x2', '\x2', 
		'\xE7', '\xE8', '\a', '.', '\x2', '\x2', '\xE8', '/', '\x3', '\x2', '\x2', 
		'\x2', '\xE9', '\xEA', '\a', '?', '\x2', '\x2', '\xEA', '\x31', '\x3', 
		'\x2', '\x2', '\x2', '\xEB', '\xEC', '\a', '?', '\x2', '\x2', '\xEC', 
		'\xED', '\a', '?', '\x2', '\x2', '\xED', '\x33', '\x3', '\x2', '\x2', 
		'\x2', '\xEE', '\xEF', '\a', '?', '\x2', '\x2', '\xEF', '\xF0', '\a', 
		'@', '\x2', '\x2', '\xF0', '\x35', '\x3', '\x2', '\x2', '\x2', '\xF1', 
		'\xF2', '\a', '#', '\x2', '\x2', '\xF2', '\x37', '\x3', '\x2', '\x2', 
		'\x2', '\xF3', '\xF4', '\a', '#', '\x2', '\x2', '\xF4', '\xF5', '\a', 
		'?', '\x2', '\x2', '\xF5', '\x39', '\x3', '\x2', '\x2', '\x2', '\xF6', 
		'\xF7', '\a', '@', '\x2', '\x2', '\xF7', ';', '\x3', '\x2', '\x2', '\x2', 
		'\xF8', '\xF9', '\a', '@', '\x2', '\x2', '\xF9', '\xFA', '\a', '?', '\x2', 
		'\x2', '\xFA', '=', '\x3', '\x2', '\x2', '\x2', '\xFB', '\xFC', '\a', 
		'/', '\x2', '\x2', '\xFC', '?', '\x3', '\x2', '\x2', '\x2', '\xFD', '\xFE', 
		'\a', '/', '\x2', '\x2', '\xFE', '\xFF', '\a', '?', '\x2', '\x2', '\xFF', 
		'\x41', '\x3', '\x2', '\x2', '\x2', '\x100', '\x101', '\a', '/', '\x2', 
		'\x2', '\x101', '\x102', '\a', '@', '\x2', '\x2', '\x102', '\x43', '\x3', 
		'\x2', '\x2', '\x2', '\x103', '\x104', '\a', '}', '\x2', '\x2', '\x104', 
		'\x45', '\x3', '\x2', '\x2', '\x2', '\x105', '\x106', '\a', ']', '\x2', 
		'\x2', '\x106', 'G', '\x3', '\x2', '\x2', '\x2', '\x107', '\x108', '\a', 
		'*', '\x2', '\x2', '\x108', 'I', '\x3', '\x2', '\x2', '\x2', '\x109', 
		'\x10A', '\a', '>', '\x2', '\x2', '\x10A', 'K', '\x3', '\x2', '\x2', '\x2', 
		'\x10B', '\x10C', '\a', '>', '\x2', '\x2', '\x10C', '\x10D', '\a', '?', 
		'\x2', '\x2', '\x10D', 'M', '\x3', '\x2', '\x2', '\x2', '\x10E', '\x10F', 
		'\a', '\'', '\x2', '\x2', '\x10F', 'O', '\x3', '\x2', '\x2', '\x2', '\x110', 
		'\x111', '\a', '\'', '\x2', '\x2', '\x111', '\x112', '\a', '?', '\x2', 
		'\x2', '\x112', 'Q', '\x3', '\x2', '\x2', '\x2', '\x113', '\x114', '\a', 
		'\x30', '\x2', '\x2', '\x114', 'S', '\x3', '\x2', '\x2', '\x2', '\x115', 
		'\x116', '\a', '-', '\x2', '\x2', '\x116', 'U', '\x3', '\x2', '\x2', '\x2', 
		'\x117', '\x118', '\a', '-', '\x2', '\x2', '\x118', '\x119', '\a', '?', 
		'\x2', '\x2', '\x119', 'W', '\x3', '\x2', '\x2', '\x2', '\x11A', '\x11B', 
		'\a', '-', '\x2', '\x2', '\x11B', '\x11C', '\a', '-', '\x2', '\x2', '\x11C', 
		'Y', '\x3', '\x2', '\x2', '\x2', '\x11D', '\x11E', '\a', '\x41', '\x2', 
		'\x2', '\x11E', '\x11F', '\a', '\x30', '\x2', '\x2', '\x11F', '[', '\x3', 
		'\x2', '\x2', '\x2', '\x120', '\x121', '\a', '\x41', '\x2', '\x2', '\x121', 
		'\x122', '\a', '\x41', '\x2', '\x2', '\x122', ']', '\x3', '\x2', '\x2', 
		'\x2', '\x123', '\x124', '\a', '\x7F', '\x2', '\x2', '\x124', '_', '\x3', 
		'\x2', '\x2', '\x2', '\x125', '\x126', '\a', '_', '\x2', '\x2', '\x126', 
		'\x61', '\x3', '\x2', '\x2', '\x2', '\x127', '\x128', '\a', '+', '\x2', 
		'\x2', '\x128', '\x63', '\x3', '\x2', '\x2', '\x2', '\x129', '\x12A', 
		'\a', '=', '\x2', '\x2', '\x12A', '\x65', '\x3', '\x2', '\x2', '\x2', 
		'\x12B', '\x12C', '\a', '\x31', '\x2', '\x2', '\x12C', 'g', '\x3', '\x2', 
		'\x2', '\x2', '\x12D', '\x12E', '\a', '\x31', '\x2', '\x2', '\x12E', '\x12F', 
		'\a', '?', '\x2', '\x2', '\x12F', 'i', '\x3', '\x2', '\x2', '\x2', '\x130', 
		'\x131', '\a', '~', '\x2', '\x2', '\x131', '\x132', '\a', '~', '\x2', 
		'\x2', '\x132', 'k', '\x3', '\x2', '\x2', '\x2', '\x133', '\x135', '\t', 
		'\b', '\x2', '\x2', '\x134', '\x133', '\x3', '\x2', '\x2', '\x2', '\x135', 
		'\x136', '\x3', '\x2', '\x2', '\x2', '\x136', '\x134', '\x3', '\x2', '\x2', 
		'\x2', '\x136', '\x137', '\x3', '\x2', '\x2', '\x2', '\x137', '\x138', 
		'\x3', '\x2', '\x2', '\x2', '\x138', '\x139', '\b', '\x36', '\x3', '\x2', 
		'\x139', 'm', '\x3', '\x2', '\x2', '\x2', '\x13A', '\x13E', '\a', '%', 
		'\x2', '\x2', '\x13B', '\x13D', '\n', '\t', '\x2', '\x2', '\x13C', '\x13B', 
		'\x3', '\x2', '\x2', '\x2', '\x13D', '\x140', '\x3', '\x2', '\x2', '\x2', 
		'\x13E', '\x13C', '\x3', '\x2', '\x2', '\x2', '\x13E', '\x13F', '\x3', 
		'\x2', '\x2', '\x2', '\x13F', '\x141', '\x3', '\x2', '\x2', '\x2', '\x140', 
		'\x13E', '\x3', '\x2', '\x2', '\x2', '\x141', '\x142', '\b', '\x37', '\x3', 
		'\x2', '\x142', 'o', '\x3', '\x2', '\x2', '\x2', '\x143', '\x145', '\t', 
		'\n', '\x2', '\x2', '\x144', '\x143', '\x3', '\x2', '\x2', '\x2', '\x145', 
		'\x146', '\x3', '\x2', '\x2', '\x2', '\x146', '\x144', '\x3', '\x2', '\x2', 
		'\x2', '\x146', '\x147', '\x3', '\x2', '\x2', '\x2', '\x147', '\x148', 
		'\x3', '\x2', '\x2', '\x2', '\x148', '\x149', '\b', '\x38', '\x4', '\x2', 
		'\x149', 'q', '\x3', '\x2', '\x2', '\x2', '\r', '\x2', '\x3', '\xB3', 
		'\xBB', '\xBE', '\xC4', '\xCC', '\xD4', '\x136', '\x13E', '\x146', '\x5', 
		'\a', '\x3', '\x2', '\b', '\x2', '\x2', '\x6', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace Stannum.Grammar
