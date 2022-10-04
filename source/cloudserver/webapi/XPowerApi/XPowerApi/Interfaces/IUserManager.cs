using XPowerApi.Models.UserModels;

namespace XPowerApi.Interfaces
{
    public interface IUserManager
    {
        /// <summary>
        /// Creates hub from the specified model data.
        /// </summary>
        /// <param name="hubCreate">The hub data to create from</param>
        /// <returns>A hub model representing the data.</returns>
        Task<User> CreateUser(UserCreate userCreate);

        /// <summary>
        /// Get hub by id.
        /// </summary>
        /// <param name="id">The id to fetch from.</param>
        /// <returns>The hub representing the data.</returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// Get hubs by the home id relating to the hub.
        /// </summary>
        /// <param name="homeId">The home id relating to the hub.</param>
        /// <returns>A list of hubs, which relates to the home id</returns>
        Task<UserCredentials> GetUserCredentialsByUsername(string username);

        /// <summary>
        /// Generates a new user token from the specified login data.
        /// </summary>
        /// <param name="user">The user data to generate from.</param>
        /// <returns>The UserToken Object.</returns>
        Task<UserToken> GetNewUserToken(UserLogin user);

    }
}
