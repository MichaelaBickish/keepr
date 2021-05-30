using System;
using keepr.server.Models;
using keepr.server.Repositories;

namespace keepr.server.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vaultKeepsRepo;

    public VaultKeepsService(VaultKeepsRepository vaultKeepsRepo)
    {
      _vaultKeepsRepo = vaultKeepsRepo;
    }

    internal VaultKeeps CreateVaultKeep(VaultKeeps vk, string userId)
    {
      //make sure signed in user is creator.
      if (vk.CreatorId != userId)
      {
        throw new Exception("You can't add a keep to a vault you don't own.");
      }
      return _vaultKeepsRepo.Create(vk);
    }

    internal void Remove(int id, string userInfoId)
    {
      //get vaultkeep by id.
      VaultKeepsViewModel foundVk = _vaultKeepsRepo.GetVaultKeepById(id);
      if (foundVk.CreatorId != userInfoId)
      {
        throw new Exception("You can't remove a keep from a vault you don't own.");
      }
      _vaultKeepsRepo.Remove(id);
    }


  }
}