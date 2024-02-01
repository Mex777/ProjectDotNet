using Microsoft.EntityFrameworkCore;
using SayIt.Data;
using SayIt.Models.Posts;
using SayIt.Repositories.GenericRepository;

namespace SayIt.Repositories.PostRepository;

public class PostRepository : GenericRepository<Post>, IPostRepository
{ 
   public PostRepository(Context context) : base(context) {}

   public List<Post> GetAllWithAuthors()
   {
      return _table.AsNoTracking().Include(p => p.Author).ToList();
   }
}