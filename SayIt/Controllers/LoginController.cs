using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SayIt.Data;
using SayIt.Helpers;
using SayIt.Models.Tables;
using SayIt.Services.UserService;

namespace SayIt.Controllers;

[ApiController]
[Route("[controller]")]
public class SecurityController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public SecurityController(IUserService usrService, IConfiguration config, IMapper mapper)
    {
        _userService = usrService;
        _config = config;
        _mapper = mapper;
    } 
    
    [HttpPost("register")]
    public IActionResult Register(UserDTO dto)
    {
        var usr = _userService.AddUser(dto); 
        return Ok(_mapper.Map<UserDTO>(usr));
    }

    [HttpPost("login")]
    public IActionResult Login(UserDTO user)
    {
        if (_userService.Login(user))
        {
            return Ok(GenerateJsonWebToken(_userService.GetUserDtoByName(user.Username)));
        }

        return NotFound();
    }

    [Authorize]
    [HttpGet]
    public IActionResult ValidToken()
    {
        return Ok();
    }
    
    private string GenerateJsonWebToken(UserDTO userDto)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userDto.Username),
            new Claim(ClaimTypes.Role, userDto.Role.ToString()),
            new Claim(ClaimTypes.SerialNumber, _userService.GetUserIdByName(userDto.Username).ToString())
        };

        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            expires: DateTime.Now.AddMinutes(60),
            claims: claims,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}