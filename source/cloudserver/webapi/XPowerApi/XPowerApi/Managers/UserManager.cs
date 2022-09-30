using XPowerApi.DbModels;
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

        public async Task<User> CreateUser(UserCredentials userCreate)
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

        public async Task<bool> ValidateUserCredentials(UserLogin user)
        {
            if (user == null)
                return false;

            UserDb validUser = await GetUserByUsername(user.UserName);

            if(validUser == null)
                return false;

            if (!MatchPassword(validUser, user))
                return false;

            return true;
        }

        public async Task<User> GetUserById(int id)
        {
            return (await _userProvider.GetUserById(id)).ConvertToUser();
        }

        public async Task<UserDb> GetUserByUsername(string username)
        {
            return (await _userProvider.GetUserByUsername(username));
        }

        // TODO: Figure out if this is needed and if it should even be in this class
        // Matches the passwords of 2 user, 1 of which contains a hashed password and its salt.
        // The other contains a plain text password.
        // Returns true if passwords match after being hashed with same salt.
        private bool MatchPassword(UserDb userWithSalt, UserLogin user)
        {
            byte[] salt = System.Text.Encoding.UTF8.GetBytes(userWithSalt.salt);

            if (userWithSalt.hashedPassword == SecuritySupport.HashPassword(user.Password, salt))
                return true;

            return false;

        }
    }
}