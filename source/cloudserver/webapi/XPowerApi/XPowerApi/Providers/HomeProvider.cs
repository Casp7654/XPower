using XPowerApi.Interfaces;
using XPowerApi.DbModels;
using XPowerApi.DbModels.SurrealDbModels;
using XPowerApi.Managers;
using XPowerApi.Models.HomeModels;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Providers
{
    public class HomeProvider : IHomeProvider
    {
        private SurrealDbProvider _dbProvider;

        public HomeProvider(IConfiguration configuration)
        {
            _dbProvider = new SurrealDbProvider(configuration);
        }

        public async Task<Home> CreateHome(HomeCreate homeCreate, int userId)
        {
            // Create HomeGroup DB Object
            Dictionary<string, string> dataArray = new Dictionary<string, string>()
                { { "name", homeCreate.Name }, };
            // Create Db object and Convert to HomeGroup on success
            Home home = (await _dbProvider.Create<HomeDb>("home", dataArray)).ConvertToHome();
            RelateObject related = await this.RelateUserToHome(userId, home.Id);

            return home;
        }

        public async Task<Home> GetHomeById(int id)
        {
            Home home = (await _dbProvider.GetOneById<HomeDb>("home", id)).ConvertToHome();
            return home;
        }

        public async Task<RelateObject> RelateUserToHome(int userId, int homeId)
        {
            RelateObject createdRelation = (await _dbProvider.Relate($"user:{userId}", $"home:{homeId}", "homeusers"));
            return createdRelation;
        }
    }
}