using Microsoft.AspNetCore.Mvc;
using SayIt.Services.LikeService;

namespace SayIt.Controllers;

[ApiController]
[Route("[controller]")]
public class LikeController : ControllerBase
{
    private readonly ILikeService _service;

    public LikeController(ILikeService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public IActionResult AddLike(Guid userId, Guid postId)
    {
       _service.AddLike(userId, postId);
       return Ok();
    }
    
    [HttpDelete]
    public IActionResult RemoveLike(Guid userId, Guid postId)
    {
       _service.DeleteLike(userId, postId);
       return Ok();
    }

    [HttpGet("/users/{username}/likes")]
    public IActionResult GetLikedPosts(string username)
    {
        return Ok(_service.GetLikedPosts(username));
    }
    
    [HttpGet("/posts/{postId}/likes")]
    public IActionResult GetPostLikes(Guid postId)
    {
        return Ok(_service.GetPostLikes(postId));
    }
}