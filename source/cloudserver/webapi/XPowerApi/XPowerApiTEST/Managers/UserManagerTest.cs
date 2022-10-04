using System.Web.Http.Controllers;
using XPowerApi.DbModels;
using XPowerApi.Interfaces;
using XPowerApi.Managers;
using XPowerApi.Models.UserModels;
using XPowerApi.Supporters;

namespace XPowerApiTEST.Managers
{
    public class UserManagerTest
    {
        private readonly UserManager _subject;
        private readonly Mock<IUserProvider> _userProvider = new();
        private readonly Mock<ITokenManager<UserToken>> _tokenManager = new();

        public static bool UserCredentialsEquals(UserCredentials a, UserCredentials b)
        {
            if (a.Id == b.Id && a.Firstname == b.Firstname && a.Lastname == b.Lastname &&
                a.UserName == b.UserName && a.Salt == b.Salt && a.HashedPassword == b.HashedPassword)
                return true;

            return false;
        }
        public UserDb CreateUserDbMock()
        {
            return new UserDb()
            {
                id = "user:1",
                firstname = "Peter",
                lastname = "Parker",
                username = "PeterParker",
                hashedPassword = "SecretPassword",
                salt = "abcdefg",
                email = "peter@email.com"
            };
        }
        public UserManagerTest()
            => _subject = new UserManager(_userProvider.Object, _tokenManager.Object);

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

            //Act
            _userProvider.Setup(s => s.GetUserById(userId))
                .ReturnsAsync(() => expected);
            var actual = (await _subject.GetUserById(userId));

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<User>(actual);
            Assert.True(actual.Id == expected.ConvertToUser().Id);
        }

        [Fact]
        public async Task GetUserCredentialsByUsername_ShouldReturnUserCredentials()
        {
            //Arrange
            string username = "PeterParker";
            UserDb expected = CreateUserDbMock();
            _userProvider.Setup(s => s.GetUserByUsername(username))
                .ReturnsAsync(() => expected);

            //Act
            var actual = await _subject.GetUserCredentialsByUsername(username);

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<UserCredentials>(actual);
            Assert.True(UserCredentialsEquals(expected.ConvertToUserCredentials(), actual));
        }

        [Fact]
        public async Task GetNewUserToken_ShouldReturnNewToken()
        {
            //Arrange
            byte[] salt = SecuritySupport.GenerateSalt();
            string hashed_password = SecuritySupport.HashPassword("SecretSecret", salt);
            string expected = "Token123";
            UserDb userDb = new UserDb()
            {
                id = "user:1",
                firstname = "Peter",
                lastname = "Parker",
                username = "PeterParker",
                email = "peter@email.com",
                salt = Convert.ToBase64String(salt),
                hashedPassword = hashed_password
            };
            UserLogin userLogin = new UserLogin()
            {
                Username = "PeterParker",
                Password = "SecretSecret"
            };
            UserToken userToken = new UserToken()
            {
                Token = "Token123"
            };

            //Act
            _tokenManager.Setup(s => s.GenerateToken(It.IsAny<UserCredentials>())).ReturnsAsync(() => userToken);
            _userProvider.Setup(s => s.GetUserByUsername(userLogin.Username))
                .ReturnsAsync(() => userDb);
            string actual = await _subject.GetNewUserToken(userLogin);

            //Assert
            Assert.NotEmpty(actual);
            Assert.True(actual == expected);
        }

        [Fact]
        public async Task GetNewUserToken_ShouldReturnNullOrEmptyStringWhenPasswordIsWrong()
        {
            //Arrange
            byte[] salt = SecuritySupport.GenerateSalt();
            string hashed_password = SecuritySupport.HashPassword("SecretSecret", salt);
            UserDb userDb = new UserDb()
            {
                id = "user:1",
                firstname = "Peter",
                lastname = "Parker",
                username = "PeterParker",
                email = "peter@email.com",
                salt = Convert.ToBase64String(salt),
                hashedPassword = hashed_password
            };
            UserLogin userLogin = new UserLogin()
            {
                Username = "PeterParker",
                Password = "SecretSecret1"
            };
            UserToken userToken = new UserToken()
            {
                Token = "Token123"
            };

            //Act
            _tokenManager.Setup(s => s.GenerateToken(It.IsAny<UserCredentials>())).ReturnsAsync(() => userToken);
            _userProvider.Setup(s => s.GetUserByUsername(userLogin.Username))
                .ReturnsAsync(() => userDb);
            string actual = await _subject.GetNewUserToken(userLogin);

            //Assert
            Assert.True(string.IsNullOrEmpty(actual));
        }

        [Fact]
        public async Task GetNewUserToken_ShouldReturnNullOrEmptyStringWhenUsernameIsWrong()
        {
            //Arrange
            byte[] salt = SecuritySupport.GenerateSalt();
            string hashed_password = SecuritySupport.HashPassword("SecretSecret", salt);
            UserDb userDb = new UserDb()
            {
                id = "user:1",
                firstname = "Peter",
                lastname = "Parker",
                username = "PeterParker",
                email = "peter@email.com",
                salt = Convert.ToBase64String(salt),
                hashedPassword = hashed_password
            };
            UserLogin userLogin = new UserLogin()
            {
                Username = "PeterParker1",
                Password = "SecretSecret"
            };
            UserToken userToken = new UserToken()
            {
                Token = "Token123"
            };

            //Act
            _tokenManager.Setup(s => s.GenerateToken(It.IsAny<UserCredentials>())).ReturnsAsync(() => userToken);
            _userProvider.Setup(s => s.GetUserByUsername(userDb.username))
                .ReturnsAsync(() => userDb);
            //Func<Task<string>> func = async () =>  await _subject.GetNewUserToken(userLogin);
            var actual = await _subject.GetNewUserToken(userLogin);
            //Assert
            //await Assert.ThrowsAsync<>(func);
            Assert.True(string.IsNullOrEmpty(actual));
        }
    }
}