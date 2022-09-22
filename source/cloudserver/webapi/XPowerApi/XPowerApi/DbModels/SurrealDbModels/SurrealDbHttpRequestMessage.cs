using System.Net.Http.Headers;

namespace XPowerApi.DbModels.SurrealDbModels;

public class SurrealDbHttpRequestMessage: HttpRequestMessage
{
    public SurrealDbHttpRequestMessage(string dataString): base(HttpMethod.Post, "sql")
    {
        Content = new StringContent(dataString);
        Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
    }
}