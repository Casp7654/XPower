using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace XPowerApi.Models;

public class SurrealDBHttpClient: HttpClient
{

    public SurrealDBHttpClient(IConfiguration configuration) : base()
    {
        this.BaseAddress = new Uri(configuration["SurrealDB:ConnStr"]);
        AuthenticationHeaderValue auth = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.UTF8.GetBytes(configuration["SurrealDB:User"])));
        this.DefaultRequestHeaders.Clear();
        this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        this.DefaultRequestHeaders.Authorization = auth;
        this.DefaultRequestHeaders.Add("NS", configuration["SurrealDB:Namespace"]);
        this.DefaultRequestHeaders.Add("DB", configuration["SurrealDB:Database"]);
    }
}