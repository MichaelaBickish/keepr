using keepr.server.Services;
using Microsoft.AspNetCore.Mvc;

namespace keepr.server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _profilesService;

    public ProfilesController(ProfilesService profilesService)
    {
      _profilesService = profilesService;
    }
    // Only need a getById? Don't need a getall. 
    //get profile by id. get vault by profile id. get keeps by profile id.


    //Get profile
    // [HttpGet("{id}")]

    //Get a user's keeps
    // [HttpGet("{id}/keeps")]

    //Get a user's vaults
    // [HttpGet("{id}/vaults")]
  }
}