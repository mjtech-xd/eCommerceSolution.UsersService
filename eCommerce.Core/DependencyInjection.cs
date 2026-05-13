using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension Methods to add infrastructure 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // TO DO: Add core services to the Ioc Container
        // Core services often include data access, caching and other low level components
        
        services.AddTransient<IUserService, UsersServices>();
        return services;
    }
}