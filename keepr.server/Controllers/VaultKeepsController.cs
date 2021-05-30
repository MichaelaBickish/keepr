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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vaultKeepsService;

    public VaultKeepsController(VaultKeepsService vaultKeepsService)
    {
      _vaultKeepsService = vaultKeepsService;
    }

    //Create vaultkeep
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<VaultKeeps>> CreateVaultKeep([FromBody] VaultKeeps vk)
    {
      try
      {
        // enforce the current user 
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        vk.CreatorId = userInfo.Id;
        VaultKeeps newVk = _vaultKeepsService.CreateVaultKeep(vk, userInfo.Id);
        return Ok(newVk);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Get vaultkeep by id to delete
    // [HttpGet("{id}")]
    // public async Task<ActionResult<VaultKeepsViewModel>> GetVaultKeepById(int id)
    // {
    //   try
    //   {
    //     Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
    //     VaultKeepsViewModel vaultkeep = _vaultKeepsService.GetVaultKeepById(id);
    //     if (vaultkeep.IsPrivate == true && vaultkeep.CreatorId != userInfo.Id)
    //     {
    //       throw new Exception("This is a private keep!");
    //     }
    //     else if (vaultkeep.IsPrivate == true && vaultkeep.CreatorId == userInfo.Id)
    //     {
    //       return Ok(vaultkeep);
    //     }
    //     return Ok(vaultkeep);
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    //Delete vaultkeep by vaultkeepId
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<VaultKeeps>> Remove(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _vaultKeepsService.Remove(id, userInfo.Id);
        return Ok("Successfully Removed");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}