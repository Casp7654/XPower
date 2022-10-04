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
        IPasswordHasher _passwordHasher;

        public UserManager(IUserProvider userProvider, IPasswordHasher passwordHasher, ITokenManager<UserToken> tokenManager)
        {
            _userProvider = userProvider;
            _passwordHasher = passwordHasher;
            _tokenManager = tokenManager;
        }

        /// <inheridDoc />
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

        /// <inheridDoc />
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

        /// <inheridDoc />
        public async Task<User> GetUserById(int id)
        {
            return (await _userProvider.GetUserById(id)).ConvertToUser();
        }

        /// <inheridDoc />
        public async Task<UserCredentials> GetUserCredentialsByUsername(string username)
        {
            return (await _userProvider.GetUserByUsername(username)).ConvertToUserCredentials();
        }

        /// <summary>
        /// Validates the given usercredentials by checking if the password matches. 
        /// </summary>
        /// <param name="validUser">The usercredentials to check against</param>
        /// <param name="user">The user to check against</param>
        /// <returns>True if valid, false if not.</returns>
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
        /// <param name="validUser">The user with hashed password.</param>
        /// <param name="user">The user with the plain password</param>
        /// <returns> True if passwords match after being hashed with same salt.</returns>
        private bool MatchPassword(UserCredentials validUser, UserLogin user)
        {
            byte[] salt = Convert.FromBase64String(validUser.Salt);

            if (validUser.HashedPassword == _passwordHasher.HashPassword(user.Password, salt))
                return true;

            return false;

        }
    }
}