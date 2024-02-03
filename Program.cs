using ConsoleApp.Application;
using ConsoleApp.Models;

void Main()
{
    try
    {
        var clientTest = new Client(){
            Name = "Test-Name",
            Gender = "Test-Gender",
            Birthdate = DateTime.Now.ToString("dd/MM/yyyy"),
            Cpf = "Test-CPF"
        };
        Application.CreateClient(clientTest);
        Application.GetClients(5);
        Application.GetClient(5);
        Application.GetClient(50);

        var clients = Enumerable.Repeat(clientTest, 10).ToList();
        Application.CreateClients(clients);

        clientTest.Id = 10;
        clientTest.Name = "Test-Name-Update";
        Application.UpdateClient(clientTest);
        Application.DeleteClient(0); // Sempre remove o penúltimo elemento
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex);
    }
}

Main();