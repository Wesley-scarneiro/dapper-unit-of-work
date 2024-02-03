namespace ConsoleApp.Repository.Interface;
public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();
    void Commit();
    void RollBack();
}
