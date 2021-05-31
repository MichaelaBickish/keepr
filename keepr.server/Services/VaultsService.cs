using System;
using System.Collections.Generic;
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

    internal Vault GetById(int id)
    {
      Vault v = _vaultsRepo.GetById(id);
      if (v == null)
      {
        throw new Exception("Invalid Id");
      }
      return v;
    }

    internal Vault Update(Vault v, string id)
    {
      Vault vault = _vaultsRepo.GetById(v.Id);
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
      Vault vault = GetById(id);
      //check that creator is user.
      if (vault.CreatorId != userId)
      {
        throw new Exception("Only the owner of this vault can delete it.");
      }
      _vaultsRepo.DeleteVault(id);
    }

    internal List<VaultKeepsViewModel> GetVkeepsByVaultId(int vaultId, string userId)
    {
      Vault vault = _vaultsRepo.GetById(vaultId);
      if (vault == null)
      {
        throw new Exception("Inaultalid Id");
      }
      else if (vault.IsPrivate == true)
      {
        throw new Exception("This vault is private!");
      }
      return _vaultsRepo.GetVkeepsByVaultId(vaultId);
    }
  }
}