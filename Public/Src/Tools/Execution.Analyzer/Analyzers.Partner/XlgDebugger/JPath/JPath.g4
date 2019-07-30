// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// To generate lexer/parser/... run:
//
//   java -cp $CLASSPATH:antlr-4.7.2-complete.jar -Xmx500M \
//      org.antlr.v4.Tool \
//      -listener -visitor -Dlanguage=CSharp -package BuildXL.Execution.Analyzer.JPath JPath.g4

grammar JPath;

WS      : [ \t\r\n]+ -> skip    ; // skip spaces, tabs, newlines

NOT     : 'not';
AND     : 'and';
OR      : 'or' ;
XOR     : 'xor';
IFF     : 'iff';

GTE     : '>=' ;
LTE     : '<=' ;
GT      : '>'  ;
LT      : '<'  ;
EQ      : '='  ;
NEQ     : '!=' ;
MATCH   : '~'  ;
NMATCH  : '!~' ;
MINUS   : '-'  ;
PLUS    : '+'  ;
TIMES   : '*'  ;
DIV     : '/'  ;
MOD     : '%'  ;

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

ID  : [a-zA-Z][a-zA-Z0-9_]* 
    | '`' ~[`]+ '`'
    ;

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

expr
    : '$'                                             #RootExpr
    | PropertyName=ID                                 #SelectorExpr
    | Value=StrLit                                    #StrLitExpr
    | Value=RegExLit                                  #RegExLitExpr
    | Value=IntLit                                    #IntLitExpr
    | Lhs=expr '.' PropertyName=ID                    #MapExpr
    | Lhs=expr '[' Index=intExpr ']'                  #IndexExpr
    | Lhs=expr '[' Begin=intExpr '..' End=intExpr ']' #RangeExpr
    | Lhs=expr '[' Filter=logicExpr ']'               #FilterExpr
    | '(' Sub=expr ')'                                #SubExpr
    ;

