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
    public async Task<ActionResult<VaultKeeps>> CreateAsync([FromBody] VaultKeeps vk)
    {
      try
      {
        // enforce the current user 
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        vk.CreatorId = userInfo.Id;
        var newVk = _vaultKeepsService.CreateVaultKeep(vk);
        return Ok(newVk);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    //Delete vaultkeep by vaultkeepId
    // [Authorize]
    // [HttpDelete("{id}")]


  }
}