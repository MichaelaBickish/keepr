using System;
using System.ComponentModel.DataAnnotations;

namespace keepr.server.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatorId { get; set; }
    // [Required]
    public string Name { get; set; }
    // [Required]
    public string Description { get; set; }
    // [Required]
    public string Img { get; set; } = "//placehold.it/200x200";
    public int Views { get; set; } = 0;
    public int Shares { get; set; } = 0;
    public int Keeps { get; set; } = 0;
    public Profile Creator { get; set; }
  }

  // public int Id { get; set; }
  // public DateTime CreatedAt { get; set; }
  // public DateTime UpdatedAt { get; set; }
  // // [Required]
  // public string CreatorId { get; set; }
  // public Profile Creator { get; set; }
  // // [Required]
  // [MinLength(1)]

  // public string Name { get; set; }

  // public string Description { get; set; } = "No Description";
  // public string Img { get; set; } = "http://placehold.it/150x150";
  // public int Views { get; set; } = 0;
  // public int Shares { get; set; } = 0;
  // public int Keeps { get; set; } = 0;
  // }
}