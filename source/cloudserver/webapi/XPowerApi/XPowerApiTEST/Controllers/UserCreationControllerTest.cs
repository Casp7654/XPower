using XPowerApi.Controllers;
using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;

namespace XPowerApiTEST.Controllers
{
    public class UserCreationControllerTest
    {
        private readonly UserCreationController _subject;
        private readonly Mock<ILogger<UserCreationController>> _logger = new();
        private readonly Mock<IUserManager> _userManager = new();
        private readonly Mock<IHomeManager> _homeManager = new();
        private readonly Mock<ITokenManager<UserToken>> _tokenManager = new();

        public UserCreationControllerTest()
            => _subject = new(
                _logger.Object,
                _userManager.Object,
                _homeManager.Object,
                _tokenManager.Object
            );

        [Fact]
        public async void CreateUser_ShouldReturnUserTokenObject()
        {
            //Arrange
            UserCredentials input = new()
            {
                Email = "test@test.dk",
                FirstName = "John",
                LastName = "Doe",
                UserName = "jodo",
                Password = "testetest"
            };
            _userManager.Setup(s => s.CreateUser(input)).ReturnsAsync(new UserToken());

            //Act
            var actual = (await _subject.CreateUser(input)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual!);
            Assert.True((actual! as OkObjectResult)!.StatusCode == 200);
        }

        [Fact]
        public async void CreateUser_ShouldFailClientError()
        {
            //Arrange
            UserCredentials input = new();
            _userManager.Setup(x => x.CreateUser(input)).ReturnsAsync(new UserToken());

            //Act
            var actual = (await _subject.CreateUser(input)).Result;

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<BadRequestObjectResult>(actual!);
            Assert.True((actual! as BadRequestObjectResult)!.StatusCode == 400);
        }
    }
}