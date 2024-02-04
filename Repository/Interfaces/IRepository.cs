namespace ConsoleApp.Repository.Interface;
public interface IRepository<T>
{
    int Insert(T obj);
    int Insert(List<T> list);
    T Select(int id);
    IEnumerable<T> Select();
    int Update(T obj);
    int Delete(int id);
}
