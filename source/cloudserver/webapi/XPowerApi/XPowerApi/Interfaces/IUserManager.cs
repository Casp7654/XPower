using XPowerApi.DbModels;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Interfaces
{
    public interface IUserManager
    {
        public Task<User> CreateUser(UserCredentials userCreate);

        public Task<bool> ValidateUserCredentials(UserLogin user);
        public Task<User> GetUserById(int id);
        public Task<UserDb> GetUserByUsername(string username);
    }
}
