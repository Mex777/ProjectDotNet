using SayIt.Models.Posts;
using SayIt.Repositories.GenericRepository;

namespace SayIt.Repositories.PostRepository;

public interface IPostRepository : IGenericRepository<Post>
{
    public List<Post> GetAllWithAuthors();
}