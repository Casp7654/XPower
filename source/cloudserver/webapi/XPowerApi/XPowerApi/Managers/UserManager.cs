using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;
using XPowerApi.Supporters;

namespace XPowerApi.Managers
{
    public class UserManager : IUserManager
    {
        IUserProvider _userProvider;
        IPasswordHasher _passwordHasher;

        public UserManager(IUserProvider userProvider, IPasswordHasher passwordHasher)
        {
            _userProvider = userProvider;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> CreateUser(UserCreate userCreate)
        {
            // Generate Salt
            byte[] salt = _passwordHasher.GenerateSalt();
            string hashed_password = _passwordHasher.HashPassword(userCreate.Password!, salt);
            // Create User DB Object
            Dictionary<string, string> dataArray = new Dictionary<string, string>()
            {
                { "hashed_password", hashed_password },
                { "username", userCreate.UserName },
                { "firstname", userCreate.FirstName},
                { "lastname", userCreate.LastName},
                { "email", userCreate.Email },
                { "salt", _passwordHasher.SaltToString(salt)}
            };
            return (await _userProvider.CreateUser(dataArray)).ConvertToUser();
        }

        public async Task<User> GetUserById(int id)
        {
            return (await _userProvider.GetUserById(id)).ConvertToUser();
        }
    }
}