using Microsoft.AspNetCore.Mvc;
using SayIt.Services.ProfileService;

namespace SayIt.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
   private IProfileService _service;

   public ProfileController(IProfileService service)
   {
      _service = service;
   }
   
   [HttpGet("{username}")]
   public IActionResult GetUserProfile(string username)
   {
      return Ok(_service.GetProfileById(username));
   }

   [HttpPut("{username}")]
   public IActionResult UpdateUserProfile(string username, string description, string profilePic)
   {
      return Ok(_service.UpdateProfile(username, description, profilePic));
   }
}