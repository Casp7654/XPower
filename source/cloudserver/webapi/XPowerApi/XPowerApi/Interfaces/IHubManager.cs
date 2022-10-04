using XPowerApi.Models.HubModels;

namespace XPowerApi.Interfaces
{
    public interface IHubManager
    {
        /// <summary>
        /// Creates hub from the specified model data.
        /// </summary>
        /// <param name="hubCreate">The hub data to create from</param>
        /// <returns>A hub model representing the data.</returns>
        public Task<Hub> CreateHub(HubCreate hubCreate);

        /// <summary>
        /// Get {model} by id.
        /// </summary>
        /// <param name="id">The id to fetch from.</param>
        /// <returns>The hub representing the data.</returns>
        public Task<Hub> GetHubById(int id);

        /// <summary>
        /// Get hubs by the home id relating to the hub.
        /// </summary>
        /// <param name="homeId">The home id relating to the hub.</param>
        /// <returns>A list of hubs, which relates to the home id</returns>
        public Task<List<Hub>> GetHubsByHomeId(int homeId);

        /// <summary>
        /// Get hubs from the userid specified.
        /// </summary>
        /// <param name="userId">The user id to fetch from.</param>
        /// <returns>A list of hubs, which relates to the user id.</returns>
        public Task<List<Hub>> GetHubsByUserId(int userId);
    }
}