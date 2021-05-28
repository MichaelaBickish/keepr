using keepr.server.Services;
using Microsoft.AspNetCore.Mvc;

namespace keepr.server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _keepsService;

    public KeepsController(KeepsService keepsService)
    {
      _keepsService = keepsService;
    }

    //Create
    // [Authorize]
    // [HttpPost]

    //Get All
    // [HttpGet]

    //Get by id
    // [HttpGet("{id}")]

    //Edit
    // [Authorize]
    // [HttpPut("{id}")]

    //Delete
    // [Authorize]
    // [HttpDelete("{id}")]

  }
}