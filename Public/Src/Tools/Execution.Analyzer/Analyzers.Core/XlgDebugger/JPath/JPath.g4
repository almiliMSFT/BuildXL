// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// To generate lexer/parser/... run:
//
//   java -cp $CLASSPATH:antlr-4.7.2-complete.jar -Xmx500M \
//      org.antlr.v4.Tool \
//      -listener -visitor -Dlanguage=CSharp -package BuildXL.Execution.Analyzer.JPath JPath.g4

grammar JPath;

WS      : [ \t\r\n]+ -> skip    ; // skip spaces, tabs, newlines

// logic operators
NOT     : 'not';
AND     : 'and';
OR      : 'or' ;
XOR     : 'xor';
IFF     : 'iff';

// bool operators
GTE     : '>=' ;
LTE     : '<=' ;
GT      : '>'  ;
LT      : '<'  ;
EQ      : '='  ;
NEQ     : '!=' ;
MATCH   : '~'  ;
NMATCH  : '!~' ;

// arithmetic operators
MINUS   : '-'  ;
PLUS    : '+'  ;
TIMES   : '*'  ;
DIV     : '/'  ;
MOD     : '%'  ;

// array operators
CONCAT    : '++' ;
INTERSECT : '&'  ;

IntLit
    : [0-9]+ ;

StrLit
    : '\'' ~[']* '\''
    | '"' ~["]* '"'
    ;

RegExLit
    : '/' ~[/]+ '/' 
    | '!' ~[!]+ '!'
    ;

fragment IdFragment
    : [a-zA-Z][a-zA-Z0-9_]* ;

VarID
    : IdFragment ;

RootID
    : '$' IdFragment ;

EscID
    : '`' ~[`]+ '`' ;

Switch
    : '-' [a-zA-Z0-9'-']+ ;

intBinaryOp
    : Token=(PLUS | MINUS | TIMES | DIV | MOD) ;

intUnaryOp
    : Token=MINUS ;

boolBinaryOp
    : Token=(GTE | GT | LTE | LT | EQ | NEQ | MATCH | NMATCH) ;
    
logicBinaryOp
    : Token=(AND | OR | XOR | IFF) ; 

logicUnaryOp
    : Token=NOT ;

arrayBinaryOp
    : Token=(CONCAT | INTERSECT) ;

anyBinaryOp
    : intBinaryOp
    | boolBinaryOp
    | logicBinaryOp
    | arrayBinaryOp
    ;

intExpr
    : Expr=expr                                       #ExprIntExpr
    | Op=intUnaryOp Sub=intExpr                       #UnaryIntExpr
    | Lhs=intExpr Op=intBinaryOp Rhs=intExpr          #BinaryIntExpr
    | '(' Sub=intExpr ')'                             #SubIntExpr
    ;

boolExpr
    : Lhs=intExpr Op=boolBinaryOp Rhs=intExpr         #BinaryBoolExpr
    | '(' Sub=boolExpr ')'                            #SubBoolExpr
    ;

logicExpr
    : Expr=boolExpr                                   #BoolLogicExpr
    | Lhs=logicExpr Op=logicBinaryOp Rhs=logicExpr    #BinaryLogicExpr
    | Op=logicUnaryOp Sub=logicExpr                   #UnaryLogicExpr
    | '(' Sub=logicExpr ')'                           #SubLogicExpr
    ;

id  : PropertyName=VarID                              #VarId
    | PropertyName=EscID                              #EscId
    | RootPropertyName=RootID                         #RootId
    ;

selector
    : Name=id                                         #NameSelector
    | '(' Names+=id ('+' Names+=id)+ ')'              #UnionSelector
    ;

literal
    : Value=StrLit                                    #StrLitExpr
    | Value=RegExLit                                  #RegExLitExpr
    | Value=IntLit                                    #IntLitExpr
    ;

expr
    : '$'                                             #RootExpr
    | Sub=selector                                    #SelectorExpr
    | Lit=literal                                     #LiteralExpr
    | Lhs=expr '.' Selector=selector                  #MapExpr
    | Lhs=expr '[' Filter=logicExpr ']'               #FilterExpr
    | Lhs=expr '[' Index=intExpr ']'                  #IndexExpr
    | Lhs=expr '[' Begin=intExpr '..' End=intExpr ']' #RangeExpr
    | '#' Sub=expr                                    #CardinalityExpr
    | Func=expr '(' Args+=expr (',' Args+=expr)* ')'  #FuncAppExprParen
    | Func=expr Arg=expr                              #FuncAppExpr
    | Func=expr OptName=Switch (OptValue=literal)?    #FuncOptExpr
    | Input=expr '|' Func=expr                        #PipeExpr
    | Lhs=expr Op=anyBinaryOp Rhs=expr                #BinExpr
    | '(' Sub=expr ')'                                #SubExpr
    | 'let' Name=id ':=' Value=expr ('in' Sub=expr)?  #LetExpr 
    ;

