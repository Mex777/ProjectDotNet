using SayIt.Models.Posts;
using SayIt.Models.Profile;

namespace SayIt.Services.ProfileService;

public interface IProfileService
{
    ProfileDTO GetProfileById(string username);

    ProfileDTO UpdateProfile(string username, string description, string profilePic);
}