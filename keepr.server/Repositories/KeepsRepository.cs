using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.server.Models;

namespace keepr.server.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Keep Create(Keep newKeep)
    {
      string sql = @"
                INSERT INTO
                keeps(description, img, views, shares, keeps)
                VALUES (@Description, @Img, @Views, @Shares, @Keeps);
                SELECT LAST_INSERT_ID();
            ";
      newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
      return newKeep;
    }

    internal Keep GetById(int id)
    {
      string sql = @"
            SELECT 
                k.*, 
                a.* 
            FROM keeps k 
            JOIN accounts a ON a.id = k.creatorId
            WHERE k.id = @id";
      return _db.Query<Keep, Profile, Keep>(sql, (k, a) =>
      {
        k.Creator = a;
        return k;
      }, new { id }).FirstOrDefault();
    }

    internal List<Keep> GetAll()
    {
      string sql = @"
            SELECT 
            k.*,
            a.* 
            FROM keeps k
            JOIN accounts a ON k.creatorId = a.id;";
      //  item1 = k item2 = a, what returns
      return _db.Query<Keep, Profile, Keep>(sql,
      // array.map equiv
      (k, a) =>
      {
        k.Creator = a;
        return k;
      }, splitOn: "id").ToList();
    }

    internal Keep Update(Keep k)
    {
      string sql = @"
            UPDATE keeps 
            SET 
                name = @Name,
                location = @Location,
                img = @Img
            WHERE id = @Id;
            ";
      _db.Execute(sql, k);
      return k;
    }
    internal void DeleteKeep(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}