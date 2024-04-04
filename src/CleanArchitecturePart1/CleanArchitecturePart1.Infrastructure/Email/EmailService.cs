using ClearArchitecture.Application.Abstractions.Email;
using ClearArchitecture.Domain.Users;

namespace ClearArchitecture.Infrastructure;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Email recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}