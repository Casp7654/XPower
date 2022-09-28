using XPowerApi.Controllers;
using XPowerApi.Interfaces;
using XPowerApi.Models.HomeModels;

namespace XPowerApiTEST.Controllers
{
    public class HomeCreationControllerTest
    {
        private readonly HomeCreationController _subject;
        private readonly Mock<ILogger<HomeCreationController>> _logger = new();
        private readonly Mock<IHomeManager> _homeManager = new();

        public HomeCreationControllerTest()
            => _subject = new(
                _logger.Object,
                _homeManager.Object
            );

        [Fact]
        public async void CreateHub_ShouldReturnHubObject()
        {
            //Arrange
            HomeCreate input = new() { Name = "hub1" };
            int userId = 1;
            _homeManager.Setup(s => s.CreateHome(input,userId)).ReturnsAsync(new Home());

            //Act
            var actual = (await _subject.CreateHome(input,userId)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual!);
            Assert.True((actual! as OkObjectResult)!.StatusCode == 200);
        }

        [Fact]
        public async void CreateHub_ShouldFailClientError()
        {
            //Arrange
            HomeCreate input = new();
            int userId = -1;
            _homeManager.Setup(s => s.CreateHome(input,userId)).ReturnsAsync(new Home());

            //Act
            var actual = (await _subject.CreateHome(input,userId)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual!);
            Assert.True((actual! as BadRequestObjectResult)!.StatusCode == 400);
        }
    }
}