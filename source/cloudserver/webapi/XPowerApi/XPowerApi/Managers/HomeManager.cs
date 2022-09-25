using XPowerApi.Interfaces;
using XPowerApi.Models.HomeModels;
using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Managers;

public class HomeManager : IHomeManager
{
    IHomeProvider _homeProvider;

    public HomeManager(IHomeProvider homeProvider)
    {
        _homeProvider = homeProvider;
    }

    public Task<Home> CreateHome(HomeCreate homeCreate)
    {
        return Task.Run(() => _homeProvider.CreateHome(homeCreate));
    }

    public Task<Home> GetHomeById(int id)
    {
        return Task.Run(() => _homeProvider.GetHomeById(id));
    }

    public Task<RelateObject> RelateUserToHome(int userId, int homeId)
    {
        return Task.Run(() => _homeProvider.RelateUserToHome(userId, homeId));
    }
}