Coloque a sua conection string do SQL no program.cs 
----------------------------------------------------------------------------------------------------------------------------------
Se a migration ja estiver criada exclua e execute os comando no Console:
----------------------------------------------------------------------------------------------------------------------------------
Add-Migration Inicial-criacao -Context Context
----------------------------------------------------------------------------------------------------------------------------------
Update-database -Context context
----------------------------------------------------------------------------------------------------------------------------------
