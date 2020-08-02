grammar Stannum;

program: statements+=statement* EOF;


//
// Statements
//

statement
    : definition
    | exprStmt
    | forStmt
    | ifStmt
    | whileStmt
    | block;

definition
    : Name=identifier '=' Value=expression ';'
    | Name=identifier '=' ValueWithoutSemi=primaryWithBlock;

exprStmt: Value=expression ';';

forStmt: (Label=identifier ':')? FOR Value=expression '->' Variable=identifier Body=block;

ifStmt: IF Condition=expression Consequent=block (ELSE (Alternative=block | AlternativeIf=ifStmt))?;

whileStmt: (Label=identifier ':')? WHILE Value=expression Body=block;

block: '{' Statements+=statement '}';


//
// Expressions
//

expression: sequence;

sequence
    : Right=assignment
    | Left=sequence ';' Right=assignment;

assignment: Left=access_ Op=(':='|'+='|'-='|'*='|'/='|'%=') Right=expression;

coalesce
    : Left=logicalOr
    | Left=logicalOr '??' Right=coalesce;

logicalOr
    : Right=logicalAnd
    | Left=logicalOr '||' Right=logicalAnd;

logicalAnd
    : Right=equality
    | Left=logicalAnd '&&' Right=equality;

equality
    : Right=relational
    | Left=equality Op=('=='|'!=') Right=relational;

relational
    : Right=additive
    | Left=relational Op=('<'|'>'|'<='|'>=') Right=additive;

additive
    : Right=multiplicative
    | Left=additive Op=('+'|'-') Right=multiplicative;

multiplicative
    : Right=unary_
    | Left=multiplicative Op=('*'|'/'|'%') Right=unary_;

unary_
    : call_ # UnarySkip
    | Op=('!'|'-') Operand=unary_ # Unary;
    
call_
    : primary # CallSkip
    | call_ '(' (Args+=expression ',')* Args+=expression? ')' # Call;

primary
    : access_
    | blockExpr
    | breakExpr
    | continueExpr
    | grouped
    | ifExpr
    | lambdaWithBlock
    | lambdaWithExpr
    | literal
    | returnExpr;
    
primaryWithBlock
    : blockExpr
    | ifExpr
    | lambdaWithBlock;
    
access_
    : identifier # AccessSkip
    | access_ '.' identifier # Access;

blockExpr: '{' Statements+=statement* Value=expression '}';

breakExpr: BREAK Label=identifier?;

continueExpr: CONTINUE Label=identifier?;

grouped: '(' Value=expression ')';

identifier
    : IDENTIFIER keyword*
    | '$' keyword+;

ifExpr: IF Condition=expression Consequent=blockExpr ELSE (Alternative=blockExpr | AlternativeIf=ifExpr);

lambdaWithBlock: '(' (Params+=identifier ',')* Params+=identifier? ')' Body=block;

lambdaWithExpr: '(' (Params+=identifier ',')* Params+=identifier? ')' '=>' Value=expression;

literal
    : NUMBER
    | STRING
    | list
    | record;
    
list: '[' (Elements+=expression)* Elements+=expression? ']';

record: '{' Members+=recordMember (',' Members+=recordMember)* ','? '}';

recordMember: Name=identifier '=' Value=expression;

returnExpr: RETURN value=expression?;


//
// Lexical Tokens
//

keyword: IDENTIFIER | BREAK | CONTINUE | ELSE | FOR | IF | MATCH | RETURN | STRUCT | VAR | WHILE;

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

IDENTIFIER: [a-zA-Z_] [a-zA-Z0-9_]*;
    
NUMBER: [0-9] [0-9_]* ('.' [0-9] [0-9_]*)?;

STRING: '"' STRCHAR '"';

fragment STRCHAR
    : ~["\\\r\n]
    | '\\' ESCSEQ;

fragment ESCSEQ
    : ['"\\0abfnrtv]
    | 'u' [a-fA-F0-9] [a-fA-F0-9] [a-fA-F0-9] [a-fA-F0-9];

WS: [ \n\r\t]+ -> skip;