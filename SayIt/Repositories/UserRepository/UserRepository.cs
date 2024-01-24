using SayIt.Data;
using SayIt.Models.Tables;
using SayIt.Repositories.GenericRepository;

namespace SayIt.Repositories.UserRepository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(Context context) : base(context) {}

    public User FindUserByName(string username)
    {
        var result = _table.FirstOrDefault(usr => usr.Username.Equals(username));

        return result;
    }
}