using XPowerApi.Interfaces;
using XPowerApi.DbModels;
using XPowerApi.DbModels.SurrealDbModels;
using XPowerApi.Managers;
using XPowerApi.Models.HubModels;
using XPowerApi.Models.UserModels;
using XPowerApi.Models.HomeModels;

namespace XPowerApi.Providers
{
    public class HubProvider : IHubProvider
    {
        private SurrealDbProvider _dbProvider;

        public HubProvider(IConfiguration configuration)
        {
            _dbProvider = new SurrealDbProvider(configuration);
        }

        public async Task<Hub> CreateHub(HubCreate hubCreate)
        {
            // Create HomeGroup DB Object
            Dictionary<string, string> dataArray = new Dictionary<string, string>()
                { { "name", hubCreate.Name }, };
            // Create Db object and Convert to HomeGroup on success
            Hub hub = (await _dbProvider.Create<HubDb>("hub", dataArray)).ConvertToHub();
            return hub;
        }

        public async Task<Hub> GetHubById(int id)
        {
            Hub hub = (await _dbProvider.GetOneById<HubDb>("home", id)).ConvertToHub();
            return hub;
        }
        
        public async Task<List<Hub>> GetHubsByHomeId(int homeid)
        {
            List<Hub> hubs = new List<Hub>();
            List<HubDb> dbHubList = (await _dbProvider.GetOneFromInsideAnother<HubDb>("hub", "home", $"home:{homeid}"));
            foreach (var hubDb in dbHubList)
                hubs.Add(hubDb.ConvertToHub());
            return hubs;
        }
        
        public async Task<List<Hub>> GetHubsByUserId(int userid)
        {
            List<Hub> hubs = new List<Hub>();
            List<HubDb> dbHubList = (await _dbProvider.GetOneFromInsideARelation<HubDb>("hub", "home", "homeusers",$"user:{userid}"));
            foreach (var hubDb in dbHubList)
                hubs.Add(hubDb.ConvertToHub());
            return hubs;
        }
    }
}