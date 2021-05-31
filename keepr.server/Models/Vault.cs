using System;
using System.ComponentModel.DataAnnotations;

namespace keepr.server.Models
{
  public class Vault
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // [Required]
    public string CreatorId { get; set; }
    // [Required]
    public string Name { get; set; }
    // [Required]
    public string Description { get; set; }
    public bool IsPrivate { get; set; } = false;
    public string img { get; set; } = "//placehold.it/200x200";
    public Profile Creator { get; set; }
  }
}