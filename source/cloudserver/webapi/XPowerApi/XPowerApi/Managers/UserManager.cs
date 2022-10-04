using XPowerApi.DbModels;
using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;
using XPowerApi.Supporters;

namespace XPowerApi.Managers
{
    public class UserManager : IUserManager
    {
        IUserProvider _userProvider;
        private readonly ITokenManager<UserToken> _tokenManager;

        public UserManager(IUserProvider userProvider, ITokenManager<UserToken> tokenManager)
        {
            _userProvider = userProvider;
            _tokenManager = tokenManager;
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
                { "salt", Convert.ToBase64String(salt) }
            };
            return (await _userProvider.CreateUser(dataArray)).ConvertToUser();
        }

        /// <summary>
        /// Fetches a new user token, if user is valid.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>A new user token</returns>
        public async Task<string> GetNewUserToken(UserLogin user)
        {
            UserCredentials validUser = await GetUserCredentialsByUsername(user.Username);

            if (ValidateCredentials(validUser, user))
            {
                UserToken userToken = await _tokenManager.GenerateToken(validUser);
                return userToken.Token;
            }

            return string.Empty;
        }

        public async Task<User> GetUserById(int id)
        {
            return (await _userProvider.GetUserById(id)).ConvertToUser();
        }

        public async Task<UserCredentials> GetUserCredentialsByUsername(string username)
        {
            return (await _userProvider.GetUserByUsername(username))?.ConvertToUserCredentials();
        }

        // Validates user credentials.
        private bool ValidateCredentials(UserCredentials validUser, UserLogin user)
        {

            if (user == null)
                return false;

            if (validUser == null)
                return false;

            return MatchPassword(validUser, user);
          
        }

        /// <summary>
        /// Matches the passwords of 2 user, 1 of which contains a hashed password and its salt.
        /// The other contains a plain text password.
        /// </summary>
        /// User containing a hashed password and a salt
        /// <param name="validUser"></param>
        /// User with plain text password
        /// <param name="user"></param>
        /// <returns> true if passwords match after being hashed with same salt.</returns>
        private bool MatchPassword(UserCredentials validUser, UserLogin user)
        {
            byte[] salt = Convert.FromBase64String(validUser.Salt);

            if (validUser.HashedPassword == SecuritySupport.HashPassword(user.Password, salt))
                return true;

            return false;

        }
    }
}