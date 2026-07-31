using Jym.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jym.BusinessLogic.ViewModels;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJymBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<IMemberService, MemberService>();

        return services;
    }
}
