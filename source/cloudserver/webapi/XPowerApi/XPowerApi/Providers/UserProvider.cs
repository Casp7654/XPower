using XPowerApi.Interfaces;
using XPowerApi.DbModels;

namespace XPowerApi.Providers
{
    public class UserProvider : IUserProvider
    {
        private SurrealDbProvider _dbProvider;

        public UserProvider(IConfiguration configuration)
        {
            _dbProvider = new SurrealDbProvider(configuration);
        }

        public async Task<UserDb> CreateUser(Dictionary<string,string> dataArray)
        {
            return await _dbProvider.Create<UserDb>("user", dataArray);
        }

        public async Task<UserDb> GetUserById(int id)
        {
            return await _dbProvider.GetOneById<UserDb>("user", id);
        }

        public async Task<UserDb> GetUserByUsername(string username)
        {
            return await _dbProvider.getOneBy
        }
    }
}