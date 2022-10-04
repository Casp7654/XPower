using XPowerApi.DbModels;
using XPowerApi.Interfaces;
using XPowerApi.Models.HubModels;

namespace XPowerApi.Managers
{
    public class HubManager : IHubManager
    {
        IHubProvider _hubProvider;

        public HubManager(IHubProvider hubProvider)
        {
            _hubProvider = hubProvider;
        }

        /// <inheridDoc />
        public async Task<Hub> CreateHub(HubCreate hubCreate)
        {
            // Create HomeGroup DB Object
            Dictionary<string, string> dataArray = new Dictionary<string, string>()
            {
                { "name", hubCreate.Name },
                { "mac", hubCreate.Mac },
                { "home", hubCreate.Home },
                { "private_addr", hubCreate.PrivateAddress },
                { "public_addr", hubCreate.PublicAddress }
            };
            return (await _hubProvider.CreateHub(dataArray)).ConvertToHub();
        }

        /// <inheridDoc />
        public async Task<Hub> GetHubById(int id)
        {
            return (await _hubProvider.GetHubById(id)).ConvertToHub();
        }

        /// <inheridDoc />
        public async Task<List<Hub>> GetHubsByHomeId(int homeId)
        {
            List<Hub> hubs = new List<Hub>();
            List<HubDb> hubDbList = await _hubProvider.GetHubsByHomeId(homeId);
            foreach (var hubDb in hubDbList)
                hubs.Add(hubDb.ConvertToHub());
            return hubs;
        }

        /// <inheridDoc />
        public async Task<List<Hub>> GetHubsByUserId(int userId)
        {
            List<Hub> hubs = new List<Hub>();
            List<HubDb> hubDbList = await _hubProvider.GetHubsByUserId(userId);
            foreach (var hubDb in hubDbList)
                hubs.Add(hubDb.ConvertToHub());
            return hubs;
        }
    }
}