using SayIt.Repositories.PostRepository;
using SayIt.Repositories.UserRepository;
using SayIt.Services.PostService;
using SayIt.Services.UserService;

namespace SayIt.Helpers.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPostService, PostService>();

        return services;
    } 
}