using XPowerApi.DbModels.SurrealDbModels;
using XPowerApi.Models.HomeModels;

namespace XPowerApi.Interfaces
{
    public interface IHomeManager
    {
        public Task<Home> CreateHome(HomeCreate homeCreate, int userId);
        public Task<Home> GetHomeById(int id);
        public Task<RelateObject> RelateUserToHome(int userId, int homeId);
    }
}