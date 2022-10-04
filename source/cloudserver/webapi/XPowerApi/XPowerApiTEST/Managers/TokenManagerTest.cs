using Microsoft.Extensions.Configuration;
using XPowerApi.Managers;

namespace XPowerApiTEST.Managers
{
    // TODO:
    public class TokenManagerTest
    {
        private readonly TokenManager _subject;
        private readonly Mock<IConfiguration> _configuration = new();

        public TokenManagerTest()
            => _subject = new(_configuration.Object);

        public void FromTokenString_ShouldReturnUserTokenObject()
        {
            //Arrange
            
            //Act
            
            //Assert
        }

        public void GenerateToken_ShouldReturnUserTokenObject()
        {
            //Arrange
            
            //Act
            
            //Assert
        }

        public void GetPrincipal_ShouldReturnClaimsPrincipalObject()
        {
            //Arrange
            
            //Act
            
            //Assert
        }

        public void ValidateToken_ShouldReturnTrue()
        {
            //Arrange
            
            //Act
            
            //Assert
        }
    }
}