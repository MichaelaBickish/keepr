using System;
using System.Threading.Tasks;
using keepr.server.Models;
using keepr.server.Repositories;

namespace keepr.server.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _profilesRepo;

    public ProfilesService(ProfilesRepository profilesRepo)
    {
      _profilesRepo = profilesRepo;
    }

    internal Profile GetOrCreateProfile(Profile userInfo)
    {
      Profile profile = _profilesRepo.GetById(userInfo.Id);
      if (profile == null)
      {
        return _profilesRepo.Create(userInfo);
      }
      return profile;
    }

    internal Profile GetById(string id)
    {
      Profile profile = _profilesRepo.GetById(id);
      if (profile == null)
      {
        throw new Exception("Invalid Id");
      }
      return profile;
    }
  }
}