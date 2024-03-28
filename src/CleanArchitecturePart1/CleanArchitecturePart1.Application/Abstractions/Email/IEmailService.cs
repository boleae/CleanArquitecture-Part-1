namespace ClearArchitecture.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(ClearArchitecture.Domain.Users.Email recipient, string subject, string body);
}