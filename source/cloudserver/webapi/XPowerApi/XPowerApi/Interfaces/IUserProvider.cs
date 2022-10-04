using XPowerApi.DbModels;

namespace XPowerApi.Interfaces
{
    public interface IUserProvider
    {
        Task<UserDb> CreateUser(Dictionary<string, string> dataArray);

        Task<UserDb> GetUserById(int id);
        Task<UserDb> GetUserByUsername(string username);
    }
}
