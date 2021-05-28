using keepr.server.Services;
using Microsoft.AspNetCore.Mvc;

namespace keepr.server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vaultsService;

    public VaultsController(VaultsService vaultsService)
    {
      _vaultsService = vaultsService;
    }

    //Create
    // [Authorize]
    // [HttpPost]

    //Get vault by id - get if public - don't get if it's private.
    // [HttpGet("{id}")]

    //Get vaultkeeps- get keeps by vault id- repo: join account, vault & keep info.
    // [HttpGet("{VaultId/keeps}")]

    //Edit
    // [Authorize]
    // [HttpPut("{id}")]

    //Delete
    // [Authorize]
    // [HttpDelete("{id}")]
  }
}