using XPowerApi.DbModels;

namespace XPowerApi.Interfaces
{
    public interface IHubProvider
    {
        /// <summary>
        /// Creates hub from the specified model data.
        /// ex: key : value
        /// </summary>
        /// <param name="dataArray">The data to create the hub from</param>
        /// <returns>A hubdb model representing the data.</returns>
        public Task<HubDb> CreateHub(Dictionary<string, string> dataArray);

        /// <summary>
        /// Get hub by id.
        /// </summary>
        /// <param name="id">The id to fetch from.</param>
        /// <returns>The hubdb representing the data.</returns>
        public Task<HubDb> GetHubById(int id);

        /// <summary>
        /// Get hubdb's by the home id relating to the hub.
        /// </summary>
        /// <param name="homeId">The home id relating to the hub.</param>
        /// <returns>A list of hubdb's, which relates to the home id</returns>
        public Task<List<HubDb>> GetHubsByHomeId(int homeId);

        /// <summary>
        /// Get hubdb's from the userid specified.
        /// </summary>
        /// <param name="userId">The user id to fetch from.</param>
        /// <returns>A list of hubdb's, which relates to the user id.</returns>
        public Task<List<HubDb>> GetHubsByUserId(int userId);
    }
}