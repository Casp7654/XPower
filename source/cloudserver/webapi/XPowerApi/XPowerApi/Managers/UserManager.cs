using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;
using XPowerApi.Supporters;

namespace XPowerApi.Managers
{
    public class UserManager : IUserManager
    {
        IUserProvider _userProvider;

        public UserManager(IUserProvider userProvider)
        {
            _userProvider = userProvider;
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
                { "firstname", userCreate.FirstName},
                { "lastname", userCreate.LastName},
                { "email", userCreate.Email },
                { "salt", System.Text.Encoding.UTF8.GetString(salt) }
            };
            return (await _userProvider.CreateUser(dataArray)).ConvertToUser();
        }

        public async Task<bool> ValidateUserCredentials(User user)
        {
            User validUser = await GetUserByUsername(user.UserName);
        }

        public async Task<User> GetUserById(int id)
        {
            return (await _userProvider.GetUserById(id)).ConvertToUser();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return (await _userProvider.GetUserByUsername(username)).ConvertToUser();
        }
    }
}