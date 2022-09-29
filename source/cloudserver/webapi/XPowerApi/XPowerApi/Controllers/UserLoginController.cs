using Microsoft.AspNetCore.Mvc;
using XPowerApi.Interfaces;
using XPowerApi.Managers;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Controllers
{
    //[Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserLoginController : Controller
    {
        private readonly ITokenManager<UserToken> _tokenManager;
        private readonly ILogger<UserLoginController> _logger;
        private readonly IUserManager _userManager;

        public UserLoginController(ITokenManager<UserToken> tokenManager, ILogger<UserLoginController> logger, IUserManager userManager)
        {
            _tokenManager = tokenManager;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Login(UserToken user)
        {
            if (user == null)
                return BadRequest("No login provided");

            try
            {
                if (!string.IsNullOrEmpty(user.Token))
                {
                    // Check if token is valid
                    if (await _tokenManager.ValidateToken(user.Token))
                        return Ok("Login Success");
                    else
                        return Unauthorized("Token Invalid");
                }

                // Validates user with credentials
                if (await _userManager.ValidateUser(user))
                    return Ok(await _tokenManager.GenerateToken(user));
                else
                    return Unauthorized("Username or Password Invalid");
            }
            catch (Exception ex)
            {

                // If error is not accounted for
                _logger.LogError("Something went wrong inside Login with message: " + ex.Message);
            }



        }
    }
}
