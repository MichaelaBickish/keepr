using keepr.server.Models;
using System.Data;
using Dapper;
using System.Linq;
using System.Collections.Generic;
using System;

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
                vaults(name, description, creatorId, isPrivate, img)
                VALUES (@Name, @Description, @CreatorId, @IsPrivate, @Img);
                SELECT LAST_INSERT_ID();
            ";
      newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
      return newVault;
    }

    internal Vault GetVaultById(int id)
    {
      string sql = @"
            SELECT 
                v.*, 
                a.* 
            FROM vaults v 
            JOIN accounts a ON a.id = v.creatorId
            WHERE v.id = @id;";
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

    internal List<VaultKeepsViewModel> GetVkeepsByVaultId(int vaultId)
    {
      // repo: join account, vault & keep info.
      string sql = @"
                SELECT 
                k.*,
                vk.id AS vaultKeepId,
                a.*
                FROM vault_keeps vk
                JOIN keeps k ON k.id = vk.keepId
                JOIN accounts a ON k.creatorId = a.id
                WHERE vk.vaultId = @vaultId;";
      return _db.Query<VaultKeepsViewModel, Profile, VaultKeepsViewModel>(sql, (vk, a) =>
      {
        vk.Creator = a;
        return vk;
      }, new { vaultId }, splitOn: "id").ToList();
    }

    internal List<Vault> GetPublicProfileVaults(string profileId)
    {
      string sql = @"
      SELECT
      v.*,
      a.*
      FROM 
      vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE
      v.creatorId = @profileId AND v.isPrivate = 0;";
      //  --------item1 = v item2 = a, v:what returns
      return _db.Query<Vault, Profile, Vault>(sql, (v, a) =>
      {
        v.Creator = a;
        return v;
      }, new { profileId }).ToList();
    }

    internal List<Vault> GetProfileVaults(string profileId)
    {
      string sql = @"
      SELECT
      v.*,
      a.*
      FROM 
      vaults v
      JOIN accounts a ON v.creatorId = a.id
      WHERE
      v.creatorId = @profileId AND v.isPrivate = 0;";
      //  --------item1 = v item2 = a, v:what returns
      return _db.Query<Vault, Profile, Vault>(sql, (v, a) =>
      {
        v.Creator = a;
        return v;
      }, new { profileId }).ToList();
    }
  }
}