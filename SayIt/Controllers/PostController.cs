using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SayIt.Models.Posts;
using SayIt.Models.Tables;
using SayIt.Services.PostService;
using SayIt.Services.UserService;

namespace SayIt.Controllers;

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

   [HttpGet("tests")]
   public IActionResult Getposts()
   {
      return Ok(_postService.GetAllPosts2());
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

   // [HttpDelete("{name}")]
   // public IActionResult DeleteUserByName(string name)
   // {
   //    _userService.DeleteUserByName(name);
   //    return Ok();
   // }
}