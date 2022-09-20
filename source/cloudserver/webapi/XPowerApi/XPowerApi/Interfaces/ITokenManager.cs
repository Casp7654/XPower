using XPowerApi.Models.UserModels;

namespace XPowerApi.Interfaces
{
    public interface ITokenManager<TToken>
    {
        public Task<TToken> GenerateToken(User user);
        public Task<bool> ValidateToken(string token);
        public Task<TToken> FromTokenString(string token);
    }
}
