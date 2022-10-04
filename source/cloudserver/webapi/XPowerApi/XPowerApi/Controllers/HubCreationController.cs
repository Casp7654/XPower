using XPowerApi.Interfaces;
using XPowerApi.Models.HubModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace XPowerApi.Controllers
{
    [Authorize]
    [Route("api/hub")]
    [ApiController]
    public class HubCreationController : Controller
    {
        private readonly ILogger<HubCreationController> _logger;
        private readonly IHubManager _hubManager;

        public HubCreationController(ILogger<HubCreationController> logger, IHubManager hubManager)
        {
            _logger = logger;
            _hubManager = hubManager;
        }

        /// <summary>
        /// Create hub
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Route("CreateHub")]
        public async Task<ActionResult<Hub>> CreateHub(HubCreate hubCreateInfo)
        {
            if (hubCreateInfo == null)
                return BadRequest(new { Message = "Missing parameter" });

            //checking if Home, Mac_addr and Pricate_addr is not null or empty
            if (string.IsNullOrEmpty(hubCreateInfo.Home) || string.IsNullOrEmpty(hubCreateInfo.Mac) ||
                string.IsNullOrEmpty(hubCreateInfo.PrivateAddress))
                return BadRequest(new { Message = "Name, Mac_addr or PrivateAddress is missing" });

            try
            {
                //Checking the hub
                var hub = await _hubManager.CreateHub(hubCreateInfo);

                //  Return a created Hub
                return Ok(hub);
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for create hub " + e.Message);
                return BadRequest(new { Message = "Missing parameter" });
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform create hub " + e.Message);
                return BadRequest(new { Message = "Missing parameter" });
            }
        }
    }
}