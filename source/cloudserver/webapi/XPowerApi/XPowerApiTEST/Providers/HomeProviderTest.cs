using XPowerApi.DbModels;
using XPowerApi.DbModels.SurrealDbModels;
using XPowerApi.Interfaces;
using XPowerApi.Providers;

namespace XPowerApiTEST.Providers
{
    public class HomeProviderTest
    {
        private readonly HomeProvider _subject;
        private readonly Mock<ISurrealDbProvider> _dbProvider = new();

        public HomeProviderTest()
            => _subject = new(_dbProvider.Object);

        [Fact]
        public async void CreateHome_ShouldReturnHomeDbObject()
        {
            //Arrange 
            string tableName = "home";
            Dictionary<string, string> input = new() { { "name", "Home1" } };
            HomeDb expected = new HomeDb() { id = "home:1", name = input["name"] };
            _dbProvider.Setup(s => s.Create<HomeDb>(tableName, input))
                .ReturnsAsync(() => expected);
            //Act
            var actual = await _subject.CreateHome(input);
            //Assert
            Assert.NotNull(actual);
            Assert.IsType<HomeDb>(actual!);
            Assert.True(actual.id == expected.id);
        }

        [Fact]
        public async void GetHomeById_ShouldReturnHomeDbObject()
        {
            //Arrange 
            string tableName = "home";
            int homeId = 1;
            HomeDb expected = new HomeDb() { id = "home:1", name = "Home1" };
            _dbProvider.Setup(s => s.GetOneById<HomeDb>(tableName, homeId))
                .ReturnsAsync(() => expected);
            //Act
            var actual = await _subject.GetHomeById(homeId);
            //Assert
            Assert.NotNull(actual);
            Assert.IsType<HomeDb>(actual!);
            Assert.True(actual.id == expected.id);
        }

        [Fact]
        public async void RelateUserToHome_ShouldReturnRelateObject()
        {
            //Arrange 
            string relateTable = "homeusers";
            int userId = 1;
            int homeId = 1;
            RelateObject expected = new(Id: "", In: $"user:{userId}", Out: $"home:{homeId}");
            _dbProvider.Setup(s => s.Relate(expected.In,expected.Out,relateTable))
                .ReturnsAsync(() => expected);
            //Act
            var actual = await _subject.RelateUserToHome(userId,homeId);
            //Assert
            Assert.NotNull(actual);
            Assert.IsType<RelateObject>(actual!);
            Assert.True(actual.In == expected.In);
            Assert.True(actual.Out == expected.Out);
        }
    }
}