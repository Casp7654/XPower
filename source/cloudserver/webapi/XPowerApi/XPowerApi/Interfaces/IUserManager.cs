using XPowerApi.Models.UserModels;

namespace XPowerApi.Interfaces
{
    public interface IUserManager
    {
        public Task<User> CreateUser(UserCreate userCreate);
        public Task<bool> ValidateUserCredentials(User user);
        public Task<User> GetUserById(int id);
        public Task<User> GetUserByUsername(string username);
    }
}
