grammar JPath;

ID : [a-zA-Z][a-zA-Z0-9_]* ;
WS : [ \t\r\n]+ -> skip    ; // skip spaces, tabs, newlines

GTE      : '>=';
LTE      : '<=';
GT       : '>' ;
LT       : '<' ;
EQ       : '=' ;
NEQ      : '!=';
TLDE     : '~' ;
SQUOT    : '\'';
DQUOT    : '"' ;
IntLit   : [1-9][0-9]* ;
StrLit   : SQUOT [^SQUOT]* SQUOT
         | DQUOT [^DQUOT]* DQUOT
         ;

expr     : ID
         | IntLit
         | StrLit
         | expr '.' ID
         | expr '[' filter ']'
         ;

boolOp   : GTE | GT | LTE | LT | EQ | NEQ | TLDE ;

filter   : IntLit
         | IntLit '..' IntLit
         | expr boolOp expr
         ;