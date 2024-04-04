using ClearArchitecture.Application.Abstractions.Behaviors;
using ClearArchitecture.Domain.Alquileres;
using Microsoft.Extensions.DependencyInjection;

namespace ClearArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            configuration.AddOpenBehavior(typeof(LogginBehavior<,>));

        });
        services.AddTransient<PrecioService>();
        return services;
    }

}