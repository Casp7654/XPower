using System.Net.Http.Headers;
using XPowerApi.Interfaces;
using XPowerApi.Models;
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
            _httpClient.BaseAddress = new Uri(configuration["SurrealDB:ConnStr"]);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Basic", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(configuration["SurrealDB:User"])));
            _httpClient.DefaultRequestHeaders.Add("NS",configuration["SurrealDB:Namespace"]);
            _httpClient.DefaultRequestHeaders.Add("DB",configuration["SurrealDB:Database"]);
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
            // Debug response
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            // ERR
            if (!response.IsSuccessStatusCode)
                throw new Exception("Could not get data");
            
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
