using XPowerApi.Interfaces;
using XPowerApi.Models.HomeModels;
using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Managers
{
    public class HomeManager : IHomeManager
    {
        IHomeProvider _homeProvider;

        public HomeManager(IHomeProvider homeProvider)
        {
            _homeProvider = homeProvider;
        }

        public async Task<Home> CreateHome(HomeCreate homeCreate, int userId)
        {
            // Convert Home to DB Object
            Dictionary<string, string> dataArray = new Dictionary<string, string>() { { "name", homeCreate.Name }, };
            return (await _homeProvider.CreateHome(dataArray, userId)).ConvertToHome();
        }

        public async Task<Home> GetHomeById(int id)
        {
            return (await _homeProvider.GetHomeById(id)).ConvertToHome();
        }

        public async Task<RelateObject> RelateUserToHome(int userId, int homeId)
        {
            return (await _homeProvider.RelateUserToHome(userId, homeId));
        }
    }
}