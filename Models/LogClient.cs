namespace ConsoleApp.Models;
public class LogClient
{
    public int Id {get; set;}
    public DateTime? DateTime {get; set;}
    public string? User {get; set;}
    public int Insertions {get; set;}


    public override string ToString()
    {
        return $"LogClient=[Id={Id}, DateTime={DateTime}, User={User}, Insertions={Insertions}, Updates={Updates}, Deletions={Deletions}]";
    }
}
