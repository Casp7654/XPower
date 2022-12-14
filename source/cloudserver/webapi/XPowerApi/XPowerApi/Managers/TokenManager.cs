using System.Collections.Immutable;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Managers
{
    public class TokenManager : ITokenManager<UserToken>
    {
        private readonly IConfiguration _configuration;
        private readonly string _secret = "";

        public TokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _secret = _configuration["JWT:Key"];
        }

        /// <inheridDoc />
        public Task<UserToken> FromTokenString(string token)
        {
            var principal = GetPrincipal(token);
            UserToken userToken = null;

            if (principal == null)
                return Task.Run(() => userToken);

            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return Task.Run(() => userToken);
            }

            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            Claim userIdClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
            userToken.UserName = usernameClaim.Value;
            userToken.Id = Convert.ToInt32(userIdClaim.Value);
            userToken.Token = token;


            return Task.Run(() => userToken);
        }

        /// <inheridDoc />
        public Task<UserToken> GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("username", user.UserName),
                new Claim("firstname", user.Firstname),
                new Claim("lastname", user.Lastname),
                new Claim("email", user.Email)
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            UserToken t = new UserToken();
            t.Token = new JwtSecurityTokenHandler().WriteToken(token);
            t.UserName = user.UserName;
            t.Id = user.Id;
            t.Email = user.Email;
            t.Firstname = user.Firstname;
            t.Lastname = user.Lastname;

            return Task.Run(() => t);
        }

        /// <inheridDoc />
        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Encoding.UTF8.GetBytes(_secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidAudience = _configuration["Jwt:Audience"],
                    ValidIssuer = _configuration["Jwt:Issuer"],
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                    parameters, out securityToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }


        /// <inheridDoc />
        public async Task<bool> ValidateToken(string token)
        {
            string username = null;
            int id = 0;
            ClaimsPrincipal principal = GetPrincipal(token);

            if (principal == null)
                await Task.Run(() => false);

            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return await Task.Run(() => false);
            }

            Claim usernameClaim = identity.FindFirst("username");
            Claim userIdClaim = identity.FindFirst("id");
            username = usernameClaim.Value;
            id = Convert.ToInt32(userIdClaim.Value);

            return await Task.Run(() => true);
        }
    }
}