using System;

namespace keepr.server.Models
{
  public class VaultKeeps
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatorId { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
  }

  public class VaultKeepsViewModel : Keep
  {
    // public int VaultId { get; set; }
    // public string VaultName { get; set; }
    // public bool IsPrivate { get; set; }
    public int VaultKeepId { get; set; }

  }
}