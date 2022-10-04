using XPowerApi.DbModels.SurrealDbModels;
using XPowerApi.Models.HomeModels;

namespace XPowerApi.Interfaces
{
    public interface IHomeManager
    {
        /// <summary>
        /// Creates a new home.
        /// </summary>
        /// <param name="homeCreate">The home to create</param>
        /// <param name="userId">The user it belongs to.</param>
        /// <returns>The home created</returns>
        Task<Home> CreateHome(HomeCreate homeCreate, int userId);

        /// <summary>
        /// Get the home by id.
        /// </summary>
        /// <param name="id">The id to fetch.</param>
        /// <returns>a home object representing home.</returns>
        Task<Home> GetHomeById(int id);

        /// <summary>
        /// Relates a home with a user.
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="homeId">The id of the home</param>
        /// <returns>The relation object between the 2.</returns>
        Task<RelateObject> RelateUserToHome(int userId, int homeId);
    }
}