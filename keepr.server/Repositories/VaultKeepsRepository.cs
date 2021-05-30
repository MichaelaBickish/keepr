using System;
using System.Data;
using Dapper;
using keepr.server.Models;

namespace keepr.server.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }


    public VaultKeeps Create(VaultKeeps vk)
    {
      string sql = @"
            INSERT INTO 
                vault_keeps(vaultId, keepId)
            VALUES(@VaultId, @KeepId);
            SELECT LAST_INSERT_ID();
            ";
      vk.Id = _db.ExecuteScalar<int>(sql, vk);
      return vk;
    }
  }
}