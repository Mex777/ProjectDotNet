using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SayIt.Data;
using SayIt.Models.Tables;
using SayIt.Services.UserService;

namespace SayIt.Controllers;

[ApiController]
[Route("[controller]")]
public class SecurityController : ControllerBase
{
    private IConfiguration _config;
    private readonly IUserService _userService;

    private string GenerateJsonWebToken()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            null,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    } 
    
    public SecurityController(IUserService usrService, IConfiguration config)
    {
        _userService = usrService;
        _config = config;
    } 
    
    [HttpPost("register")]
    public IActionResult Register(UserDTO dto)
    {
        var usr = _userService.AddUser(dto); 
        return Ok(usr);
    }

    [HttpPost("login")]
    public IActionResult Login(UserDTO user)
    {
        if (_userService.Login(user))
        {
            return Ok(GenerateJsonWebToken());
        }

        return NotFound();
    }
}