using XPowerApi.DbModels;
using XPowerApi.Interfaces;
using XPowerApi.Providers;

namespace XPowerApiTEST.Providers
{
    public class HubProviderTest
    {
        private readonly HubProvider _subject;
        private readonly Mock<ISurrealDbProvider> _dbProvider = new();

        public HubProviderTest()
            => _subject = new(_dbProvider.Object);
        
        [Fact]
        public async void CreateHub_ShouldReturnHubDbObject()
        {
            //Arrange 
            string tableName = "hub";
            Dictionary<string, string> input = new() { { "name", "Hub1" } };
            HubDb expected = new HubDb() { id = "hub:1", name = input["name"] };
            _dbProvider.Setup(s => s.Create<HubDb>(tableName, input))
                .ReturnsAsync(() => expected);
            //Act
            var actual = await _subject.CreateHub(input);
            //Assert
            Assert.NotNull(actual);
            Assert.IsType<HubDb>(actual!);
            Assert.True(actual.id == expected.id);
        }

        [Fact]
        public async void GetHubById_ShouldReturnHubDbObject()
        {
            //Arrange 
            string tableName = "hub";
            int hubId = 1;
            HubDb expected = new HubDb() { id = "hub:1", name = "Hub1" };
            _dbProvider.Setup(s => s.GetOneById<HubDb>(tableName, hubId))
                .ReturnsAsync(() => expected);
            //Act
            var actual = await _subject.GetHubById(hubId);
            //Assert
            Assert.NotNull(actual);
            Assert.IsType<HubDb>(actual!);
            Assert.True(actual.id == expected.id);
        }

        [Fact]
        public async void GetHubsByHomeId_ShouldReturnListOfTargetObject()
        {
            //Arrange 
            int homeId = 1;
            string tableName = "hub";
            string baseTable = "home";
            string targetId = $"home:{homeId}";
            List<HubDb> expected = new List<HubDb>() { new HubDb(), new HubDb() };
            _dbProvider.Setup(s => s.GetOneFromInsideAnother<HubDb>(tableName,baseTable,targetId))
                .ReturnsAsync(() => expected);
            //Act
            var actual = await _subject.GetHubsByHomeId(homeId);
            //Assert
            Assert.NotNull(actual);
            Assert.IsType<List<HubDb>>(actual!);
            Assert.True((actual as List<HubDb>).Count == 2);
        }

        [Fact]
        public async void GetHubsByUserId_ShouldReturnListOfTargetObject()
        {
            //Arrange 
            int userId = 1;
            string tableName = "hub";
            string baseTable = "home";
            string relationTable = "homeusers";
            string targetId = $"user:{userId}";
            List<HubDb> expected = new List<HubDb>() { new HubDb(), new HubDb() };
            _dbProvider.Setup(s => s.GetOneFromInsideARelation<HubDb>(tableName,baseTable,relationTable,targetId))
                .ReturnsAsync(() => expected);
            //Act
            var actual = await _subject.GetHubsByUserId(userId);
            //Assert
            Assert.NotNull(actual);
            Assert.IsType<List<HubDb>>(actual!);
            Assert.True((actual as List<HubDb>).Count == 2);
        }
    }
}