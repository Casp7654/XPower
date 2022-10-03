using XPowerApi.DbModels;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Interfaces
{
    public interface IUserManager
    {
        public Task<User> CreateUser(UserCreate userCreate);
        public Task<string> GetNewUserToken(UserLogin user);
        public Task<User> GetUserById(int id);
        public Task<UserCredentials> GetUserCredentialsByUsername(string username);
    }
}
