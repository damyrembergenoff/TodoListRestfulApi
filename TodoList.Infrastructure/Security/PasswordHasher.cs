using System.Security.Cryptography;
using System.Text;

namespace TodoList.Infrastructure.Security;

public static class PasswordHasherEntensions
{
    public static string HashPassword(this string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    public static bool VerifyPassword(this string password, string passwordHash)
    {
        var hashOfInput = HashPassword(password);
        return hashOfInput == passwordHash;
    }
}