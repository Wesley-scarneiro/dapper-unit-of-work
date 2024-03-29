using ConsoleApp.Models;
using ConsoleApp.Repository.Interface;

namespace ConsoleApp.Repository;
public class UnitOfWork : IUnitOfWork
{
    private readonly DbSession _session;
    public IRepository<Client> ClientRepository {get; init;}
    public IRepositoryInsertion<LogClient> LogClientRepository {get; init;}

    public UnitOfWork(DbSession session)
    {
        _session = session;
        ClientRepository = new ClientRepository(session);
        LogClientRepository = new LogClientRepository(session);
    }

    public void BeginTransaction()
    {
        _session.Transaction = _session.Connection.BeginTransaction();
    }

    public void Commit()
    {
        _session.Transaction?.Commit();
        Dispose();        
    }

    public void RollBack()
    {
        _session.Transaction?.Rollback();
        Dispose();
    }

    public void Dispose() => _session.Transaction?.Dispose();
}
