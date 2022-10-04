using XPowerApi.Models.UserModels;

namespace XPowerApi.Interfaces
{
    public interface IUserManager
    {
        Task<User> CreateUser(UserCreate userCreate);
        Task<User> GetUserById(int id);
        Task<UserCredentials> GetUserCredentialsByUsername(string username);
        Task<UserToken> GetNewUserToken(UserLogin user);
    }
}
