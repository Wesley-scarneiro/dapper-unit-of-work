using ConsoleApp.Models;
using ConsoleApp.Repository.Interface;
using Dapper;

namespace ConsoleApp.Repository;
public class LogClientRepository : IRepositoryInsertion<LogClient>
{
    private readonly DbSession _session;

    public LogClientRepository(DbSession session)
    {
        _session = session;
    }

    public int Insert(int rows)
    {
        var logClient = new LogClient()
        {
            DateTime = DateTime.Now,
            User = "Admin",
            Insertions = rows
        };
        string query = $"INSERT INTO LogClient (DateTime, User, Insertions) VALUES(@DateTime, @User, @Insertions)";
        return _session.Connection.Execute(query, logClient, _session.Transaction);
    }
}
