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

ESC_ID
    : '`' ~[`]+ '`' ;

IntBinaryOp
    : PLUS | MINUS | TIMES | DIV | MOD ;

IntUnaryOp
    : MINUS ;

BoolBinaryOp
    : GTE | GT | LTE | LT | EQ | NEQ | MATCH | NMATCH ;
    
LogicBinaryOp
    : AND | OR | XOR | IFF ; 

LogicUnaryOp
    : NOT ;

ArrayBinaryOp
    : CONCAT | INTERSECT ;

AnyBinaryOp
    : IntBinaryOp | BoolBinaryOp | LogicBinaryOp | ArrayBinaryOp ;
    
intExpr
    : Expr=expr                                       #ExprIntExpr
    | Op=IntUnaryOp Sub=intExpr                       #UnaryIntExpr
    | Lhs=intExpr Op=IntBinaryOp Rhs=intExpr          #BinaryIntExpr
    | '(' Sub=intExpr ')'                             #SubIntExpr
    ;

boolExpr
    : Lhs=intExpr Op=BoolBinaryOp Rhs=intExpr         #BinaryBoolExpr
    | '(' Sub=boolExpr ')'                            #SubBoolExpr
    ;

logicExpr
    : Expr=boolExpr                                   #BoolLogicExpr
    | Lhs=logicExpr Op=LogicBinaryOp Rhs=logicExpr    #BinaryLogicExpr
    | Op=LogicUnaryOp Sub=logicExpr                   #UnaryLogicExpr
    | '(' Sub=logicExpr ')'                           #SubLogicExpr
    ;

id  : PropertyName=VarID                              #IdSelector
    | PropertyName=ESC_ID                             #EscIdSelector
    ;

selector
    : Name=id                                         #NameSelector
    | RootPropertyName=RootID                         #RootIdSelector
    | '(' Names+=id ('+' Names+=id)+ ')'              #UnionSelector
    ;

expr
    : '$'                                             #RootExpr
    | Sub=selector                                    #SelectorExpr
    | Value=StrLit                                    #StrLitExpr
    | Value=RegExLit                                  #RegExLitExpr
    | Value=IntLit                                    #IntLitExpr
    | Lhs=expr Op=AnyBinaryOp Rhs=expr                #BinExpr
    | Lhs=expr '.' Selector=selector                  #MapExpr
    | Lhs=expr '[' Index=intExpr ']'                  #IndexExpr
    | Lhs=expr '[' Begin=intExpr '..' End=intExpr ']' #RangeExpr
    | Lhs=expr '[' Filter=logicExpr ']'               #FilterExpr
    | Func=expr '(' Args+=expr (',' Args+=expr)* ')'  #FuncAppExpr
    | Input=expr '|' Func=expr                        #PipeExpr
    | '(' Sub=expr ')'                                #SubExpr
    ;

