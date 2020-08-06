lexer grammar StannumLexer;

BREAK: 'break';
CONTINUE: 'continue';
ELSE: 'else';
FOR: 'for';
IF: 'if';
MATCH: 'match';
RETURN: 'return';
STRUCT: 'struct';
VAR: 'var';
WHILE: 'while';

IDENTIFIER_START: [a-zA-Z_] -> pushMode(IDENTIFIER_MODE);
    
NUMBER: [0-9] [0-9_]* ('.' [0-9] [0-9_]*)?;

STRING: '"' STRCHAR* '"';

fragment STRCHAR
    : ~["\\\r\n]
    | '\\' ESCSEQ;

fragment ESCSEQ
    : ['"\\0abfnrtv]
    | 'u' [a-fA-F0-9] [a-fA-F0-9] [a-fA-F0-9] [a-fA-F0-9];

Ampersand_Ampersand: '&&';
Asterisk: '*';
Asterisk_EqualsSign: '*=';
AtSign: '@' -> pushMode(IDENTIFIER_MODE);
Colon: ':';
Colon_EqualsSign: ':=';
Comma: ',';
EqualsSign: '=';
EqualsSign_EqualsSign: '==';
EqualsSign_GreaterThanSign: '=>';
ExclamationMark: '!';
ExclamationMark_EqualsSign: '!=';
GreaterThanSign: '>';
GreaterThanSign_EqualsSign: '>=';
HyphenMinus: '-';
HyphenMinus_EqualsSign: '-=';
HyphenMinus_GreaterThanSign: '->';
LeftBrace: '{';
LeftBracket: '[';
LeftParen: '(';
LessThanSign: '<';
LessThanSign_EqualsSign: '<=';
PercentSign: '%';
PercentSign_EqualsSign: '%=';
Period: '.';
PlusSign: '+';
PlusSign_EqualsSign: '+=';
PlusSign_PlusSign: '++';
QuestionMark_Period: '?.';
QuestionMark_QuestionMark: '??';
RightBrace: '}';
RightBracket: ']';
RightParen: ')';
Semicolon: ';';
Slash: '/';
Slash_EqualsSign: '/=';
VerticleLine_VerticleLine: '||';

WS: [ \n\r\t]+ -> skip;
COMMENT: '#' ~[\r\n\f]* -> skip;


mode IDENTIFIER_MODE;

IDENTIFIER_REST: [a-zA-Z0-9_ \t]+ -> popMode;