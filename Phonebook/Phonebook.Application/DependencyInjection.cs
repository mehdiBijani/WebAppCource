using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Phonebook.Application;

public static class DependencyInjection
{
    // public static IServiceCollection AddApplication(this IServiceCollection services)
    // {
    //     services.AddMediatR(typeof(DependencyInjection).Assembly);
    //     return services;
    // }
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}