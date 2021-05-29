using keepr.server.Services;
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
    // [Authorize]
    // [HttpPost]


    //Delete vaultkeep by vaultkeepId
    // [Authorize]
    // [HttpDelete("{id}")]


  }
}