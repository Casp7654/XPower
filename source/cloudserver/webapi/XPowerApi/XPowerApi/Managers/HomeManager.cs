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
            Home home = (await _homeProvider.CreateHome(dataArray)).ConvertToHome();
            // Create User Relation on created home
            RelateObject related = (await _homeProvider.RelateUserToHome(userId, home.Id));
            return home;
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