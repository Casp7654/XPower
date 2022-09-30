using XPowerApi.DbModels;
using XPowerApi.Interfaces;
using XPowerApi.Providers;

namespace XPowerApiTEST.Providers
{
    public class UserProviderTest
    {
        private readonly UserProvider _subject;
        private readonly Mock<ISurrealDbProvider> _dbProvider = new();

        public UserProviderTest()
            => _subject = new(_dbProvider.Object);

        [Fact]
        public async void CreateUser_ShouldReturnUserDbObject()
        {
            //Arrange 
            string tableName = "user";
            Dictionary<string, string> input = new() { { "firstname", "test" }, { "lastname", "pest" } };
            UserDb expected = new UserDb() { id = "user:1", firstname = "test", lastname = "pest" };
            _dbProvider.Setup(s => s.Create<UserDb>(tableName, input))
                .ReturnsAsync(() => expected);
            //Act
            var actual = await _subject.CreateUser(input);
            //Assert
            Assert.NotNull(actual);
            Assert.IsType<UserDb>(actual!);
            Assert.True(actual.id == expected.id);
        }

        [Fact]
        public async void GetHubById_ShouldReturnHubDbObject()
        {
            //Arrange 
            string tableName = "user";
            int userId = 1;
            UserDb expected = new UserDb() { id = "hub:1", firstname = "test", lastname = "pest"};
            _dbProvider.Setup(s => s.GetOneById<UserDb>(tableName, userId))
                .ReturnsAsync(() => expected);
            //Act
            var actual = await _subject.GetUserById(userId);
            //Assert
            Assert.NotNull(actual);
            Assert.IsType<UserDb>(actual!);
            Assert.True(actual.id == expected.id);
        }
    }
}