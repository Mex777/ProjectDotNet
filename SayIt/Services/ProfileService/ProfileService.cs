using AutoMapper;
using SayIt.Models.Profile;
using SayIt.Repositories.ProfileRepository;

namespace SayIt.Services.ProfileService;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _repository;
    private readonly IMapper _mapper;

    public ProfileService(IProfileRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public ProfileDTO GetProfileById(string username)
    {
        return _mapper.Map<ProfileDTO>(_repository.FindProfileByUsername(username));
    }

    public ProfileDTO UpdateProfile(string username, string description, string profilePic)
    { 
        var profile = _repository.FindProfileByUsername(username);
        profile.ProfilePic = profilePic;
        profile.Description = description;
        _repository.Save();
        return _mapper.Map<ProfileDTO>(profile);
    }
}