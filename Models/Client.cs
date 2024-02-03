namespace ConsoleApp.Models;
public class Client
{
    public int Id {get; set;}
    public string? Name {get; set;}
    public string? Gender {get; set;}
    public string? Birthdate {get; set;}
    public string? Cpf {get; set;}

    public override string ToString()
    {
        return $"Client=[Id={Id}, Name={Name}, Gender={Gender}, Birthdate={Birthdate}, Cpf={Cpf}]";
    }
}
