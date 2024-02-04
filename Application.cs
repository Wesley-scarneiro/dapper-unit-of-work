using ConsoleApp.Models;
using ConsoleApp.Repository;

namespace ConsoleApp.Application;

public static class Application
{
    private static void printColor(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void CreateClient(Client client)
    {
        printColor(ConsoleColor.Green, "Running CreateClient");
        using var uow = new UnitOfWork(new DbSession());

        try
        {
            uow.BeginTransaction();
            var rows = uow.ClientRepository.Insert(client);
            uow.LogClientRepository.Insert(rows);
            uow.Commit();
            printColor(ConsoleColor.Yellow, $"\tLines affected: {rows}");
        }
        catch(Exception ex)
        {
            uow.RollBack();
            printColor(ConsoleColor.Red, "CreateClient Error");
            printColor(ConsoleColor.White, ex.ToString());
        }
        finally
        {
            printColor(ConsoleColor.Green, "Finished CreateClient");
        }
    }

    public static void CreateClients(List<Client> clients)
    {
        printColor(ConsoleColor.Green, $"Running CreateClients");
        using var uow = new UnitOfWork(new DbSession());

        try
        {
            uow.BeginTransaction();
            var rows = uow.ClientRepository.Insert(clients);
            uow.LogClientRepository.Insert(rows);
            uow.Commit();
            printColor(ConsoleColor.Yellow, $"\tLines affected: {rows}");
        }
        catch(Exception ex)
        {
            uow.RollBack();
            printColor(ConsoleColor.Red, "CreateClient Error");
            printColor(ConsoleColor.White, ex.ToString());
        }
        finally
        {
            printColor(ConsoleColor.Green, "Finished CreateClients");
        }
    }

    public static void GetClients(int take=0)
    {
        printColor(ConsoleColor.Green, "Running GetClients");
        var uow = new UnitOfWork(new DbSession());

        try
        {
            var clients = uow.ClientRepository.Select();
            if (take == 0) take = clients.Count();
            printColor(ConsoleColor.DarkYellow, $"\tTotal: {clients.Count()} | Take: {take}");
            foreach (var client in clients.Take(take)) printColor(ConsoleColor.Yellow, $"\t{client}");
        }
        catch(Exception ex)
        {
            printColor(ConsoleColor.Red, "GetClients Error");
            printColor(ConsoleColor.White, ex.ToString());
        }
        finally
        {
            printColor(ConsoleColor.Green, "Finished GetClients");
        }
    }

    public static void GetClient(int id)
    {
        printColor(ConsoleColor.Green, "Running GetClient");
        var uow = new UnitOfWork(new DbSession());

        try
        {
            var client = uow.ClientRepository.Select(id);
            if (client is null) printColor(ConsoleColor.Red, $"\tNo record found with Id={id}");
            else printColor(ConsoleColor.Yellow, $"\t{client}");
        }
        catch(Exception ex)
        {
            printColor(ConsoleColor.Red, "GetClient Error");
            printColor(ConsoleColor.White, ex.ToString());
        }
        finally
        {
            printColor(ConsoleColor.Green, "Finished GetClient");
        }
    }

    public static void UpdateClient(Client client)
    {
        printColor(ConsoleColor.Green, "Running UpdateClient");
        var uow = new UnitOfWork(new DbSession());

        try
        {
            uow.BeginTransaction();
            var rows = uow.ClientRepository.Update(client);
            uow.Commit();
            printColor(ConsoleColor.Yellow, $"\tLines affected: {rows}");
        }
        catch(Exception ex)
        {
            printColor(ConsoleColor.Red, "UpdateClient Error");
            printColor(ConsoleColor.White, ex.ToString());
            uow.RollBack();
        }
        finally
        {
            printColor(ConsoleColor.Green, "Finished UpdateClient");
        }
    }

    public static void DeleteClient(int id)
    {
        printColor(ConsoleColor.Green, "Running DeleteClient");
        var uow = new UnitOfWork(new DbSession());

        try
        {
            uow.BeginTransaction();
            id = uow.ClientRepository.Select().Count()-1;
            var rows = uow.ClientRepository.Delete(id);
            uow.Commit();
            printColor(ConsoleColor.Yellow, $"\tId={id} record removed | {rows} lines affected");
        }
        catch(Exception ex)
        {
            printColor(ConsoleColor.Red, "DeleteClient Error");
            printColor(ConsoleColor.White, ex.ToString());
            uow.RollBack();
        }
        finally
        {
            printColor(ConsoleColor.Green, "Finished DeleteClient");
        }
    }
}


