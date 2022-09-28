using XPowerApi.DbModels;
using XPowerApi.DbModels.SurrealDbModels;
using XPowerApi.Interfaces;
using XPowerApi.Managers;
using XPowerApi.Models.HomeModels;

namespace XPowerApiTEST.Managers
{
    public class HomeManagerTest
    {
        private readonly HomeManager _subject;
        private readonly Mock<IHomeProvider> _homeProvider = new();

        public HomeManagerTest()
            => _subject = new(_homeProvider.Object);

        [Fact]
        public async void CreateHome_ShouldReturnHomeObject()
        {
            //Arrange
            HomeCreate input = new() { Name = "Home1" };
            Dictionary<string, string> dataArray = new() { { "name", input.Name } };
            HomeDb expected = new HomeDb() { id = "home:1", name = "Home1" };
            int userId = 1;
            _homeProvider.Setup(s => s.CreateHome(dataArray, userId)) 
                .ReturnsAsync(() => expected);

            //Act
            var home = (await _subject.CreateHome(input, userId));

            //Assert
            Assert.NotNull(home);
            Assert.IsType<Home>(home);
            Assert.NotEmpty((home as Home)!.Name);
            Assert.True((home as Home)!.Name == input.Name);
        }

        [Fact]
        public async void GetHomeById_ShouldReturnHomeObject()
        {
            //Arrange
            HomeDb expected = new HomeDb() { id = "home:1", name = "Home1" };
            int homeId = 1;
            _homeProvider.Setup(s => s.GetHomeById(homeId))
                .ReturnsAsync(() => expected);

            //Act
            var home = (await _subject.GetHomeById(homeId));

            //Assert
            Assert.NotNull(home);
            Assert.IsType<Home>(home);
            Assert.NotEmpty((home as Home)!.Name);
            Assert.True((home as Home)!.Name == expected.name);
        }
        
        [Fact]
        public async void RelateUserToHome_ShouldReturnRelateObject()
        {
            //Arrange
            int userId = 1;
            int homeId = 1;
            RelateObject expected = new(Id: "TestId", In :$"user:{userId}", Out : $"home:{homeId}");
            _homeProvider.Setup(s => s.RelateUserToHome(userId,homeId))
                .ReturnsAsync(() => expected);

            //Act
            var home = (await _subject.RelateUserToHome(userId,homeId));

            //Assert
            Assert.NotNull(home);
            Assert.IsType<RelateObject>(home);
            Assert.NotEmpty((home as RelateObject)!.Id);
            Assert.NotEmpty((home as RelateObject)!.In);
            Assert.NotEmpty((home as RelateObject)!.Out);
            Assert.True((home as RelateObject)!.Id == expected.Id);
        }
    }
}