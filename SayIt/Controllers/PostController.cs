using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SayIt.Models.Posts;
using SayIt.Models.Tables;
using SayIt.Services.PostService;
using SayIt.Services.UserService;

namespace SayIt.Controllers;

[Authorize]
[ApiController]
[Route("/posts")]
public class PostController : ControllerBase
{
   private readonly IPostService _postService;

   public PostController(IPostService postService)
   {
      _postService = postService;
   }
   
   [HttpGet]
   public IActionResult GetPosts()
   {
      return Ok(_postService.GetAllPosts());
   }

   [Authorize]
   [HttpPost]
   public IActionResult AddPost(PostDTO post)
   {
      var outcome = _postService.AddPost(post);
      // if (outcome == null)
      // {
      //    return Unauthorized();
      // }

      return Ok(outcome);
   }

   [HttpGet("{username}")]
   public IActionResult GetUserPosts(string username)
   {
      return Ok(_postService.GetPostsByUsername(username));
   }

   [HttpDelete("{postId}")]
   public IActionResult DeleteUserByName(Guid postId)
   {
      _postService.DeletePostById(postId);
      return Ok();
   }

   [HttpPut("{postId}")]
   public IActionResult ModifyPost(Guid postId, string text)
   {
      return Ok(_postService.ModifyPostById(postId, text));
   }
}