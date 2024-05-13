using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CleanArchitecture.Domain.Users;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;

namespace CleanArchitecture.Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions 
{
    public static string GetUserEmail(this ClaimsPrincipal? claimsPrincipal)
    {
        return claimsPrincipal?.FindFirstValue(ClaimTypes.Email) ?? throw new ApplicationException("El email no está disponible");
    }

    public static Guid GetUserId(this ClaimsPrincipal? claimsPrincipal)
    {
        var userIdOV = claimsPrincipal?.FindFirstValue(ClaimTypes.NameIdentifier);

        return Guid.TryParse(userIdOV, out var parserUserId) ?
            parserUserId :
            throw new ApplicationException("El userId no está disponible");

        
       

    }
}