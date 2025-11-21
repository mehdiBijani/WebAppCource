using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Phonebook.Infrastructure.Persistence;

namespace Phonebook.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PhonebookDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}