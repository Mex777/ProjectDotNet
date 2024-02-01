using SayIt.Helpers;

namespace SayIt.Models.Tables;

public class UserDTO
{
    public string Username { get; set; }
    public string Password { get; set; }
    
    public UserRoles Role { get; set; }
}