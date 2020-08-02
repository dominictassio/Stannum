grammar Stannum;

program: Stmts+=statement* EOF;


//
// Statements
//

statement
    : definition_
    | exprStmt
    | forStmt
    | ifStmt_
    | whileStmt
    | blockStmt;

definition_
    : Name=identifier '=' Value=expression ';' # Definition
    | Name=identifier '=' Value=primaryWithBlock # DefinitionWithoutSemi;

exprStmt: Value=expression ';';

forStmt: (Label=identifier ':')? FOR Value=expression ('->' Var=identifier)? Body=blockStmt;

ifStmt_
    : IF Cond=expression Cons=blockStmt # IfStmt
    | IF Cond=expression Cons=blockStmt ELSE Alt=blockStmt # IfElseStmt
    | IF Cond=expression Cons=blockStmt ELSE AltIf=ifStmt_ # IfElseIfStmt;

whileStmt: (Label=identifier ':')? WHILE Value=expression Body=blockStmt;

blockStmt: '{' Stmts+=statement '}';


//
// Expressions
//

expression: assignment_;

assignment_
    : coalesce_ # AssignmentSkip
    | Left=access_ Op=(':='|'+='|'-='|'*='|'/='|'%=') Right=expression # Assignment;

coalesce_
    : logicalOr_ # CoalesceSkip
    | Left=logicalOr_ Op=('??'|'!?') Right=coalesce_ # Coalesce;

logicalOr_
    : logicalAnd_ # LogicalOrSkip
    | Left=logicalOr_ '||' Right=logicalAnd_ # LogicalOr;

logicalAnd_
    : equality_ # LogicalAndSkip
    | Left=logicalAnd_ '&&' Right=equality_ # LogicalAnd;

equality_
    : relational_ # EqualitySkip
    | Left=equality_ Op=('=='|'!=') Right=relational_ # Equality;

relational_
    : additive_ # RelationalSkip
    | Left=relational_ Op=('<'|'>'|'<='|'>=') Right=additive_ # Relational;

additive_
    : multiplicative_ # AdditiveSkip
    | Left=additive_ Op=('+'|'-') Right=multiplicative_ # Additive;

multiplicative_
    : prefix_ # MultiplicativeSkip
    | Left=multiplicative_ Op=('*'|'/'|'%') Right=prefix_# Multiplicative;

prefix_
    : call_ # PrefixSkip
    | Op=('!'|'-') Operand=prefix_ # Prefix;
    
call_
    : primary # CallSkip
    | Callee=call_ '(' (Args+=expression ',')* Args+=expression? ')' # Call;

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
    | Left=access_ Op=('.'|'?.') Right=identifier # Access;

blockExpr: '{' Stmts+=statement* Value=expression '}';

breakExpr: BREAK Label=identifier?;

continueExpr: CONTINUE Label=identifier?;

grouped: '(' Value=expression ')';

identifier
    : IDENTIFIER keyword*
    | '$' keyword+;

ifExpr
    : IF Cond=expression Cons=blockExpr ELSE Alt=blockExpr # IfElseExpr
    | IF Cond=expression Cons=blockExpr ELSE AltIf=ifExpr # IfElseIfExpr;

lambdaWithBlock: '(' (Params+=identifier ',')* Params+=identifier? ')' Body=blockStmt;

lambdaWithExpr: '(' (Params+=identifier ',')* Params+=identifier? ')' '=>' Value=expression;

literal
    : NUMBER # NumberLit
    | STRING # StringLit
    | list # ListLit
    | record # RecordLit;
    
list: '[' (Elems+=expression)* Elems+=expression? ']';

record: '{' Elems+=recordMember (',' Elems+=recordMember)* ','? '}';

recordMember: Name=identifier '=' Value=expression;

returnExpr: RETURN Value=expression?;


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