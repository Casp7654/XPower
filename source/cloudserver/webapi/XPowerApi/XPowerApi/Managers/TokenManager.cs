using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Managers
{

    public class TokenManager : ITokenManager<UserToken>
    {
        private readonly IConfiguration _configuration;
        string secret = "";
        public TokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
            secret = _configuration["JWT:Key"];
        }

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

        public Task<UserToken> GenerateToken(User user)
        {
 
            byte[] key = Convert.FromBase64String(secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, user.UserName),
                      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);

            UserToken t = new UserToken();
            t.Token = handler.WriteToken(token);
            t.UserName = user.UserName;
            t.Id = user.Id;

            return Task.Run(() => t);
        }

        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
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
            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            Claim userIdClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
            username = usernameClaim.Value;
            id = Convert.ToInt32(userIdClaim.Value);

            return await Task.Run(() => true);
        }
    }
}
