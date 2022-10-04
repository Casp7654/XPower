using XPowerApi.Models.UserModels;

namespace XPowerApi.Interfaces
{
    public interface IUserManager
    {
        public Task<User> CreateUser(UserCreate userCreate);
        public Task<User> UpdateUserUsername(int id, string username);
        public Task<User> GetUserByID(int id);
        public Task<bool> DeleteUser(int id);
    }
}
