using Moq.Protected;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using XPowerApi.DbModels.SurrealDbModels;
using XPowerApi.Providers;

namespace XPowerApiTEST.Providers
{
    //TODO: Write this class.
    public class SurrealDbProviderTest
    {
        private readonly SurrealDbProvider _subject;
        private readonly HttpClient _httpClient;
        private readonly Mock<HttpMessageHandler> _handler;

        public SurrealDbProviderTest()
        {
            FakeConfiguration config = new();
            _handler = new Mock<HttpMessageHandler>();
            _httpClient = new(_handler.Object);
            _subject = new(_httpClient);
        }

        [Fact]
        public async Task MakeRawResult_ShouldReturnSurrealDbResultObjectWithData()
        {
            //Arrange
            var list = new List<SurrealDbResult>() {new SurrealDbResult()
            {
                time = DateTime.Now.ToString(),
                status = "Ok",
                result = new List<object>() { "" }
            }};
            var expected = JsonSerializer.Serialize(list.First());
            string actual;

            HttpResponseMessage responseMessage = new(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(JsonSerializer.Serialize(list));

            //Act
            _handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(() => responseMessage);
            _httpClient.BaseAddress = new Uri("http://test.dk");


            var actualObj = await _subject.MakeRawResult("");
            actual = JsonSerializer.Serialize(actualObj);
            
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void MakeRawResult_ShouldReturnSurrealDbResultObjectWithoutData()
        {
            //Arrange
            var data = "[]";
            SurrealDbResult expected = null;
            SurrealDbResult actual;

            HttpResponseMessage responseMessage = new(HttpStatusCode.OK);
            responseMessage.Content = new StringContent(data);

            //Act
            _handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(() => responseMessage);
            _httpClient.BaseAddress = new Uri("http://test.dk");


            actual = await _subject.MakeRawResult("");

            //Assert
            Assert.Equal(expected, actual);
        }

        public async void Create_ShouldReturnUserObject()
        {
            // Arrange

            // Act

            // Assert
        }

        public async void Create_ShouldReturnHubObject()
        {
        }

        public async void Create_ShouldReturnHomeObject()
        {
        }

        public async void Relate_ShouldReturnCorrectlyFormattedSurrealQLString()
        {
        }

        public async void GetNextId_ShouldReturnOne()
        {
        }

        public async void GetNextId_ShouldReturnNextId()
        {
        }

        public async void GetOneById_ShouldReturnUserObject()
        {
        }

        public async void GetOneById_ShouldReturnHomeObject()
        {
        }

        public async void GetOneById_ShouldReturnHubObject()
        {
        }

        public async void GetRelation_ShouldReturnRelateObject()
        {
        }

        public async void GetOneFromInsideAnother_ShouldReturnListOfTargetObject()
        {
        }

        public async void GetOneFromInsideARelation_ShouldReturnListOfTargetObject()
        {
        }
    }
}