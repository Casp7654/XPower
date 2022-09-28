using XPowerApi.Controllers;
using XPowerApi.Interfaces;
using XPowerApi.Models.HubModels;

namespace XPowerApiTEST.Controllers
{
    public class HubControllerTest
    {
        private readonly HubController _subject;
        private readonly Mock<ILogger<HubController>> _logger = new();
        private readonly Mock<IHubManager> _hubManager = new();

        public HubControllerTest()
            => _subject = new(
                _logger.Object,
                _hubManager.Object
            );

        [Fact]
        public async void GetHubById_ShouldReturnHubObject()
        {
            //Arrange
            int hubId = 1;
            _hubManager.Setup(s => s.GetHubById(hubId)).ReturnsAsync(new Hub()
            {
                Id = 1,
                Name = "hub1"
            });

            //Act
            var actual = (await _subject.GetHubById(hubId)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual!);
            Assert.True((actual! as OkObjectResult)!.StatusCode == 200);
            Assert.True(((actual! as OkObjectResult)!.Value as Hub)!.Id == 1);
        }

        [Fact]
        public async void GetHubById_ShouldReturnClientError()
        {
            //Arrange
            int hubId = -1;
            _hubManager.Setup(s => s.GetHubById(hubId)).Throws<ArgumentException>();

            //Act
            var actual = (await _subject.GetHubById(hubId)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual!);
            Assert.True((actual! as BadRequestObjectResult)!.StatusCode == 400);
        }

        [Fact]
        public async void GetHubsByHomeId_ShouldReturnListOfHubs()
        {
            //Arrange
            int homeId = 1;
            _hubManager.Setup(s => s.GetHubsByHomeId(homeId)).ReturnsAsync(
                new List<Hub>() { { new Hub() }, { new Hub() } });

            //Act
            var actual = (await _subject.GetHubsByHomeId(homeId)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual!);
            Assert.True((actual! as OkObjectResult)!.StatusCode == 200);
            Assert.True(((actual! as OkObjectResult)!.Value as List<Hub>)!.Count == 2);
        }
        
        [Fact]
        public async void GetHubsByHomeId_ShouldReturnClientError()
        {
            //Arrange
            int homeId = -1;
            _hubManager.Setup(s => s.GetHubsByHomeId(homeId)).Throws<ArgumentException>();

            //Act
            var actual = (await _subject.GetHubsByHomeId(homeId)).Result;
            
            //Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual!);
            Assert.True((actual! as BadRequestObjectResult)!.StatusCode == 400);
        }

        [Fact]
        public async void GetHubsByUserId_ShouldReturnListOfHubs()
        {
            //Arrange
            int userId = 1;
            _hubManager.Setup(s => s.GetHubsByUserId(userId)).ReturnsAsync(
                new List<Hub>() { { new Hub() }, { new Hub() } });

            //Act
            var actual = (await _subject.GetHubsByUserId(userId)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual!);
            Assert.True((actual! as OkObjectResult)!.StatusCode == 200);
            Assert.True(((actual! as OkObjectResult)!.Value as List<Hub>)!.Count == 2);
        }

        [Fact]
        public async void GetHubsByUserId_ShouldReturnClientError()
        {
            //Arrange
            int userId = -1;
            _hubManager.Setup(s => s.GetHubsByUserId(userId)).Throws<ArgumentException>();

            //Act
            var actual = (await _subject.GetHubsByUserId(userId)).Result;
            
            //Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual!);
            Assert.True((actual! as BadRequestObjectResult)!.StatusCode == 400);
        }
    }
}