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

    internal Keep Update(Keep k, string id)
    {
      Keep keep = _keepsRepo.GetById(k.Id);
      if (keep == null)
      {
        throw new Exception("Invalid Id");
      }
      if (keep.CreatorId != id)
      {
        throw new Exception("Only the owner of this keep can edit it.");
      }

      return _keepsRepo.Update(k);
    }

    internal void DeleteKeep(int id, string userId)
    {
      Keep keep = GetById(id);
      //check that creator is user.
      if (keep.CreatorId != userId)
      {
        throw new Exception("Only the owner of this keep can delete it.");
      }
      _keepsRepo.DeleteKeep(id);
    }
  }
}