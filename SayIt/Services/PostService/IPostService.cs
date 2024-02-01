using SayIt.Models.Posts;

namespace SayIt.Services.PostService;

public interface IPostService
{
    PostDTO AddPost(PostDTO post);

    List<PostDTO> GetAllPosts();

    List<PostDTO> GetPostsByUsername(string username);

    public List<Post> GetAllPosts2();
}