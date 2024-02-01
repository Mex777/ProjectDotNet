using Microsoft.EntityFrameworkCore;
using SayIt.Data;
using SayIt.Models.Tables;
using SayIt.Repositories.GenericRepository;

namespace SayIt.Repositories.UserRepository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(Context context) : base(context) {}

    public User FindUserByName(string username)
    {
        var result = _table.Include(u => u.Posts).FirstOrDefault(usr => usr.Username.Equals(username));
        return result;
    }

    public void LoadPosts(User user)
    {   
        // Eager load the Posts collection
        _table.Entry(user).Collection(u => u.Posts).Load();
    } 
}