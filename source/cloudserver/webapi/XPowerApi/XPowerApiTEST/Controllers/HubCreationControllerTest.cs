using XPowerApi.Controllers;
using XPowerApi.Interfaces;
using XPowerApi.Models.HubModels;

namespace XPowerApiTEST.Controllers
{
    public class HubCreationControllerTest
    {
        private readonly HubCreationController _subject;
        private readonly Mock<ILogger<HubCreationController>> _logger = new();
        private readonly Mock<IHubManager> _hubManager = new();

        public HubCreationControllerTest()
            => _subject = new(
                _logger.Object,
                _hubManager.Object
            );

        [Fact]
        public async void CreateHub_ShouldReturnHubObject()
        {
            //Arrange
            HubCreate input = new()
            {
                Home = "home1",
                Mac = "FF:FF:FF:FF:FF:FF",
                Name = "hub1",
                PrivateAddress = "127.0.0.1",
                PublicAddress = "127.0.0.1"
            };
            _hubManager.Setup(s => s.CreateHub(input)).ReturnsAsync(new Hub());

            //Act
            var actual = (await _subject.CreateHub(input)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual!);
            Assert.True((actual! as OkObjectResult)!.StatusCode == 200);
        }

        [Fact]
        public async void CreateHub_ShouldFailClientError()
        {
            //Arrange
            HubCreate input = new();
            _hubManager.Setup(s => s.CreateHub(input)).ReturnsAsync(new Hub());

            //Act
            var actual = (await _subject.CreateHub(input)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual!);
            Assert.True((actual! as BadRequestObjectResult)!.StatusCode == 400);
        }
    }
}