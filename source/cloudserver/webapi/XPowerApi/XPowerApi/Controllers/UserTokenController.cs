using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserTokenController : Controller
    {
        private readonly ITokenManager<UserToken> _tokenManager;
        private readonly ILogger<UserTokenController> _logger;
        private readonly IUserManager _userManager;

        public UserTokenController(ITokenManager<UserToken> tokenManager, ILogger<UserTokenController> logger, IUserManager userManager)
        {
            _tokenManager = tokenManager;
            _logger = logger;
            _userManager = userManager;
        }

        /// <summary>
        /// Checks if users token is valid and returns accordingly.
        /// </summary>
        /// <param name="token"></param>
        /// <returns>OK if token is valid & Unauthorized if token is invalid</returns>
        [HttpPost]
        [Route("ValidateToken")]
        public async Task<IActionResult> ValidateToken(string token)
        {

            try
            {
                // Check if token has been provided
                if (!string.IsNullOrEmpty(token))
                {
                    // Check if token is valid
                    if (await _tokenManager.ValidateToken(token))
                        return Ok("Login Success");
                }

                return Unauthorized("Token Invalid");
            }
            catch (Exception ex)
            {

                // If error is not accounted for
                _logger.LogError("Something went wrong inside ValidateToken with message: " + ex.Message);

                return BadRequest("Something went wrong with token validation.");
            }

        }
    }
}
