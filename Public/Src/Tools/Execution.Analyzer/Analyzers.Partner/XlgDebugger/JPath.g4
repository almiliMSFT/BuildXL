grammar JPath;

ID : [a-zA-Z][a-zA-Z0-9_]* ;
WS : [ \t\r\n]+ -> skip    ; // skip spaces, tabs, newlines

IntConst : [1-9][0-9]* ;
GTE      : '>=';
LTE      : '<=';
GT       : '>' ;
LT       : '<' ;
EQ       : '=' ;
NEQ      : '!=';
TLDE     : '~' ;

expr     : ID
         | IntConst
         | expr '.' ID
         | expr '[' filter ']'
         ;

boolOp   : GTE | GT | LTE | LT | EQ | NEQ | TLDE ;

filter   : IntConst
         | IntConst '..' IntConst
         | expr boolOp expr
         ;