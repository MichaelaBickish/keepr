using System;
using System.Collections.Generic;
using keepr.server.Models;
using keepr.server.Repositories;

namespace keepr.server.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _keepsRepo;

    public KeepsService(KeepsRepository keepsRepo)
    {
      _keepsRepo = keepsRepo;
    }

    internal Keep Create(Keep newKeep)
    {
      return _keepsRepo.Create(newKeep);
    }

    internal List<Keep> GetKeeps()
    {
      return _keepsRepo.GetAll();
    }

    internal Keep GetById(int id)
    {
      Keep k = _keepsRepo.GetById(id);
      if (k == null)
      {
        throw new Exception("Invalid Id");
      }
      return k;
    }

    public List<Keep> GetProfileKeeps(string userId)
    {
      return _keepsRepo.GetProfileKeeps(userId);
    }

    internal Keep Update(Keep k, string id)
    {
      Keep keep = _keepsRepo.GetById(k.Id);
      if (keep == null)
      {
        throw new Exception("Invalid Id");
      }
      if (k.CreatorId != keep.CreatorId)
      {
        throw new Exception("Only the owner of this keep can edit it.");
      }
      keep.Name = k.Name.Length > 0 ? k.Name : keep.Name;
      keep.Description = k.Description.Length > 0 ? k.Description : keep.Description;
      keep.Img = k.Img.Length > 0 ? k.Img : keep.Img;
      keep.Views = k.Views > 0 ? k.Views : keep.Views;
      keep.Keeps = k.Keeps > 0 ? k.Keeps : keep.Keeps;
      keep.Shares = k.Shares > 0 ? k.Shares : keep.Shares;

      return _keepsRepo.Update(keep);
    }


    internal void RemoveKeep(int id, string userId)
    {
      Keep keep = _keepsRepo.GetById(id);
      //check that creator is user.
      if (keep.CreatorId != userId)
      {
        throw new Exception("Only the owner of this keep can delete it.");
      }
      _keepsRepo.RemoveKeep(id);
    }
  }
}