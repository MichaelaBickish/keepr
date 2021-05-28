using System;

namespace keepr.server.Models
{
  public class Profile
  {
    // no account model. 1 profile model
    // Both an account controller & profile controller
    // 1 profile service & repo. no account service or repo.

    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Picture { get; set; }
  }
}