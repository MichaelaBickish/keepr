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

    internal VaultKeeps CreateVaultKeep(VaultKeeps vk)
    {
      return _vaultKeepsRepo.Create(vk);
    }
  }
}