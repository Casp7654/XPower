using System.Net.Http.Headers;
using System.Text.Json;
using XPowerApi.Interfaces;
using XPowerApi.Models;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Providers
{
    public class UserProvider : IUserProvider
    {
        private SurrealDBHttpClient _httpClient;
        private List<User> _users = new List<User>();

        public UserProvider(IConfiguration configuration)
        {
            _httpClient = new SurrealDBHttpClient(configuration);
        }

        public Task<User> CreateUser(UserCreate userCreate)
        {
            var createdUser = new User() { Id = Random.Shared.Next(4, 150), UserName = userCreate.UserName };
            _users.Add(createdUser);

            return Task.Run(() => createdUser);
        }

        public Task<bool> DeleteUser(int id)
        {
            var user = _users.Find(x => x.Id == id);

            if (user == null)
                return Task.Run(() => false);

            return Task.Run(() => _users.Remove(user));
        }

        public async Task<User> GetUserByID(int id)
        {
            // Set SQL string
            string sqlString = $"select * from user where id = user:{id};";
            // Create RequestMessage
            SurrealDbHttpRequestMessage request = new SurrealDbHttpRequestMessage(sqlString);
            // Get Response
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            string responseJson = await response.Content.ReadAsStringAsync();
            // Debug response
            Console.WriteLine(responseJson);
            // ERR
            if (!response.IsSuccessStatusCode)
                throw new Exception("Could not get data");

            // Create Object
            SurrealDbResult dbResult = SurrealDbResultFactory.MakeResult(responseJson);
            User user = JsonSerializer.Deserialize<User>(JsonSerializer.Serialize(dbResult.result[0]));
            
            return user;
        }

        public Task<User> UpdateUserUsername(int id, string username)
        {
            var user = _users.Find(x => x.Id == id);

            if (user == null)
                return Task.Run(() => user); // because i cant return null :/

            user.UserName = username;

            return Task.Run(() => user);
        }
    }
}