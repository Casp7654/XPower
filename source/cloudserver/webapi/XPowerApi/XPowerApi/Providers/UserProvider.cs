using System;
using System.Net.Http;
using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Providers
{
    public class UserProvider : IUserProvider
    {
        private IConfiguration _configuration;
        private HttpClient _httpClient;
        private List<User> users = new List<User>();

        public UserProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_configuration["SurrealDB"]["ConnStr"]);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.User.Add("root:root");
            _httpClient.DefaultRequestHeaders.Add("NS: xpower");
            _httpClient.DefaultRequestHeaders.Add("DB: webapi");
        }

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

        public async Task<User> GetUserByID(int id)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Content = "select * from user";
            HttpResponseMessage response = await _httpClient.SendAs(request);
            Console.WriteLine(response.Content.ToString());

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
