using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using XPowerApi.Interfaces;
using XPowerApi.DbModels;
using XPowerApi.Managers;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Providers
{
    public class UserProvider : IUserProvider
    {
        private SurrealDbManager _dbManager;

        public UserProvider(IConfiguration configuration)
        {
            _dbManager = new SurrealDbManager(configuration);
        }

        public async Task<User> CreateUser(UserCreate userCreate)
        {
            // TODO: Generate Salt
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: userCreate.Password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 2,
                numBytesRequested: 256 / 8));
            
            // Create DB Object
            Dictionary<string, string> dataArray = new Dictionary<string, string>()
            {
                {"hashed_password", hashed},
                {"username",userCreate.UserName},
                {"salt",System.Text.Encoding.UTF8.GetString(salt)}
            };
            // Create Dbobject and Convert to User on success
            User user = (await _dbManager.Create<UserDb>("user", dataArray)).ConvertToUser();
            return user;
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {
            User user = (await _dbManager.GetOneById<UserDb>("user", id)).ConvertToUser();
            return user;
        }

        public Task<User> UpdateUserUsername(int id, string username)
        {
            throw new NotImplementedException();
        }
    }
}