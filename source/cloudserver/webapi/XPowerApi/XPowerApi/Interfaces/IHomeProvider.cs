using XPowerApi.DbModels;
using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Interfaces
{
    public interface IHomeProvider
    {
        public Task<HomeDb> CreateHome(Dictionary<string, string> dataArray);

        public Task<HomeDb> GetHomeById(int id);

        public Task<RelateObject> RelateUserToHome(int userId, int homeId);
    }
}