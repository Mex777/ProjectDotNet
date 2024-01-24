using SayIt.Models.Tables;
using SayIt.Repositories.GenericRepository;

namespace SayIt.Repositories.UserRepository;

public interface IUserRepository : IGenericRepository<User>
{
    public User FindUserByName(string username);
}