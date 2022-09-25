using XPowerApi.Interfaces;
using XPowerApi.DbModels;
using XPowerApi.DbModels.SurrealDbModels;
using XPowerApi.Managers;
using XPowerApi.Models.HomeGroupModels;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Providers
{
    public class HomeGroupProvider : IHomeGroupProvider
    {
        private SurrealDbProvider _dbProvider;

        public HomeGroupProvider(IConfiguration configuration)
        {
            _dbProvider = new SurrealDbProvider(configuration);
        }

        public async Task<HomeGroup> CreateHomeGroup(HomeGroupCreate homeGroupCreate)
        {
            // Create HomeGroup DB Object
            Dictionary<string, string> dataArray = new Dictionary<string, string>()
                { { "name", homeGroupCreate.Name }, };
            // Create Db object and Convert to HomeGroup on success
            HomeGroup homeGroup = (await _dbProvider.Create<HomeGroupDb>("homegroup", dataArray)).ConvertToHomeGroup();
            return homeGroup;
        }

        public async Task<HomeGroup> GetHomeGroupById(int id)
        {
            HomeGroup homeGroup = (await _dbProvider.GetOneById<HomeGroupDb>("homegroup", id)).ConvertToHomeGroup();
            return homeGroup;
        }

        public async Task<RelateObject> RelateUserToHomeGroup(int userId, int homeGroupId)
        {
            RelateObject createdRelation = (await _dbProvider.Relate($"user:{userId}", $"homegroup:{homeGroupId}", "usergroups"));
            return createdRelation;
        }
    }
}