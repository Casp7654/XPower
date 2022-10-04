using System.Text;
using System.Net.Http.Headers;
using XPowerApi.Interfaces;

namespace XPowerApi.DbModels.SurrealDbModels
{
    public class SurrealDbHttpClient : HttpClient
    {
        public SurrealDbHttpClient(IConfiguration configuration) : base()
        {
            BaseAddress = new Uri(configuration["SurrealDB:ConnStr"]);
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string authBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(configuration["SurrealDB:User"]));
            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authBase64);
            DefaultRequestHeaders.Add("NS", configuration["SurrealDB:Namespace"]);
            DefaultRequestHeaders.Add("DB", configuration["SurrealDB:Database"]);
        }
    }
}