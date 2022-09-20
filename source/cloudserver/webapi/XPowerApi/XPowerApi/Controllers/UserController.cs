using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using XPowerApi.Interfaces;
using XPowerApi.Managers;
using XPowerApi.Models;
using XPowerApi.Models.UserModels;

namespace XPowerApi.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserManager _userManager;

        public UserController(ILogger<UserController> logger, IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets user by id
        /// </summary>
        /// <param name="id">ID of the user</param>
        [HttpGet]
        [Route("GetUserByID")]
        public async Task<ActionResult<User>> GetUserByID(int id)
        {
            try
            {
                //Checking if the user exists
                var user = await _userManager.GetUserByID(id);

                // User with that id was not found
                if(user == null)
                    return NoContent();

                //  Return a found user
                return Ok(user);
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for get user " + e.Message);
                return BadRequest(new { Message = e.Message });
                }
            catch (Exception e)
            {
                _logger.LogError("Could not perform get user" + e.Message);
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}
