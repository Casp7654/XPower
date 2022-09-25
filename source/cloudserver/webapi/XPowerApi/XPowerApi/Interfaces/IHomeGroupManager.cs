using XPowerApi.DbModels.SurrealDbModels;
using XPowerApi.Models.HomeGroupModels;

namespace XPowerApi.Interfaces;

public interface IHomeGroupManager
{
        public Task<HomeGroup> CreateHomeGroup(HomeGroupCreate homeGroupCreate);
        public Task<HomeGroup> GetHomeGroupById(int id);
        public Task<RelateObject> RelateUserToHomeGroup(int userId, int homeGroupId);

}