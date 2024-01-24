using SayIt.Models.Tables;

namespace SayIt.Services.UserService;

public interface IUserService
{
    public List<User> GetAllUsers();

    public UserDTO GetUserDtoByName(string name);

    public User AddUser(UserDTO user);

    public bool Login(UserDTO user);
}