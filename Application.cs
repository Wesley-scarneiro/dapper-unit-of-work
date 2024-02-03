
using System.Data;
using System.Transactions;
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
        using var dbSession = new DbSession();
        using var transaction = new UnitOfWork(dbSession);
        var repo = new ClientRepository(dbSession);

        try
        {
            transaction.BeginTransaction();
            var rows = repo.Save(client);
            transaction.Commit();
            printColor(ConsoleColor.Yellow, $"\tLines affected: {rows}");
        }
        catch(Exception ex)
        {
            transaction.RollBack();
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
        using var dbSession = new DbSession();
        using var transaction = new UnitOfWork(dbSession);
        var repo = new ClientRepository(dbSession);

        try
        {
            transaction.BeginTransaction();
            var rows = repo.Save(clients);
            transaction.Commit();
            printColor(ConsoleColor.Yellow, $"\tLines affected: {rows}");
        }
        catch(Exception ex)
        {
            transaction.RollBack();
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
        using var dbSession = new DbSession();
        var repo = new ClientRepository(dbSession);

        try
        {
            var clients = repo.Get();
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
        using var dbSession = new DbSession();
        var repo = new ClientRepository(dbSession);

        try
        {
            var client = repo.Get(id);
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
        using var dbSession = new DbSession();
        using var transaction = new UnitOfWork(dbSession);
        var repo = new ClientRepository(dbSession);

        try
        {
            transaction.BeginTransaction();
            var rows = repo.Update(client);
            transaction.Commit();
            printColor(ConsoleColor.Yellow, $"\tLines affected: {rows}");
        }
        catch(Exception ex)
        {
            printColor(ConsoleColor.Red, "UpdateClient Error");
            printColor(ConsoleColor.White, ex.ToString());
            transaction.RollBack();
        }
        finally
        {
            printColor(ConsoleColor.Green, "Finished UpdateClient");
        }
    }

    public static void DeleteClient(int id)
    {
        printColor(ConsoleColor.Green, "Running DeleteClient");
        using var dbSession = new DbSession();
        using var transaction = new UnitOfWork(dbSession);
        var repo = new ClientRepository(dbSession);

        try
        {
            transaction.BeginTransaction();
            id = repo.Get().Count()-1;
            var rows = repo.Delete(id);
            transaction.Commit();
            printColor(ConsoleColor.Yellow, $"\tId={id} record removed | {rows} lines affected");
        }
        catch(Exception ex)
        {
            printColor(ConsoleColor.Red, "DeleteClient Error");
            printColor(ConsoleColor.White, ex.ToString());
            transaction.RollBack();
        }
        finally
        {
            printColor(ConsoleColor.Green, "Finished DeleteClient");
        }
    }
}


