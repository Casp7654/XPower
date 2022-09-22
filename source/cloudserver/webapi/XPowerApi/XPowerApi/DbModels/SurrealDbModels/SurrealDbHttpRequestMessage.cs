namespace XPowerApi.Models;
using System.Net.Http;
using System.Net.Http.Headers;

public class SurrealDbHttpRequestMessage: HttpRequestMessage
{
    public SurrealDbHttpRequestMessage(string dataString): base(HttpMethod.Post, "sql")
    {
        this.Content = new StringContent(dataString);
        this.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
    }
}