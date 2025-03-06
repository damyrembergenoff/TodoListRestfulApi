using Microsoft.Extensions.DependencyInjection;
using TodoList.Application.Interfaces;
using TodoList.Application.Services;

namespace TodoList.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
