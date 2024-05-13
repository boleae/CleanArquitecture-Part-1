using CleanArchitecture.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Infrastructure.Authentication;

internal sealed class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccesor;

    public UserContext(IHttpContextAccessor httpContextAccesor)
    {
        _httpContextAccesor = httpContextAccesor;
    }

    public string UserEmail => _httpContextAccesor.HttpContext?.User.GetUserEmail() ?? throw new ApplicationException("User Context is Invalid");

    public Guid UserId => _httpContextAccesor.HttpContext?.User.GetUserId() ?? throw new ApplicationException("User Context is Invalid");
}