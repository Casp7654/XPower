using XPowerApi.DbModels.SurrealDbModels;
using XPowerApi.Models.HubModels;

namespace XPowerApi.Interfaces;

public interface IHubManager
{
        public Task<Hub> CreateHub(HubCreate hubCreate);
        public Task<Hub> GetHubById(int id);
        public Task<List<Hub>> GetHubsByHomeId(int homeId);
        public Task<List<Hub>> GetHubsByUserId(int userId);
}