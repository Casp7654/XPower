using System.Net.Http.Headers;
using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Providers
{
    public class UserProvider : IUserProvider
    {
        private HttpClient _httpClient;
        private List<User> _users = new List<User>();

        public UserProvider(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(configuration["SurrealDBConnStr"]);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("root:root");
            _httpClient.DefaultRequestHeaders.Add("NS:","xpower");
            _httpClient.DefaultRequestHeaders.Add("DB:","webapi");
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
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.Content = new StringContent("select * from user");
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            Console.WriteLine(response.Content.ToString());

            return await Task.Run(() => _users.Find(x => x.Id == id));
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
