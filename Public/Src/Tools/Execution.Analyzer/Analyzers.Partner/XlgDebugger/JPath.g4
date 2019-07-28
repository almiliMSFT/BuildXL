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

IntLit
    : [1-9][0-9]* ;

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

unaryOp
    : MINUS ;

binaryOp
    : GTE | GT | LTE | LT | EQ | NEQ | MATCH | NMATCH ;
    
logicBinaryOp
    : AND | OR | XOR | IFF ; 

logicUnaryOp
    : NOT ;

boolExpr
    : expr binaryOp expr #BinaryBoolExpr
    | unaryOp expr       #UnaryBoolExpr
    | '(' boolExpr ')'   #SubBoolExpr
    ;

logicExpr
    : boolExpr                          #BoolLogicExpr
    | logicExpr logicBinaryOp logicExpr #BinaryLogicExpr
    | logicUnaryOp logicExpr            #UnaryLogicExpr
    | '(' logicExpr ')'                 #SubLogicExpr
    ;

expr
    : '$'                               #RootExpr
    | PropertyName=ID                   #SelectorExpr
    | Value=StrLit                      #StrLitExpr
    | Value=RegExLit                    #RegExLitExpr
    | Value=IntLit                      #IntLitExpr
    | Begin=expr '..' End=expr          #RangeExpr
    | Lhs=expr '.' PropertyName=ID      #MapExpr
    | Lhs=expr '[' Filter=logicExpr ']' #FilterExpr
    | '(' Sub=expr ')'                  #SubExpr
    ;
