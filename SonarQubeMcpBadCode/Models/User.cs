namespace SonarDemoMcp.Models;

public class User
{
    public int Id;
    public string Name;
    public string PasswordHash;

    // property and field duplication (confusing)
    public string Email { get; set; }

    // method that is too long and complex
    public string Describe()
    {
        var desc = $"User {Id}: {Name}";
        // magic numbers
        for (int i = 0; i < 42; i++)
        {
            desc += ".";
        }
        return desc;
    }
}
