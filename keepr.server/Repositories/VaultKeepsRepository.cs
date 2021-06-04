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
      //TODO inside sql statement, update keeps count??
      //UPDATE keeps
      // SET
      //keeps = keeps +1
      string sql = @"
           UPDATE keeps
              SET
              keeps = keeps + 1
              WHERE id = @KeepId;
            INSERT INTO 
                vault_keeps(vaultId, keepId, creatorId)
            VALUES(@VaultId, @KeepId, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
      vk.Id = _db.ExecuteScalar<int>(sql, vk);
      return vk;
    }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM vault_keeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

    //Get vaultkeep by id for delete vaultkeep
    internal VaultKeepsViewModel GetVaultKeepById(int id)
    {
      string sql = @"
      SELECT * FROM vault_keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<VaultKeepsViewModel>(sql, new { id });
    }


  }
}