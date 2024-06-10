%{
#include <stdio.h>
%}

%%

[0-9]+          { printf("NUMBER: %s\n", yytext); }
[a-zA-Z_][a-zA-Z0-9_]*    { printf("IDENTIFIER: %s\n", yytext); }
"+"|"-"|"*"|"/"    { printf("OPERATOR: %s\n", yytext); }
[ \t\n]+        { printf("MASTER: %s\n", yytext); /* Ignorar espacios y tabulaciones */ }
.               { printf("UNKNOWN: %s\n", yytext); }

%%

int main(int argc, char **argv)
{
    if (argc > 1) {
        FILE *file = fopen(argv[1], "r");
        if (!file) {
            perror(argv[1]);
            return 1;
        }
        yyin = file;
        yylex();
        fclose(file);
    }
    else {
        yylex();
    }
    return 0;
}

int yywrap() {
    return 1;
}
