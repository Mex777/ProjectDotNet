using SayIt.Models.Profile;
using SayIt.Repositories.GenericRepository;

namespace SayIt.Repositories.ProfileRepository;

public interface IProfileRepository : IGenericRepository<Profile>
{
   Profile FindProfileByUsername(string username);
}