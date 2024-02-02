using System.ComponentModel.DataAnnotations;
using SayIt.Helpers;
using SayIt.Models.Base;
using SayIt.Models.Likes;
using SayIt.Models.Posts;

namespace SayIt.Models.Tables;

public class User : BaseEntity
{
    [Required]
    public string? Username { get; set; }
    
    [Required]
    public string? Password { get; set; }
    
    [Required]
    public UserRoles Role { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    
    public virtual Profile.Profile Extra { get; set; }
    
    public virtual List<Like> Likes { get; set; }
}