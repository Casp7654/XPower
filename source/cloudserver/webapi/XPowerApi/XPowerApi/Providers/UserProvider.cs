using XPowerApi.Interfaces;
using XPowerApi.DbModels;
using XPowerApi.DbModels.SurrealDbModels;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Providers
{
    public class UserProvider : IUserProvider
    {
        private SurrealDbHttpClient _httpClient;
        private List<User> _users = new List<User>();

        public UserProvider(IConfiguration configuration)
        {
            _httpClient = new SurrealDbHttpClient(configuration);
        }

        public async Task<int> GetNextUserId()
        {
            // Set SQL string
            string sqlString = $"select id from user order by id desc limit 1;";
            // Create RequestMessage
            SurrealDbHttpRequestMessage request = new SurrealDbHttpRequestMessage(sqlString);
            // Get Response
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            string responseJson = await response.Content.ReadAsStringAsync();
            // Debug response
            //Console.WriteLine(responseJson);
            // ERR
            if (!response.IsSuccessStatusCode)
                throw new Exception("Could not get data");

            // Create Object
            int id = SurrealDbResultFactory.GetIdFromResult(responseJson);
            return (id != 0) ? id + 1 : -1;
        }

        public async Task<User> CreateUser(UserCreate userCreate)
        {
            int id = await GetNextUserId();
            string sqlString =
                $"insert into user {{id:{id},username:\"{userCreate.UserName}\",hashed_password:\"{userCreate.Password}\"}}";

            return new User();
        }

        public Task<bool> DeleteUser(int id)
        {
            var user = _users.Find(x => x.Id == id);

            if (user == null)
                return Task.Run(() => false);

            return Task.Run(() => _users.Remove(user));
        }

        public async Task<User> GetUserById(int id)
        {
            // Set SQL string
            string sqlString = $"select * from user where id = user:{id};";
            // Create RequestMessage
            SurrealDbHttpRequestMessage request = new SurrealDbHttpRequestMessage(sqlString);
            // Get Response
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            string responseJson = await response.Content.ReadAsStringAsync();
            // Debug response
            //Console.WriteLine(responseJson);
            // ERR
            if (!response.IsSuccessStatusCode)
                throw new Exception("Could not get data");

            // Create Object
            User user = SurrealDbResultFactory.MakeOne<UserDb>(responseJson).ConvertToUser();
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