using XPowerApi.DbModels;
using XPowerApi.Interfaces;
using XPowerApi.Managers;
using XPowerApi.Models.UserModels;

namespace XPowerApiTEST.Managers
{
    public class UserManagerTest
    {
        private readonly UserManager _subject;
        private readonly Mock<IUserProvider> _userProvider = new();

        public UserManagerTest()
            => _subject = new UserManager(_userProvider.Object);

        [Fact]
        public async void CreateUser_ShouldReturnHubObject()
        {
            //Arrange
            UserCreate input = new()
            {
                UserName = "JohnDon",
                FirstName = "John",
                LastName = "Doe",
                Email = "test@test.dk",
                Password = "SecretPassword"
            };
            Dictionary<string, string> dataArray = new Dictionary<string, string>()
            {
                { "username", input.UserName },
                { "firstname", input.FirstName },
                { "lastname", input.LastName },
                { "email", input.Email },
            };
            UserDb expected = new()
            {
                id = "user:1",
                username = "JohnDon",
            };
            _userProvider.Setup(s => s.CreateUser(dataArray)).ReturnsAsync(expected);

            //Act
            var actual = (await _subject.CreateUser(input));
            // TODO: Figure out why this fails

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<User>(actual);
            Assert.NotEmpty(actual.UserName);
            Assert.True(actual.UserName == expected.ConvertToUser().UserName);
            Assert.True(actual.Id == expected.ConvertToUser().Id);
        }

        [Fact]
        public async void GetUserById_ShouldReturnHubObject()
        {
            //Arrange
            int userId = 1;
            UserDb expected = new() { id = $"user:{userId}" };
            _userProvider.Setup(s => s.GetUserById(userId))
                .ReturnsAsync(() => expected);

            //Act
            var actual = (await _subject.GetUserById(userId));

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<User>(actual);
            Assert.True(actual.Id == expected.ConvertToUser().Id);
        }
    }
}