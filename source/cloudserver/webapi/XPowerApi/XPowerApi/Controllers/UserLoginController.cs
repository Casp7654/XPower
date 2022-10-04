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
        private readonly ILogger<UserLoginController> _logger;
        private readonly IUserManager _userManager;

        public UserLoginController(ILogger<UserLoginController> logger, IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Login")]
        /// <summary>
        /// Calls usermanager to validate user login info
        /// </summary>
        /// <param name="user"></param>
        /// <returns>New token if user is valid</returns>
        public async Task<IActionResult> LoginUser(UserLogin user)
        {
            // Check if token is provided
            if (user == null)
                return BadRequest("No user provided");

            try
            {
                // Validates user with credentials and fetches a new token
                string validUserToken = await _userManager.GetNewUserToken(user);
                if (!string.IsNullOrEmpty(validUserToken))
                    return Ok(validUserToken);
                else
                    return Unauthorized("Username or Password Invalid");
            }
            catch (Exception ex)
            {

                // If error is not accounted for
                _logger.LogError("Something went wrong inside Login with message: " + ex.Message);

                return BadRequest("Something went wrong with login.");
            }

        }
    }
}
