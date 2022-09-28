using XPowerApi.Controllers;
using XPowerApi.Interfaces;
using XPowerApi.Models.HomeModels;

namespace XPowerApiTEST.Controllers
{
    public class HomeControllerTest
    {
        private readonly HomeController _subject;
        private readonly Mock<ILogger<HomeController>> _logger = new();
        private readonly Mock<IHomeManager> _homeManager = new();

        public HomeControllerTest()
            => _subject = new(
                _logger.Object,
                _homeManager.Object
            );

        [Fact]
        public async void GetHomeById_ShouldReturnHomeObject()
        {
            //Arrange
            int homeId = 1;
            _homeManager.Setup(s => s.GetHomeById(homeId)).ReturnsAsync(new Home()
            {
                Id = 1,
                Name = "home1",
            });

            //Act
            var actual = (await _subject.GetHomeById(homeId)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual!);
            Assert.True((actual! as OkObjectResult)!.StatusCode == 200);
            Assert.True(((actual! as OkObjectResult)!.Value as Home)!.Id == 1);
        }

        [Fact]
        public async void GetHomeById_ShouldReturnClientError()
        {
            //Arrange
            int homeId = -1;
            _homeManager.Setup(s => s.GetHomeById(homeId)).Throws<ArgumentException>();

            //Act
            var actual = (await _subject.GetHomeById(homeId)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual!);
            Assert.True((actual! as BadRequestObjectResult)!.StatusCode == 400);
        }
    }
}