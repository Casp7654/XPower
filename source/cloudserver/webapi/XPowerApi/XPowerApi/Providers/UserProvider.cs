using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Providers
{
    public class UserProvider : IUserProvider
    {
        List<User> users = new List<User>()
        {
            new User() { Id = 0, UserName = "Jon"},
            new User() { Id = 1, UserName = "Tron"},
            new User() { Id = 2, UserName = "Aaron"},
        };

        public Task<User> CreateUser(UserCreate userCreate)
        {
            var createdUser = new User() { Id = Random.Shared.Next(4, 150), UserName = userCreate.UserName };
            users.Add(createdUser);

            return Task.Run(() => createdUser);
        }

        public Task<bool> DeleteUser(int id)
        {
            var user = users.Find(x => x.Id == id);

            if (user == null)
                return Task.Run(() => false);

            return Task.Run(() => users.Remove(user));
        }

        public Task<User> GetUserByID(int id)
        {
            return Task.Run(() => users.Find(x => x.Id == id));
        }

        public Task<User> UpdateUserUsername(int id, string username)
        {
            var user = users.Find(x => x.Id == id);

            if (user == null)
                return Task.Run(() => user); // because i cant return null :/

            user.UserName = username;

            return Task.Run(() => user);
        }
    }
}
