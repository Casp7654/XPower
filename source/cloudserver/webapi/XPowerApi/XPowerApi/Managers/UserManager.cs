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

        public Task<User> GetUserById(int id)
        {
            return Task.Run(() => _userProvider.GetUserById(id));
        }

    }
}
