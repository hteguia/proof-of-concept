using System.Security.Cryptography;
using System.Text;

namespace SonarDemoMcp.Utils;

public static class Hashing
{
    // insecure hashing algorithm (MD5)
    public static string MD5Hash(string input)
    {
        using (var md5 = MD5.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = md5.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }

    // Unused method (dead code)
    public static string Unused()
    {
        return "i am unused";
    }
}
