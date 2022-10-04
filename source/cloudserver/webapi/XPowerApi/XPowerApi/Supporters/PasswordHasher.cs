using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using XPowerApi.Interfaces;

namespace XPowerApi.Supporters
{
    public class PasswordHasher : IPasswordHasher
    {
        public byte[] GenerateSalt()
        {
            return RandomNumberGenerator.GetBytes(128 / 8);
        }

        public string SaltToString(byte[] salt)
        {
            return Convert.ToBase64String(salt);
        }

        public string HashPassword(string password, byte[] salt)
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