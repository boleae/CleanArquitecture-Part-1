namespace CleanArchitecture.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(CleanArchitecture.Domain.Users.Email recipient, string subject, string body);
}