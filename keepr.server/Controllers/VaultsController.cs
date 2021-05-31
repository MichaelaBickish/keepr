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
    public async Task<ActionResult<Vault>> GetById(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        Vault vault = _vaultsService.GetById(id);
        // if vault is private and user is not creator, cant access
        // if vault is private and user is creator, CAN access.
        // if not private, can access
        if (vault.IsPrivate == true && vault.CreatorId != userInfo.Id)
        {
          throw new Exception("This vault is private!");
        }
        else if (vault.IsPrivate == true && vault.CreatorId == userInfo.Id)
        {
          return Ok(vault);
        }
        return Ok(vault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //GET vaultkeeps- get keeps by vault id- IF VAULT IS MARKED PRIVATE, only owner can view keeps.
    // api/vaults/:vaultId/keeps
    [HttpGet("{id}/keeps")]
    public async Task<ActionResult<List<VaultKeepsViewModel>>> GetVkeepsByVaultId(int vaultId)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        var vKeeps = _vaultsService.GetVkeepsByVaultId(vaultId, userInfo.Id);
        List<VaultKeepsViewModel> vaultkeeps = _vaultsService.GetVkeepsByVaultId(vaultId, userInfo.Id);
        // if vault is private and user is not creator, cant access
        // if vault is private and user is creator, CAN access.
        // if not private, can access
        return Ok(vaultkeeps);
        // if (vault.IsPrivate == true && vault.CreatorId != userInfo.Id)
        // {
        //   throw new Exception("This vault's keeps are private!");
        // }
        // else if (vault.IsPrivate == true && vault.CreatorId == userInfo.Id)
        // {
        //   return Ok(vKeeps);
        // }
        // return Ok(vKeeps);

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


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