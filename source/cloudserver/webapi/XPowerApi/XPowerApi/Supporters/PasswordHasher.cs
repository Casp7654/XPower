using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using XPowerApi.Interfaces;

namespace XPowerApi.Supporters
{
    public class PasswordHasher : IPasswordHasher
    {
        /// <inheritDoc />
        public byte[] GenerateSalt()
        {
            return RandomNumberGenerator.GetBytes(128 / 8);
        }

        /// <inheritDoc />
        public string SaltToString(byte[] salt)
        {
            return Convert.ToBase64String(salt);
        }
        
        /// <inheritDoc />
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