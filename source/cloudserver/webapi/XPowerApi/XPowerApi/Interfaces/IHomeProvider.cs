using XPowerApi.DbModels;
using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Interfaces
{
    public interface IHomeProvider
    {
        /// <summary>
        /// Creates a new home by the given data.
        /// Key : Value
        /// </summary>
        /// <param name="dataArray">The data to create from.</param>
        /// <returns>A Homedb model representing data created.</returns>
        public Task<HomeDb> CreateHome(Dictionary<string, string> dataArray);

        /// <summary>
        /// Get home by id.
        /// </summary>
        /// <param name="id">The id to fetch from.</param>
        /// <returns>A homedb model representing home.</returns>
        public Task<HomeDb> GetHomeById(int id);

        /// <summary>
        /// Relates user and home.
        /// </summary>
        /// <param name="userId">The id to relate to.</param>
        /// <param name="homeId">The home to relate to.</param>
        /// <returns>A relation object representing the relation between the 2 specified id's</returns>
        public Task<RelateObject> RelateUserToHome(int userId, int homeId);
    }
}