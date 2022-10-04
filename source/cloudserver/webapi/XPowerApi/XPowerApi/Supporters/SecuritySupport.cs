using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace XPowerApi.Supporters
{
    public static class SecuritySupport
    {
        public static byte[] GenerateSalt()
        {
            return RandomNumberGenerator.GetBytes(128 / 8);
        }

        public static string HashPassword(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 2,
                numBytesRequested: 256 / 8));
        }
    }
}