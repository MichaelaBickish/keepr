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
    public string img { get; set; } = "https://images.unsplash.com/photo-1582139329536-e7284fece509?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=800&q=80";

    public Profile Creator { get; set; }
  }
}