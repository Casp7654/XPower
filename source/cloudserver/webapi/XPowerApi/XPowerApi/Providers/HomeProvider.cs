using XPowerApi.Interfaces;
using XPowerApi.DbModels;
using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Providers
{
    public class HomeProvider : IHomeProvider
    {
        private ISurrealDbProvider _dbProvider;

        public HomeProvider(ISurrealDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        public async Task<HomeDb> CreateHome(Dictionary<string, string> dataArray)
        {
            return (await _dbProvider.Create<HomeDb>("home", dataArray));
        }

        public async Task<HomeDb> GetHomeById(int id)
        {
            return (await _dbProvider.GetOneById<HomeDb>("home", id));
        }

        public async Task<RelateObject> RelateUserToHome(int userId, int homeId)
        {
            return (await _dbProvider.Relate($"user:{userId}", $"home:{homeId}", "homeusers"));
        }
    }
}