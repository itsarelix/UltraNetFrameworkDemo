using System.Security.Cryptography;
using System.Text;
using UltraNet.Framework.Core.Interfaces.PasswordHasher;

namespace UltraNet.Framework.Modules.Auth
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
        public bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            var inputHashed = HashPassword(inputPassword);
            return hashedPassword == inputHashed;
        }
    }
}
