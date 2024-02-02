using SayIt.Models.Likes;
using SayIt.Models.Posts;
using SayIt.Models.Tables;
using SayIt.Repositories.GenericRepository;

namespace SayIt.Repositories.LikeRepository;

public interface ILikeRepository : IGenericRepository<Like>
{
   List<Post> LikedPostsByUsername(string username);

   List<User> PostLikes(Guid postId);

   Like GetById(Guid userId, Guid postId);
}