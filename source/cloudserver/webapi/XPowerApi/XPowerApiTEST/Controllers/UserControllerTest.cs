using XPowerApi.Controllers;
using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;

namespace XPowerApiTEST.Controllers
{
    public class UserControllerTest
    {
        private readonly UserController _subject;
        private readonly Mock<ILogger<UserController>> _logger = new();
        private readonly Mock<IUserManager> _userManager = new();

        public UserControllerTest()
            => _subject = new(
                _logger.Object,
                _userManager.Object
            );

        [Fact]
        public async void GetUserById_ShouldReturnUserObject()
        {
            //Arrange
            int userId = 1;
            _userManager.Setup(s => s.GetUserById(userId)).ReturnsAsync(new User()
            {
                Id = 1,
                UserName = "UnitTest",
            });

            //Act
            var actual = (await _subject.GetUserById(userId)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual!);
            Assert.True((actual! as OkObjectResult)!.StatusCode == 200);
            Assert.True(((actual! as OkObjectResult)!.Value as User)!.Id == 1);
        }

        [Fact]
        public async void GetUserById_ShouldReturnClientError()
        {
            //Arrange
            int userId = -1;
            _userManager.Setup(s => s.GetUserById(userId)).Throws<ArgumentException>();

            //Act
            var actual = (await _subject.GetUserById(userId)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual!);
            Assert.True((actual! as BadRequestObjectResult)!.StatusCode == 400);
        }
    }
}