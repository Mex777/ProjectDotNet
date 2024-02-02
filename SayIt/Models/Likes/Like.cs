using SayIt.Models.Base;
using SayIt.Models.Posts;
using SayIt.Models.Tables;

namespace SayIt.Models.Likes;

public class Like : BaseEntity
{
    public Guid UserId { get; set; }    
    public virtual User User { get; set; }
    
    public Guid PostId { get; set; }
    public virtual Post Post { get; set; }
    
    public DateTime LikeTime { get; set; } 
}