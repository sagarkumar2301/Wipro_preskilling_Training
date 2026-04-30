using Xunit;
using SecureUserApp.Services;

namespace SecureApp.Tests   
{
    public class AuthTests   
    {
        [Fact]   
        public void Register_And_Login_Should_Work()
        {
            // Arrange
            AuthService auth = new AuthService();

            // Act
            auth.Register("test", "123");
            bool result = auth.Login("test", "123");

            // Assert
            Assert.True(result);
        }
    }
}
