using XPowerApi.DbModels;

namespace XPowerApi.Interfaces
{
    public interface IUserProvider
    {
        public Task<UserDb> CreateUser(Dictionary<string,string> dataArray);
        
        public Task<UserDb> GetUserById(int id);
        public Task<UserDb> GetUserByUsername(string username);
    }
}
