using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XPowerApi.Interfaces;
using XPowerApi.Models.HomeModels;

namespace XPowerApi.Controllers
{
    [Authorize]
    [Route("api/home")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeManager _homeManager;

        public HomeController(ILogger<HomeController> logger, IHomeManager homeManager)
        {
            _logger = logger;
            _homeManager = homeManager;
        }

        /// <summary>
        /// Gets home by id
        /// </summary>
        /// <param name="id">ID of the home</param>
        [HttpGet]
        [Route("GetHomeByID")]
        public async Task<ActionResult<Home>> GetHomeById(int id)
        {
            try
            {
                //Checking if the home exists
                var home = await _homeManager.GetHomeById(id);

                // User with that id was not found
                if (home == null)
                    return NoContent();

                //  Return a found home
                return Ok(home);
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for get home " + e.Message);
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform get home " + e.Message);
                return BadRequest(new { Message = e.Message });
            }
        }
    }
