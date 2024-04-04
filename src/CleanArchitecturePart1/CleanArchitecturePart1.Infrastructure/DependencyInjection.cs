using ClearArchitecture.Application.Abstractions.Clock;
using ClearArchitecture.Application.Abstractions.Email;
using ClearArchitecture.Infrastructure.Clock;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClearArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();
        return services;
    }
}