using XPowerApi.Interfaces;
using XPowerApi.DbModels;

namespace XPowerApi.Providers
{
    public class HubProvider : IHubProvider
    {
        private SurrealDbProvider _dbProvider;

        public HubProvider(IConfiguration configuration)
        {
            _dbProvider = new SurrealDbProvider(configuration);
        }

        public async Task<HubDb> CreateHub(Dictionary<string, string> dataArray)
        {
            return await _dbProvider.Create<HubDb>("hub", dataArray);
        }

        public async Task<HubDb> GetHubById(int id)
        {
            return await _dbProvider.GetOneById<HubDb>("home", id);
        }

        public async Task<List<HubDb>> GetHubsByHomeId(int homeid)
        {
            return await _dbProvider.GetOneFromInsideAnother<HubDb>("hub", "home", $"home:{homeid}");
        }

        public async Task<List<HubDb>> GetHubsByUserId(int userid)
        {
            return await _dbProvider.GetOneFromInsideARelation<HubDb>("hub", "home", "homeusers", $"user:{userid}");
        }
    }
}