using SayIt.Models.Base;
using SayIt.Models.Likes;
using SayIt.Models.Tables;

namespace SayIt.Models.Posts;

public class Post : BaseEntity
{
    public string Text { get; set; }
    
    public virtual User Author { get; set; }
    
    public virtual List<Like> Likes { get; set; }
}