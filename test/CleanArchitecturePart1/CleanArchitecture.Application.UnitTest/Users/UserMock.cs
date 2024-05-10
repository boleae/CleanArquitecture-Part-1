using System.Runtime.InteropServices;
using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Application.UnitTest.Users;

internal static class UserMock
{
    public static readonly Nombre Nombre = new("Eduardo");
    public static readonly Apellido Apellido = new("Garcia");
    public static readonly Email Email = new("eduargo.garcia@gmail.com");
    public static readonly PasswordHash Password = new("AfeD%%32111");

    public static User Create() => User.Create(Nombre, Apellido, Email, Password);
}