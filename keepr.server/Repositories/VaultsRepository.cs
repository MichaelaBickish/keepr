using System;
using System;
using keepr.server.Models;
using System.Data;
using keepr.server.Models;

namespace keepr.server.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Vault Create(Vault newVault)
    {
      throw new NotImplementedException();
    }

    internal Vault GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal Vault Update(Vault v)
    {
      throw new NotImplementedException();
    }

    internal void DeleteVault(int id)
    {
      throw new NotImplementedException();
    }
  }
}