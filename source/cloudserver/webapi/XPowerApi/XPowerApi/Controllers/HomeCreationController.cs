using XPowerApi.Interfaces;
using XPowerApi.Models.HomeModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace XPowerApi.Controllers
{
    //[Authorize]
    [Route("api/home")]
    [ApiController]
    public class HomeCreationController : Controller
    {
        private readonly ILogger<HomeCreationController> _logger;
        private readonly IHomeManager _homeManager;

        public HomeCreationController(ILogger<HomeCreationController> logger, IHomeManager homeManager)
        {
            _logger = logger;
            _homeManager = homeManager;
        }

        /// <summary>
        /// Create Home
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Route("CreateHome")]
        public async Task<ActionResult<Home>> CreateHome(HomeCreate homeCreateInfo, int userId)
        {
            if (homeCreateInfo == null)
                return BadRequest(new { Message = "Missing parameter" });

            //checking if name is not null or empty
            if (string.IsNullOrEmpty(homeCreateInfo.Name))
                return BadRequest(new { Message = "Name is missing" });

            try
            {
                //Checking the home
                var home = await _homeManager.CreateHome(homeCreateInfo, userId);

                //  Return a created Home
                return Ok(home);
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for create home " + e.Message);
                return BadRequest(new { Message = "Missing parameter" });
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform create home " + e.Message);
                return BadRequest(new { Message = "Missing parameter" });
            }
        }
    }
}