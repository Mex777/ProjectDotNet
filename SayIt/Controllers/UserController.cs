using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SayIt.Models.Tables;
using SayIt.Services.UserService;

namespace SayIt.Controllers;

[Authorize]
[ApiController]
[Route("/users")]
public class UserController : ControllerBase
{ 
   private readonly IUserService _userService;

   public UserController(IUserService userService)
   {
      _userService = userService;
   }
   
   [HttpGet]
   public IActionResult GetUsers()
   {
      return Ok(_userService.GetAllUsers());
   }

   [Authorize(Roles = "Admin")]
   [HttpDelete("{name}")]
   public IActionResult DeleteUserByName(string name)
   {
      _userService.DeleteUserByName(name);
      return Ok();
   }
   
   [HttpPut("{name}")]
   public IActionResult ChangeUserByName(string name, UserDTO changes)
   {
      var usr = _userService.UpdateUserByName(name, changes);
      return Ok(usr);
   }
}