using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Users;

public static class UserErrors {
    public static Error NotFound = new(
        "User.NotFound",
        "No existe el usuario buscado por este Id"
    );

    public static Error InvalidCredentials = new(
        "User.InvalidCredentials",
        "Las credenciales son incorrectas"
    );

    public static Error AlreadyExists = new(
        "User.UserAlreadyExists",
        "El usuario ya existe en la base de datos"
    );
}