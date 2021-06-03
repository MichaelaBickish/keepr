using System;
using System.Collections.Generic;
using System.Linq;
using keepr.server.Models;
using keepr.server.Repositories;

namespace keepr.server.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vaultsRepo;

    public VaultsService(VaultsRepository vaultsRepo)
    {
      _vaultsRepo = vaultsRepo;
    }

    internal Vault Create(Vault newVault)
    {
      return _vaultsRepo.Create(newVault);
    }

    internal Vault GetVaultById(Profile userinfo, int id)
    {
      Vault vault = _vaultsRepo.GetVaultById(id);
      //If vault is null throw exception
      if (vault == null)
      {
        throw new Exception("Invalid Vault Id");
      }
      // if vault is private and user is creator, CAN access.
      // if vault is private and user is not creator, cant access
      // if not private, can access
      else if (vault.IsPrivate == true && vault.CreatorId != userinfo.Id)
      {
        throw new Exception("This vault is private and only viewable by it's owner!");
      }
      // else if (vault.IsPrivate == true && userinfo == null)
      // {
      //   throw new Exception("This vault is private and only viewable by it's owner!");
      // }
      return vault;
    }

    internal Vault Update(Vault v, string id)
    {
      Vault vault = _vaultsRepo.GetVaultById(v.Id);
      if (vault == null)
      {
        throw new Exception("Invalid Id");
      }
      if (vault.CreatorId != id)
      {
        throw new Exception("Only the owner of this vault can edit it.");
      }

      return _vaultsRepo.Update(v);
    }

    internal void DeleteVault(int id, string userId)
    {
      Vault vault = _vaultsRepo.GetVaultById(id);
      //check that creator is user.
      if (vault.CreatorId != userId)
      {
        throw new Exception("Only the owner of this vault can delete it.");
      }
      _vaultsRepo.DeleteVault(id);
    }

    internal List<VaultKeepsViewModel> GetVkeepsByVaultId(int vaultId, string userId)
    {
      Vault vault = _vaultsRepo.GetVaultById(vaultId);
      if (vault == null)
      {
        throw new Exception("Invalid Id");
      }
      else if (vault.IsPrivate == true)
      {
        throw new Exception("This vault is private!");
      }
      return _vaultsRepo.GetVkeepsByVaultId(vaultId);
    }

    internal List<Vault> GetProfileVaults(string profileId)
    {
      //Make sure signed in userId = profileId && make sure that someone who isn't signed in can't access all vaults.
      // if (userId == profileId && userId != null)
      // {
      // return _vaultsRepo.GetOwnersProfileVaults(profileId);
      // }
      //if not logged in userid doesn't match profileId OR user isn't logged in, return only public vaults.
      // return _vaultsRepo.GetPublicProfileVaults(profileId);

      // Find all to iterate over every vault to check isPrivate or creatorID?
      List<Vault> vaults = _vaultsRepo.GetProfileVaults(profileId);
      return vaults.ToList().FindAll(v => v.IsPrivate == false);

    }

  }
}
