using XPowerApi.DbModels;
using XPowerApi.Interfaces;
using XPowerApi.Managers;
using XPowerApi.Models.HubModels;

namespace XPowerApiTEST.Managers
{
    public class HubManagerTest
    {
        private readonly HubManager _subject;
        private readonly Mock<IHubProvider> _hubProvider = new();

        public HubManagerTest()
            => _subject = new HubManager(_hubProvider.Object);

        [Fact]
        public async void CreateHub_ShouldReturnHubObject()
        {
            //Arrange
            HubCreate input = new() { Name = "Home1", Mac = "FF:FF:FF:FF:FF:FF", Home = "Home1" };
            Dictionary<string, string> dataArray = new() { { "name", input.Name } };
            HubDb expected = new() { id = "hub:1", name = input.Name, mac = input.Mac, home = input.Home };
            _hubProvider.Setup(s => s.CreateHub(dataArray))
                .ReturnsAsync(() => expected);

            //Act
            var actual = (await _subject.CreateHub(input));

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<Hub>(actual);
            Assert.NotEmpty((actual as Hub)!.Name);
            Assert.True((actual as Hub)!.Name == input.Name);
        }

        [Fact]
        public async void GetHubById_ShouldReturnHubObject()
        {
            //Arrange
            int hubId = 1;
            HubDb expected = new() { id = $"hub:{hubId}", name = "Hub1", mac = "FF:FF:FF:FF:FF:FF", home = "Home1" };
            _hubProvider.Setup(s => s.GetHubById(hubId))
                .ReturnsAsync(() => expected);

            //Act
            var actual = (await _subject.GetHubById(hubId));

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<Hub>(actual);
            Assert.True((actual as Hub)!.Id == expected.ConvertToHub().Id);
        }
        
        [Fact]
        public async void GetHubsByHomeId_ShouldReturnListOfHubObjects()
        {
            //Arrange
            int homeId = 1;
            List<HubDb> expected = new() { { new HubDb(){id = "hub:1"} }, { new HubDb(){id = "hub:2"} } };
            _hubProvider.Setup(s => s.GetHubsByHomeId(homeId))
                .ReturnsAsync(() => expected);

            //Act
            var actual = (await _subject.GetHubsByHomeId(homeId));

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<List<Hub>>(actual);
            Assert.True((actual as List<Hub>)!.Count == 2);
        }
        
        [Fact]
        public async void GetHubsByUserId_ShouldReturnListOfHubObjects()
        {
            //Arrange
            int userId = 1;
            List<HubDb> expected = new() { { new HubDb(){id = "hub:1"} }, { new HubDb(){id = "hub:2"} } };
            _hubProvider.Setup(s => s.GetHubsByUserId(userId))
                .ReturnsAsync(() => expected);

            //Act
            var actual = (await _subject.GetHubsByUserId(userId));

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<List<Hub>>(actual);
            Assert.True((actual as List<Hub>)!.Count == 2);
        }
        
    }
}