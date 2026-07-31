using Gymy.DataAccess.Repositories;
using Jym.DataAccess.Data.Contexts;
using Jym.DataAccess.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Jym.DataAccess;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJymDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<JymDbContext>(options =>
            options.UseSqlServer(connectionString));

        // generic repository registration — covers any TEntity automatically
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // feature-specific repositories still need their own line
        services.AddScoped<IPlanRepository, PlanRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();

        return services;
    }
}