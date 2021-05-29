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
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _keepsService;
    private readonly ProfilesService _profilesService;

    public KeepsController(KeepsService keepsService, ProfilesService profilesService)
    {
      _keepsService = keepsService;
      _profilesService = profilesService;
    }

    //Create
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
    {
      try
      {
        //get user info and set the creatorId
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        //check an account exists for that user before creating.
        Profile fullProfile = _profilesService.GetOrCreateProfile(userInfo);
        newKeep.CreatorId = userInfo.Id;

        Keep keep = _keepsService.Create(newKeep);
        //add profile to the new object as creator.
        keep.Creator = fullProfile;
        return Ok(keep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Get All
    [HttpGet]
    public ActionResult<List<Keep>> Get()
    {
      try
      {
        List<Keep> keeps = _keepsService.GetKeeps();
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // Get by id
    [HttpGet("{id}")]
    public ActionResult<Keep> GetById(int id)
    {
      try
      {
        Keep keep = _keepsService.GetById(id);
        return Ok(keep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Edit
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Keep>> Update(int id, [FromBody] Keep update)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        // don't trust client.
        update.Id = id;
        Keep newKeep = _keepsService.Update(update, userInfo.Id);
        newKeep.Creator = userInfo;
        return Ok(newKeep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Delete
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Keep>> Delete(int id)
    {
      try
      {
        //don't trust client.
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _keepsService.DeleteKeep(id, userInfo.Id);
        return Ok("Keep Successfully Deleted!");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}