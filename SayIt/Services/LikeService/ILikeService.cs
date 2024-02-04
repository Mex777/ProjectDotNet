using SayIt.Models.Posts;
using SayIt.Models.Tables;

namespace SayIt.Services.LikeService;

public interface ILikeService
{
    List<PostDTO> GetLikedPosts(string username);

    List<UserDTO> GetPostLikes(Guid postId);

    void AddLike(Guid userId, Guid postId);

    void DeleteLike(Guid userId, Guid postId);

    public bool LikedPost(Guid userId, Guid postId);
}