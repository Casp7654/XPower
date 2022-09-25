﻿using Microsoft.AspNetCore.Http;
using System.Net;
using XPowerApi.Interfaces;
using XPowerApi.Models.UserModels;
using XPowerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using XPowerApi.Models.HomeGroupModels;

namespace XPowerApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserCreationController : Controller
    {
        private readonly ILogger<UserCreationController> _logger;
        private readonly IUserManager _userManager;
        private readonly IHomeGroupManager _homeGroupManager;
        private readonly ITokenManager<UserToken> _tokenManager;

        public UserCreationController(
            ILogger<UserCreationController> logger,
            IUserManager userManager,
            IHomeGroupManager homeGroupManager,
            ITokenManager<UserToken> tokenManager
        )
        {
            _logger = logger;
            _userManager = userManager;
            _homeGroupManager = homeGroupManager;
            _tokenManager = tokenManager;
        }

        /// <summary>
        /// Create user
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<UserToken>> CreateUser(UserCreate userCreateInfo)
        {
            if (userCreateInfo == null)
                return BadRequest(new { Message = "Missing parameter" });

            //checking if username and password is not null or empty
            if (string.IsNullOrEmpty(userCreateInfo.UserName) || string.IsNullOrEmpty(userCreateInfo.Password))
                return BadRequest(new { Message = "Username or Password is missing valid" });

            try
            {
                //Checking the user
                var user = await _userManager.CreateUser(userCreateInfo);
                //Checking the homegroup
                var homeGroup = await _homeGroupManager.CreateHomeGroup(new HomeGroupCreate() { Name = "Default" });
                //make relation
                var related = await _homeGroupManager.RelateUserToHomeGroup(user.Id, homeGroup.Id);

                //  Return a created usertoken
                return Ok(_tokenManager.GenerateToken(user));
            }
            catch (ArgumentException e)
            {
                _logger.LogError("Bad request for create user " + e.Message);
                return BadRequest(new { Message = "Missing parameter" });
            }
            catch (Exception e)
            {
                _logger.LogError("Could not perform create user" + e.Message);
                return BadRequest(new { Message = "Missing parameter" });
            }
        }
    }
}