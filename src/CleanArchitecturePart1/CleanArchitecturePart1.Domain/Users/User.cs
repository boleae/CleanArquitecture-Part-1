using System.Security.Cryptography.X509Certificates;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Users.Events;

namespace CleanArchitecture.Domain.Users;

public sealed class User : Entity
{
    private User(Guid id,
                Nombre nombre,
                Apellido apellido,
                Email email) : base(id)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;

    }

    public Nombre? Nombre {get;private set;}
    public Apellido? Apellido {get;private set;}
    public Email? Email {get;private set;}
    //Con esto, ocultamos la Lógica del constructor
    public static User Create(
        Nombre nombre,
        Apellido apellido,
        Email email
    )
    {
        var user = new User(Guid.NewGuid(), nombre, apellido, email);
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
        return user;

    }
}