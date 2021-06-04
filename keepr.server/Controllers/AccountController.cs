using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr.server.Models;
using keepr.server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly ProfilesService _profilesService;
    private readonly VaultsService _vaultsService;

    public AccountController(ProfilesService profilesService, VaultsService vaultsService)
    {
      _profilesService = profilesService;
      _vaultsService = vaultsService;
    }


    // Create and a getByID.
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_profilesService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("vaults")]
    [Authorize]
    //Get current users vaults for dropdown list in client
    public async Task<ActionResult<List<Vault>>> GetCurrentUsersVaults()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_vaultsService.GetCurrentUsersVaults(userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}