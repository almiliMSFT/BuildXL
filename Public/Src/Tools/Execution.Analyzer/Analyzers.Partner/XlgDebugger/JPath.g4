grammar JPath;

// To generate lexer/parser/... run:
//
//   java -cp $CLASSPATH:antlr-4.7.2-complete.jar -Xmx500M \
//      org.antlr.v4.Tool \
//      -listener -visitor -Dlanguage=CSharp -package BuildXL.Execution.Analyzer.JPath JPath.g4


ID : [a-zA-Z][a-zA-Z0-9_]* ;
WS : [ \t\r\n]+ -> skip    ; // skip spaces, tabs, newlines

GTE      : '>=' ;
LTE      : '<=' ;
GT       : '>'  ;
LT       : '<'  ;
EQ       : '='  ;
NEQ      : '!=' ;
MATCH    : '~'  ;
NMATCH   : '!~' ;

IntLit   : [1-9][0-9]* ;

StrLit   : '\'' [^']* '\''
         | '"' [^"]* '"'
         ;

RegExLit : '/' [^/]+ '/' ;

expr    : Name=ID                         #VarExpr
        | Value=IntLit                    #IntLitExpr
        | Value=StrLit                    #StrLitExpr
        | Value=RegExLit                  #RegExLitExpr
        | Lhs=expr '.' FieldName=ID       #MapExpr
        | Lhs=expr '[' Filter=filter ']'  #FilterExpr
        ;

boolOp  : GTE | GT | LTE | LT | EQ | NEQ | MATCH | NMATCH ;

filter  : Index=IntLit                    #IndexFilter
        | Start=IntLit '..' End=IntLit    #RangeFilter
        | Lhs=expr Op=boolOp Rhs=expr     #BoolFilter
        ;