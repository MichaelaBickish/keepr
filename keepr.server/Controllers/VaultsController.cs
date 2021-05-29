using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr.server.Models;
using keepr.server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vaultsService;
    private readonly ProfilesService _profilesService;

    public VaultsController(VaultsService vaultsService, ProfilesService profilesService)
    {
      _vaultsService = vaultsService;
      _profilesService = profilesService;
    }

    //Create
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
    {
      try
      {
        //get user info and set the creatorId
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        //check an account exists for that user before creating.
        Profile fullProfile = _profilesService.GetOrCreateProfile(userInfo);
        newVault.CreatorId = userInfo.Id;

        Vault vault = _vaultsService.Create(newVault);
        //add profile to the new object as creator.
        vault.Creator = fullProfile;
        return Ok(vault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Get vault by id - get if public - don't get if it's private.
    [HttpGet("{id}")]
    public ActionResult<Keep> GetById(int id)
    {
      try
      {
        Vault vault = _vaultsService.GetById(id);
        return Ok(vault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //TODO
    //Get vaultkeeps- get keeps by vault id- IF VAULT IS MARKED PRIVATE, only owner can view keeps.
    // repo: join account, vault & keep info.
    // [HttpGet("{VaultId/keeps}")]


    //Edit
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Vault>> Update(int id, [FromBody] Vault update)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        // don't trust client.
        update.Id = id;
        Vault newVault = _vaultsService.Update(update, userInfo.Id);
        newVault.Creator = userInfo;
        return Ok(newVault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Delete
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Vault>> Delete(int id)
    {
      try
      {
        //don't trust client.
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _vaultsService.DeleteVault(id, userInfo.Id);
        return Ok("Vault Successfully Deleted!");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}