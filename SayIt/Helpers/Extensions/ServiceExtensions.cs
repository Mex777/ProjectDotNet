using SayIt.Repositories.PostRepository;
using SayIt.Repositories.ProfileRepository;
using SayIt.Repositories.UserRepository;
using SayIt.Services.PostService;
using SayIt.Services.ProfileService;
using SayIt.Services.UserService;

namespace SayIt.Helpers.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IProfileService, ProfileService>();

        return services;
    } 
}