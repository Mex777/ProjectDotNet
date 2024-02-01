using SayIt.Models.Base;
using SayIt.Models.Posts;

namespace SayIt.Models.Tables;

public class User : BaseEntity
{
    public string? Username { get; set; }
    
    public string? Password { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}