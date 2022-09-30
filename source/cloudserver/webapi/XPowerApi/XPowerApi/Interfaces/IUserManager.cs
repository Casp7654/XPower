using XPowerApi.Models.UserModels;

namespace XPowerApi.Interfaces
{
    public interface IUserManager
    {
        public Task<User> CreateUser(UserCreate userCreate);
        public Task<User> GetUserById(int id);
    }
}
