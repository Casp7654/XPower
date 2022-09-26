using XPowerApi.Interfaces;
using XPowerApi.DbModels;
using XPowerApi.Models.UserModels;
using XPowerApi.Supporters;

namespace XPowerApi.Providers
{
    public class UserProvider : IUserProvider
    {
        private SurrealDbProvider _dbProvider;

        public UserProvider(IConfiguration configuration)
        {
            _dbProvider = new SurrealDbProvider(configuration);
        }

        public async Task<User> CreateUser(UserCreate userCreate)
        {
            // Generate Salt
            byte[] salt = SecuritySupport.GenerateSalt();
            string hashed_password = SecuritySupport.HashPassword(userCreate.Password!, salt);

            // Create User DB Object
            Dictionary<string, string> dataArray = new Dictionary<string, string>()
            {
                { "hashed_password", hashed_password },
                { "username", userCreate.UserName },
                { "salt", System.Text.Encoding.UTF8.GetString(salt) }
            };
            // Create Db object and Convert to User on success
            User user = (await _dbProvider.Create<UserDb>("user", dataArray)).ConvertToUser();
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            User user = (await _dbProvider.GetOneById<UserDb>("user", id)).ConvertToUser();
            return user;
        }
    }
}