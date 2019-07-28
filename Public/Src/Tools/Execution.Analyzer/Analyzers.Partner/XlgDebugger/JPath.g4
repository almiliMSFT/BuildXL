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

expr    : ID                    #VarExpr
        | IntLit                #IntLitExpr
        | StrLit                #StrLitExpr
        | RegExLit              #RegExLitExpr
        | expr '.' ID           #MapExpr
        | expr '[' filter ']'   #FilterExpr
        ;

boolOp  : GTE | GT | LTE | LT | EQ | NEQ | MATCH | NMATCH ;

filter  : IntLit                #IndexFilter
        | IntLit '..' IntLit    #RangeFilter
        | expr boolOp expr      #BoolFilter
        ;