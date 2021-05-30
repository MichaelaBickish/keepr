using System;
using System;
using keepr.server.Models;
using System.Data;
using keepr.server.Models;
using Dapper;
using System.Linq;
using System.Collections.Generic;

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
      string sql = @"
                INSERT INTO
                vaults(name, description, isPrivate, img)
                VALUES (@Name, @Description, @IsPrivate, @Img);
                SELECT LAST_INSERT_ID();
            ";
      newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
      return newVault;
    }

    internal Vault GetById(int id)
    {
      string sql = @"
            SELECT 
                v.*, 
                a.* 
            FROM vaults v 
            JOIN accounts a ON a.id = v.creatorId
            WHERE v.id = @Id";
      return _db.Query<Vault, Profile, Vault>(sql, (v, a) =>
      {
        v.Creator = a;
        return v;
      }, new { id }).FirstOrDefault();
    }

    internal Vault Update(Vault v)
    {
      string sql = @"
            UPDATE vaults 
            SET 
                name = @Name,
                description = @Description,
                isPrivate = @IsPrivate,
                img = @Img
            WHERE id = @Id;
            ";
      _db.Execute(sql, v);
      return v;
    }

    internal void DeleteVault(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<VaultKeepsViewModel> GetVkeepsByVaultId(int vaultId)
    {
      // repo: join account, vault & keep info.
      string sql = @"
                SELECT 
                k.*,
                vk.id AS vaultKeepId
                FROM vault_keeps vk
                INNER JOIN keeps k ON k.id = vk.keepId
                WHERE vaultId = @VaultId";
      return _db.Query<VaultKeepsViewModel>(sql, new { vaultId });
    }
  }
}