using XPowerApi.DbModels;

namespace XPowerApi.Interfaces
{
    public interface IUserProvider
    {
        /// <summary>
        /// Creates user from the specified model data.
        /// ex: key : value
        /// </summary>
        /// <param name="dataArray">The user data to create from</param>
        /// <returns>A userDb model representing the data.</returns>
        Task<UserDb> CreateUser(Dictionary<string, string> dataArray);

        /// <summary>
        /// Get userdb by id.
        /// </summary>
        /// <param name="id">The id to fetch from.</param>
        /// <returns>The userdb representing the data.</returns>
        Task<UserDb> GetUserById(int id);

        /// <summary>
        /// Get userdb by the username relating to the user.
        /// </summary>
        /// <param name="username">The username relating to the user.</param>
        /// <returns>a userdb representing the user.</returns>
        Task<UserDb> GetUserByUsername(string username);
    }
}
