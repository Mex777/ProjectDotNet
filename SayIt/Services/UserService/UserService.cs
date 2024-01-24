using Microsoft.AspNetCore.Http.HttpResults;
using SayIt.Models.Tables;
using SayIt.Repositories.GenericRepository;
using SayIt.Repositories.UserRepository;

namespace SayIt.Services.UserService;

public class UserService : IUserService
{
    private IUserRepository _userRepo;

    public UserService(IUserRepository repo)
    {
        _userRepo = repo;
    }
    
    public List<User> GetAllUsers()
    {
        return _userRepo.GetAll();
    }

    public UserDTO GetUserDtoByName(string name)
    {
        return new UserDTO();
    }

    public User AddUser(UserDTO user)
    {
        var newUser = new User
            {
                 Id = Guid.NewGuid(),
                 Username = user.Username,
                 DateCreated = new DateTime(),
                 DateModified = new DateTime(),
                 Password = user.Password
             };

        _userRepo.Create(newUser);
        _userRepo.Save();

        return newUser;
    }

    public bool Login(UserDTO user)
    {
        var dbUser = _userRepo.FindUserByName(user.Username);
        return dbUser.Password == user.Password;
    }
}