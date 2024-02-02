using Microsoft.EntityFrameworkCore;
using SayIt.Data;
using SayIt.Models.Likes;
using SayIt.Models.Posts;
using SayIt.Models.Tables;
using SayIt.Repositories.GenericRepository;

namespace SayIt.Repositories.LikeRepository;

public class LikeRepository : GenericRepository<Like>, ILikeRepository
{
   public LikeRepository(Context context) : base(context) {}

   public List<Post> LikedPostsByUsername(string username)
   {
     return _table.Include(like => like.Post.Author).Where(like => like.User.Username == username).Select(like => like.Post).ToList();
   }

   public List<User> PostLikes(Guid postId)
   {
     return _table.Where(like => like.PostId == postId).Select(like => like.User).ToList();
   }
   
   public Like GetById(Guid userId, Guid postId)
   {
       return _table.FirstOrDefault(l => l.UserId == userId && l.PostId == postId);
   }
}