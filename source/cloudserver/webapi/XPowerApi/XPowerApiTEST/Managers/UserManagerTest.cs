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
        private readonly Mock<IPasswordHasher> _passwordHasher = new();
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
                hashed_password = "SecretPassword",
                salt = "abcdefg",
                email = "peter@email.com"
            };
        }
        public UserManagerTest()
            => _subject = new UserManager(
                _userProvider.Object,
                _passwordHasher.Object,
                _tokenManager.Object
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
            byte[] salt = _passwordHasher.Object.GenerateSalt();
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
        public async void GetUserById_ShouldReturnUserObject()
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
            byte[] salt = _passwordHasher.Object.GenerateSalt();
            string hashed_password = _passwordHasher.Object.HashPassword("SecretSecret", salt);
            UserDb userDb = new UserDb()
            {
                id = "user:1",
                firstname = "Peter",
                lastname = "Parker",
                username = "PeterParker",
                email = "peter@email.com",
                salt = Convert.ToBase64String(salt),
                hashed_password = hashed_password
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
            var actual = await _subject.GetNewUserToken(userLogin);

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<UserToken>(actual);
            Assert.True((actual as UserToken) == userToken);
        }

        [Fact]
        public async Task GetNewUserToken_ShouldReturnNullOrEmptyStringWhenPasswordIsWrong()
        {
            //Arrange
            PasswordHasher passwordHasher = new();
            byte[] salt = passwordHasher.GenerateSalt();
            string hashed_password = passwordHasher.HashPassword("SecretSecret", salt);
            UserDb userDb = new UserDb()
            {
                id = "user:1",
                firstname = "Peter",
                lastname = "Parker",
                username = "PeterParker",
                email = "peter@email.com",
                salt = Convert.ToBase64String(salt),
                hashed_password = hashed_password
            };
            UserLogin userLogin = new UserLogin()
            {
                Username = "PeterParker",
                Password = "secretsuperPassword"
            };
            UserToken userToken = new UserToken()
            {
                Token = "Token123"
            };

            //Act
            _tokenManager.Setup(s => s.GenerateToken(It.IsAny<UserCredentials>())).ReturnsAsync(() => userToken);
            _userProvider.Setup(s => s.GetUserByUsername(userLogin.Username))
                .ReturnsAsync(() => userDb);
            var actual = await _subject.GetNewUserToken(userLogin);

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<UserToken>(actual);
            Assert.True(string.IsNullOrEmpty((actual as UserToken).Token));
        }

        [Fact]
        public async Task GetNewUserToken_ShouldReturnNullOrEmptyStringWhenUsernameIsWrong()
        {
            //Arrange
            byte[] salt = _passwordHasher.Object.GenerateSalt();
            string hashed_password = _passwordHasher.Object.HashPassword("SecretSecret", salt);
            UserDb userDb = new UserDb()
            {
                id = "user:1",
                firstname = "Peter",
                lastname = "Parker",
                username = "PeterParker",
                email = "peter@email.com",
                salt = Convert.ToBase64String(salt),
                hashed_password = hashed_password
            };
            UserLogin userLogin = new UserLogin()
            {
                Username = "PeterParker1",
                Password = "SecretSecret"
            };
            UserToken userToken = new UserToken()
            {
                Token = ""
            };

            //Act
            _tokenManager.Setup(s => s.GenerateToken(It.IsAny<UserCredentials>())).ReturnsAsync(() => userToken);
            _userProvider.Setup(s => s.GetUserByUsername(userLogin.Username))
                .ReturnsAsync(() => userDb);
            var actual = await _subject.GetNewUserToken(userLogin);

            //Assert
            Assert.NotNull(actual);
            Assert.IsType<UserToken>(actual);
            Assert.True(string.IsNullOrEmpty((actual as UserToken).Token));
        }
    }
}