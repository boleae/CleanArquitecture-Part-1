namespace CleanArchitecture.Application.Users.RegisterUser;

public record RegisteruserRequest(
    string Email,
    string Nombre,
    string Apellidos,
    string Password
);