using System.Data;
using Microsoft.Data.Sqlite;

namespace ConsoleApp.Repository;
public sealed class DbSession : IDisposable
{
    private readonly Guid _id;
    public IDbConnection Connection {get;}
    public IDbTransaction? Transaction {get; set;}

    public DbSession()
    {
        _id = Guid.NewGuid();
        Connection = new SqliteConnection(Settings.ConnectionString);
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}
