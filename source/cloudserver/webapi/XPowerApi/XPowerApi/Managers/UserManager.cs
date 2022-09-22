using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Managers
{
    public class UserManager : IUserManager
    {
       IUserProvider _userProvider;

        public UserManager(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public Task<User> CreateUser(UserCreate userCreate)
        {
            return Task.Run(() => _userProvider.CreateUser(userCreate));
        }

        public Task<bool> DeleteUser(int id)
        {
            return Task.Run(() => _userProvider.DeleteUser(id));
        }

        public Task<User> GetUserById(int id)
        {
            return Task.Run(() => _userProvider.GetUserById(id));
        }

        public Task<User> UpdateUserUsername(int id, string username)
        {
            return Task.Run(() => _userProvider.UpdateUserUsername(id, username));
        }
    }
}
