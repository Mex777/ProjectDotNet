using Microsoft.EntityFrameworkCore;
using SayIt.Data;
using SayIt.Models.Posts;
using SayIt.Models.Profile;
using SayIt.Repositories.GenericRepository;

namespace SayIt.Repositories.ProfileRepository;

public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
{ 
   public ProfileRepository(Context context) : base(context) {}

   public Profile FindProfileByUsername(string username)
   { 
      var result = _table.Include(p => p.CorrespondingUser).FirstOrDefault(p => p.CorrespondingUser.Username.Equals(username));
      return result;
   }
}