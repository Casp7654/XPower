using XPowerApi.DbModels;

namespace XPowerApi.Interfaces
{
    public interface IHubProvider
    {
        public Task<HubDb> CreateHub(Dictionary<string, string> dataArray);

        public Task<HubDb> GetHubById(int id);

        public Task<List<HubDb>> GetHubsByHomeId(int homeid);

        public Task<List<HubDb>> GetHubsByUserId(int userid);
    }
}