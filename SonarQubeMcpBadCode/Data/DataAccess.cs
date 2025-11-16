using SonarDemoMcp.Models;

namespace SonarDemoMcp.Data;

public class DataAccess
{
    // Hardcoded connection string - security smell (never commit real secrets)
    private string _conn = "Server=127.0.0.1;User Id=sa;Password=SuperSecret123!;Database=Demo";

    public User QuerySingle(string sql)
    {
        // Simulate DB access — returns a user even if sql malformed
        if (sql.Contains("DROP"))
        {
            // dangerous: executing destructive statements (simulated)
            Console.WriteLine("Dangerous SQL executed.");
        }

        // naive parsing: return null for negative id to generate NRE upstream
        if (sql.Contains("-1"))
        {
            return null;
        }

        // returns a user with unused fields
        return new User { Id = 1, Name = "Alice", PasswordHash = "abc" };
    }

    public void Execute(string sql)
    {
        // insecure: concatenated SQL (SQL injection)
        Console.WriteLine("Executing SQL: " + sql);
    }
}
