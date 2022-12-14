using XPowerApi.Interfaces;
using XPowerApi.DbModels;

namespace XPowerApi.Providers
{
    public class UserProvider : IUserProvider
    {
        ISurrealDbProvider _dbProvider;

        public UserProvider(ISurrealDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }
        
        /// <inheritDoc />
        public async Task<UserDb> CreateUser(Dictionary<string, string> dataArray)
        {
            return await _dbProvider.Create<UserDb>("user", dataArray);
        }
        
        /// <inheritDoc />
        public async Task<UserDb> GetUserById(int id)
        {
            return await _dbProvider.GetOneById<UserDb>("user", id);
        }
        
        /// <inheritDoc />
        public async Task<UserDb> GetUserByUsername(string username)
        {
            return await _dbProvider.GetOneByField<UserDb>("user", "username", username);
        }
    }
}