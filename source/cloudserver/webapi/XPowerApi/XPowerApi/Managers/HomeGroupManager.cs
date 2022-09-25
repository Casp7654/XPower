using XPowerApi.Interfaces;
using XPowerApi.Models.HomeGroupModels;
using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Managers;

public class HomeGroupManager : IHomeGroupManager
{
    IHomeGroupProvider _homeGroupProvider;

    public HomeGroupManager(IHomeGroupProvider homeGroupProvider)
    {
        _homeGroupProvider = homeGroupProvider;
    }

    public Task<HomeGroup> CreateHomeGroup(HomeGroupCreate homeGroupCreate)
    {
        return Task.Run(() => _homeGroupProvider.CreateHomeGroup(homeGroupCreate));
    }

    public Task<HomeGroup> GetHomeGroupById(int id)
    {
        return Task.Run(() => _homeGroupProvider.GetHomeGroupById(id));
    }

    public Task<RelateObject> RelateUserToHomeGroup(int userId, int homegroupId)
    {
        return Task.Run(() => _homeGroupProvider.RelateUserToHomeGroup(userId, homegroupId));
    }
}