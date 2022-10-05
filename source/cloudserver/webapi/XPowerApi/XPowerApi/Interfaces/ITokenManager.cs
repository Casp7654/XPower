using XPowerApi.Models.UserModels;

namespace XPowerApi.Interfaces
{
    public interface ITokenManager<TToken>
    {
        /// <summary>
        /// Generates a token by the specified user.
        /// </summary>
        /// <param name="user">The user to generate token from.</param>
        /// <returns>The generated token.</returns>
        public Task<TToken> GenerateToken(User user);

        /// <summary>
        /// Validates a given token.
        /// </summary>
        /// <param name="token">The token to validate.</param>
        /// <returns>True if valid, false if not.</returns>
        public Task<bool> ValidateToken(string token);

        /// <summary>
        /// Converts a token string to TToken model.
        /// </summary>
        /// <param name="token">The token to convert.</param>
        /// <returns>The converted token.</returns>
        public Task<TToken> FromTokenString(string token);
    }
}
