using ConsoleApp.Models;
using ConsoleApp.Repository.Interface;
using Dapper;

namespace ConsoleApp.Repository;
public class ClientRepository : IRepository<Client>
{
    private readonly DbSession _session;

    public ClientRepository(DbSession session)
    {
        _session = session;
    }

    public int Insert(Client client)
    {
        string query = "INSERT INTO Client (Name, Gender, Birthdate, Cpf) VALUES(@Name, @Gender, @Birthdate, @Cpf)";
        return _session.Connection.Execute(query, client, _session.Transaction);
    }

    public int Insert(List<Client> client)
    {
        string query = "INSERT INTO Client (Name, Gender, Birthdate, Cpf) VALUES(@Name, @Gender, @Birthdate, @Cpf)";
        return _session.Connection.Execute(query, client, _session.Transaction);
    }

    public IEnumerable<Client> Select()
    {
        string query ="SELECT * FROM Client";
        return _session.Connection.Query<Client>(query);
    }

    public Client? Select(int id)
    {
        string query ="SELECT * FROM Client WHERE Id=@Id";
        return _session.Connection.QueryFirstOrDefault<Client>(query, new {Id = id});
    }

    public int Update(Client client)
    {
        string query = "UPDATE Client SET Name=@Name, Gender=@Gender, Birthdate=@Birthdate, Cpf=@Cpf WHERE Id=@Id";
        return _session.Connection.Execute(query, client, _session.Transaction);
    }

    public int Delete(int id)
    {
        string query = "DELETE FROM Client WHERE Id=@Id";
        return _session.Connection.Execute(query, new {Id=id}, _session.Transaction);
    }
}
