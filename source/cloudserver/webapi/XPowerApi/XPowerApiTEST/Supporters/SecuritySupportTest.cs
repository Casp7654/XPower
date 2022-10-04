using XPowerApi.Supporters;

namespace XPowerApiTEST.Supporters
{
    public class SecuritySupportTest
    {
        [Fact]
        public void GenerateSalt_ShouldReturnByteArray()
        {
            //Arrange
            byte[] salt = new byte[0];

            //Act
            salt = SecuritySupport.GenerateSalt();

            //Assert
            Assert.NotEmpty(salt);
            Assert.True(salt.Length >= 1);
        }

        [Fact]
        public void HashPassword_ShouldReturnHashedString()
        {
            //Arrange 
            string clean_password = "SuperSecretPassword";

            //Act
            string hashedPassword = (SecuritySupport.HashPassword(clean_password, SecuritySupport.GenerateSalt()));

            //Assert
            Assert.NotEmpty(hashedPassword);
            Assert.True(hashedPassword.Length >= clean_password.Length);
        }
    }
}