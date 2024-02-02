using AutoMapper;
using SayIt.Models.Likes;
using SayIt.Models.Posts;
using SayIt.Models.Tables;
using SayIt.Repositories.LikeRepository;

namespace SayIt.Services.LikeService;

public class LikeService : ILikeService
{
    private readonly ILikeRepository _repo;
    private readonly IMapper _mapper;

    public LikeService(ILikeRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public List<PostDTO> GetLikedPosts(string username)
    {
        var posts = _repo.LikedPostsByUsername(username);
        var dtoList = new List<PostDTO>();

        foreach (var post in posts)
        {
           dtoList.Add(_mapper.Map<PostDTO>(post)); 
        }

        return dtoList;
    } 
    
    public List<UserDTO> GetPostLikes(Guid postId)
    {
        var users = _repo.PostLikes(postId);
        var dtoList = new List<UserDTO>();

        foreach (var user in users)
        {
           dtoList.Add(_mapper.Map<UserDTO>(user)); 
        }

        return dtoList;
    }

    public void AddLike(Guid userId, Guid postId)
    {
        if (_repo.GetById(userId, postId) == null)
        {
            var newLike = new Like
            {
                UserId = userId,
                PostId = postId,
                LikeTime = DateTime.UtcNow
            };

            _repo.Create(newLike);
            _repo.Save();
        }
    }

    public void DeleteLike(Guid userId, Guid postId)
    {
        var toDelete = _repo.GetById(userId, postId);

        if (toDelete != null)
        {
            _repo.Delete(toDelete);
            _repo.Save();
        }
    }
}