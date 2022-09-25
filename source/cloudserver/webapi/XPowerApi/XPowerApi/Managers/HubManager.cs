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

}