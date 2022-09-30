using XPowerApi.Interfaces;
using XPowerApi.DbModels;

namespace XPowerApi.Providers
{
    public class HubProvider : IHubProvider
    {
        private ISurrealDbProvider _dbProvider;

        public HubProvider(ISurrealDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        public async Task<HubDb> CreateHub(Dictionary<string, string> dataArray)
        {
            return await _dbProvider.Create<HubDb>("hub", dataArray);
        }

        public async Task<HubDb> GetHubById(int id)
        {
            return await _dbProvider.GetOneById<HubDb>("hub", id);
        }

        public async Task<List<HubDb>> GetHubsByHomeId(int homeId)
        {
            return await _dbProvider.GetOneFromInsideAnother<HubDb>("hub", "home", $"home:{homeId}");
        }

        public async Task<List<HubDb>> GetHubsByUserId(int userId)
        {
            return await _dbProvider.GetOneFromInsideARelation<HubDb>("hub", "home", "homeusers", $"user:{userId}");
        }
    }
}