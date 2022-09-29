using XPowerApi.Supporters;

namespace XPowerApiTEST.Supporters
{
    public class PasswordHasherTest
    {
        private readonly PasswordHasher _subject;

        public PasswordHasherTest()
            => _subject = new();
        
        [Fact]
        public void GenerateSalt_ShouldReturnByteArray()
        {
            //Arrange
            byte[] salt;

            //Act
            salt = _subject.GenerateSalt();

            //Assert
            Assert.NotEmpty(salt);
            Assert.True(salt.Length >= 1);
        }

        [Fact]
        public void HashPassword_ShouldReturnHashedString()
        {
            //Arrange 
            string cleanPassword = "SuperSecretPassword";

            //Act
            string hashedPassword = (_subject.HashPassword(cleanPassword, _subject.GenerateSalt()));

            //Assert
            Assert.NotEmpty(hashedPassword);
            Assert.True(hashedPassword.Length >= cleanPassword.Length);
        }
    }
}