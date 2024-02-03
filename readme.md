# Dapper Unit of Work e Repository Pattern

Aplicação simples de console usando .NET Core e Dapper para manipulações de transações com banco de dados.
Para persistência dos dados é utilizado o SQLite.

# Packages utilizados

* Dapper
* Microsoft.Data.SqlClient 
* Microsoft.Data.Sqlite

# Classes

* DbSession: encapsula a criação da conexão com o banco de dados e das transações
* UnitOfWork: manipula a criação e commit das transações
* ClientRepository: manipula a execução das queries para a tabela Client no banco de dados
* Application: operações da aplicação

# Log

![Log](log.png)

