using XPowerApi.Interfaces;
using XPowerApi.DbModels;
using XPowerApi.DbModels.SurrealDbModels;
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
            // Generate Salt
            string salt = "hestepest"; // TODO: Make Salt
            // Create DB Object
            Dictionary<string, string> dataArray = new Dictionary<string, string>()
            {
                {"hashed_password", userCreate.Password},
                {"username",userCreate.UserName},
                {"salt",salt}
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