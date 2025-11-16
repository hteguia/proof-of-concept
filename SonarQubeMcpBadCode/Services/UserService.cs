using SonarDemoMcp.Data;
using SonarDemoMcp.Models;
using SonarDemoMcp.Utils;

namespace SonarDemoMcp.Services;

public class UserService
{
    private readonly DataAccess _db;
    // propriété mutable exposée (code smell)
    public int Counter { get; set; } = 0;

    public UserService(DataAccess db)
    {
        _db = db;
    }

    public User GetUserById(int id)
    {
        Counter++; // état partagé, pas thread-safe (bug)
                   // construction SQL vulnérable (SQL injection)
        var sql = "SELECT * FROM Users WHERE Id = " + id;
        return _db.QuerySingle(sql);
    }

    public bool CreateUser(string name, string password)
    {
        // hash insecure using MD5 (security)
        var hashed = Hashing.MD5Hash(password);
        // hardcoded DB password used inside DataAccess.Configure (see appsettings) — example only
        _db.Execute($"INSERT INTO Users (Name, Password) VALUES ('{name}', '{hashed}')");
        return true;
    }

    // Long method with many responsibilities (code smell / complexity)
    public void DoManyThings()
    {
        // duplicated code block
        Console.WriteLine("Start");
        Console.WriteLine("Start");
        Console.WriteLine("Processing...");
        // swallow exceptions (bug)
        try
        {
            // some risky operation
            var x = 0;
            var y = 10 / x; // will throw
        }
        catch (Exception)
        {
            // swallow: no logging, hiding errors
        }
        // TODO left in code
        // TODO: implement audit
    }
}
