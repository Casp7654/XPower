using XPowerApi.Interfaces;
using XPowerApi.DbModels;
using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Providers
{
    public class HomeProvider : IHomeProvider
    {
        private SurrealDbProvider _dbProvider;

        public HomeProvider(IConfiguration configuration)
        {
            _dbProvider = new SurrealDbProvider(configuration);
        }

        public async Task<HomeDb> CreateHome(Dictionary<string, string> dataArray, int userId)
        {
            // Create Home in DB
            HomeDb home = await _dbProvider.Create<HomeDb>("home", dataArray);
            // Create User Relation on created home
            RelateObject related = await this.RelateUserToHome(userId, Int32.Parse(home.id.Split(':')[1]));
            return home;
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