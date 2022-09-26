using XPowerApi.Interfaces;
using XPowerApi.Models.HubModels;
using XPowerApi.DbModels.SurrealDbModels;

namespace XPowerApi.Managers;

public class HubManager : IHubManager
{
    IHubProvider _hubProvider;

    public HubManager(IHubProvider hubProvider)
    {
        _hubProvider = hubProvider;
    }

    public Task<Hub> CreateHub(HubCreate hubCreate)
    {
        return Task.Run(() => _hubProvider.CreateHub(hubCreate));
    }

    public Task<Hub> GetHubById(int id)
    {
        return Task.Run(() => _hubProvider.GetHubById(id));
    }

    public Task<List<Hub>> GetHubsByHomeId(int homeId)
    {
        return Task.Run(() => _hubProvider.GetHubsByHomeId(homeId));
    }

    public Task<List<Hub>> GetHubsByUserId(int userId)
    {
        return Task.Run(() => _hubProvider.GetHubsByHomeId(userId));
    }
}