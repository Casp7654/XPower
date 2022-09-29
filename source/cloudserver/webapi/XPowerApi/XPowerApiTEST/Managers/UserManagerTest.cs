using System.Security.Cryptography;
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
        private readonly Mock<IPasswordHasher> _passwordHasher = new();

        public UserManagerTest()
            => _subject = new UserManager(
                _userProvider.Object,
                _passwordHasher.Object
            );

        [Fact]
        public async void CreateUser_ShouldReturnUserObject()
        {
            //Arrange
            UserCreate input = new()
            {
                UserName = "JohnDon",
                FirstName = "John",
                LastName = "Doe",
                Email = "test@test.dk",
                Password = "Teste",
            };
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashedPassword = _passwordHasher.Object.HashPassword(input.Password, salt);
            Dictionary<string, string> dataArray = new Dictionary<string, string>()
            {
                { "hashed_password", hashedPassword },
                { "username", input.UserName },
                { "firstname", input.FirstName },
                { "lastname", input.LastName },
                { "email", input.Email },
                { "salt", _passwordHasher.Object.SaltToString(salt) }
            };
            UserDb expected = new()
            {
                id = "user:1",
                username = "JohnDon",
            };
            _passwordHasher.Setup(s => s.GenerateSalt())
                .Returns(() => salt);
            _passwordHasher.Setup(s => s.HashPassword(input.Password!, salt))
                .Returns(() => hashedPassword);
            _userProvider.Setup(s => s.CreateUser(dataArray))
                .ReturnsAsync(() => expected);

            //Act
            var actual = (await _subject.CreateUser(input));

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