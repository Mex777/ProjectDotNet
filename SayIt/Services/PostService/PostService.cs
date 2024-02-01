using System.Net.Mime;
using AutoMapper;
using SayIt.Models.Posts;
using SayIt.Repositories.PostRepository;
using SayIt.Repositories.UserRepository;

namespace SayIt.Services.PostService;

public class PostService : IPostService
{
    private readonly IPostRepository _repo;

    private readonly IUserRepository _usr;

    private readonly IMapper _mapper;

    public PostService(IPostRepository repo, IUserRepository userRepository, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
        _usr = userRepository;
    }

    public PostDTO AddPost(PostDTO post)
    {
        var author = _usr.FindUserByName(post.Author);
        _usr.LoadPosts(author);
        if (author == null)
        {
            return null;
        }
        
        Post dbPost = new Post
        {
            Id = Guid.NewGuid(),
            Text = post.Text,
            Author = author
        };
        
        _repo.Create(dbPost);
        _repo.Save();
        _usr.Save();

        return _mapper.Map<PostDTO>(dbPost);
    }

    public List<PostDTO> GetAllPosts()
    {
        List<PostDTO> list = new List<PostDTO>();
        var postList = _repo.GetAllWithAuthors();

        foreach (var post in postList)
        {
            var dto = _mapper.Map<PostDTO>(post);
            dto.Author = post.Author.Username;
            list.Add(dto);
        }

        return list;
        
    }
    
    public List<Post> GetAllPosts2()
    {
        var postList = _repo.GetAllWithAuthors();
        return postList;
    }

    public List<PostDTO> GetPostsByUsername(string username)
    {
        var user = _usr.FindUserByName(username);
        var posts = new List<PostDTO>();
        foreach (var post in user.Posts)
        {
            posts.Add(_mapper.Map<PostDTO>(post)); 
        }

        return posts;
    }
}