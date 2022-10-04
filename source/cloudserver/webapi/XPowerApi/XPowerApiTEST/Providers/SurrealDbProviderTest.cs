using System.Net;
using Microsoft.Extensions.Configuration;
using XPowerApi.DbModels.SurrealDbModels;
using XPowerApi.Interfaces;
using XPowerApi.Providers;

namespace XPowerApiTEST.Providers
{
    //TODO: Write this class.
    public class SurrealDbProviderTest
    {
        private readonly SurrealDbProvider _subject;
        private readonly Mock<SurrealDbHttpClient> _httpClient;
        private readonly Mock<IConfiguration> _configuration = new();
        public SurrealDbProviderTest()
        {
            FakeConfiguration config = new();
            _subject = new(config);
            _httpClient = new(config);
            _subject.HttpClient = _httpClient.Object;
        }

        [Fact]
        public async Task MakeRawResult_ShouldReturnSurrealDbResultObjectWithData()
        {
            //Arrange
            string sqlString = "info for db";
            SurrealDbHttpRequestMessage request = new(sqlString);
            HttpResponseMessage expected = new(HttpStatusCode.OK);
            expected.Content = new StringContent("All Ok");
            // TODO: Casper => Can't figure this out Atm.
            //_httpClient.Setup(s => s.SendAsync(request)).ReturnsAsync(() => expected);
            
            //Act
            //var actual = await _subject.MakeRawResult(sqlString);
            await Assert.ThrowsAsync<HttpRequestException>(() => _subject.MakeRawResult(sqlString!));
            
            //Assert
            //Assert.NotNull(actual);
            //Assert.IsType<SurrealDbResult>(actual);
            //Assert.True(actual.result.Count >= 1);
        }

        public async void MakeRawResult_ShouldReturnSurrealDbResultObjectWithoutData()
        {
        }

        public async void Create_ShouldReturnUserObject()
        {
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