O Projeto foi desenvolvido utilizando o DotNet 7.0 em C#, Padrão MVC com Razor Pages, EntityFramework, SqlServer, Bootstrap, Html, CSS, Jquery e JavaScript

Altere a conection string do SQL no program.cs com a sua string de coneção
----------------------------------------------------------------------------------------------------------------------------------
Se a migration ja estiver criada exclua e execute os comando no Console:
----------------------------------------------------------------------------------------------------------------------------------
Add-Migration Inicial-criacao -Context Context
----------------------------------------------------------------------------------------------------------------------------------
Update-database -Context context
----------------------------------------------------------------------------------------------------------------------------------
