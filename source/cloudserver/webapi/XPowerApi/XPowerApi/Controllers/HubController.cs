using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XPowerApi.Interfaces;
using XPowerApi.Models.HubModels;

namespace XPowerApi.Controllers
{
    [Authorize]
    [Route("api/hub")]
    [ApiController]
    public class HubController : Controller
    {
        private readonly ILogger<HubController> _logger;
        private readonly IHubManager _hubManager;

        public HubController(ILogger<HubController> logger, IHubManager hubManager)
        {
            _logger = logger;
            _hubManager = hubManager;
        }

        /// <summary>
        /// Gets Hub by id
        /// </summary>
        /// <param name="id">ID of the hub</param>
        [HttpGet]
        [Route("GetHubByID")]
        public async Task<ActionResult<Hub>> GetHubById(int id)
        {
            try
            {
                //Checking if the hub exists
                var hub = await _hubManager.GetHubById(id);

                // Hub with that id was not found
                if (hub == null)
                    return NoContent();

                //  Return a found hub
                return Ok(hub);
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for get hub " + e.Message);
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform get hub " + e.Message);
                return BadRequest(new { Message = e.Message });
            }
        }

        /// <summary>
        /// Gets Hubs in home
        /// </summary>
        /// <param name="homeid">Id of the home</param>
        [HttpGet]
        [Route("GetHubsByHomeID")]
        public async Task<ActionResult<List<Hub>>> GetHubsByHomeId(int homeid)
        {
            try
            {
                //Checking if the hub exists
                List<Hub> hubs = await _hubManager.GetHubsByHomeId(homeid);

                // Hub with that id was not found
                if (hubs.Count <= 0)
                    return NoContent();

                //  Return a found hub
                return Ok(hubs);
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for get hubs " + e.Message);
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform get hubs " + e.Message);
                return BadRequest(new { Message = e.Message });
            }
        }

        /// <summary>
        /// Gets Hubs associated with user
        /// </summary>
        /// <param name="userid">Id of the user</param>
        [HttpGet]
        [Route("GetHubsByUserID")]
        public async Task<ActionResult<List<Hub>>> GetHubsByUserId(int userid)
        {
            try
            {
                //Checking if the hub exists
                List<Hub> hubs = await _hubManager.GetHubsByUserId(userid);

                // Hub with that id was not found
                if (hubs.Count <= 0)
                    return NoContent();

                //  Return a found hub
                return Ok(hubs);
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for get hubs " + e.Message);
                return BadRequest(new { Message = e.Message });
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform get hubs " + e.Message);
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}