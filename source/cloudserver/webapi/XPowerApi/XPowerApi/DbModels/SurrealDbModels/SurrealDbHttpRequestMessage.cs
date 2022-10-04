using System.Net.Http.Headers;

namespace XPowerApi.DbModels.SurrealDbModels
{
    public class SurrealDbHttpRequestMessage : HttpRequestMessage
    {
        /// <summary>
        /// Constructor for creating the message request for surrealDB
        /// </summary>
        /// <param name="dataString">The data to send to surrealdb, in json</param>
        public SurrealDbHttpRequestMessage(string dataString) : base(HttpMethod.Post, "sql")
        {
            Content = new StringContent(dataString);
            Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        }
    }
}