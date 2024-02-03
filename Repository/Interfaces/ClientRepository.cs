using ConsoleApp.Models;
using Dapper;

namespace ConsoleApp.Repository;
public class ClientRepository
{
    private readonly DbSession _session;

    public ClientRepository(DbSession session)
    {
        _session = session;
    }

    public int Save(Client client)
    {
        string query = "INSERT INTO Client (Name, Gender, Birthdate, Cpf) VALUES(@Name, @Gender, @Birthdate, @Cpf)";
        return _session.Connection.Execute(query, client, _session.Transaction);
    }

    public int Save(List<Client> client)
    {
        string query = "INSERT INTO Client (Name, Gender, Birthdate, Cpf) VALUES(@Name, @Gender, @Birthdate, @Cpf)";
        return _session.Connection.Execute(query, client, _session.Transaction);
    }

    public IEnumerable<Client> Get()
    {
        string query ="SELECT * FROM Client";
        return _session.Connection.Query<Client>(query);
    }

    public Client? Get(int id)
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
