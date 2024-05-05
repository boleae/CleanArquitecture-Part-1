using CleanArchitecture.Domain.UnitTest.Infrastructura;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Users.Events;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Domain.UnitTest.Users;

public class UserTest : BaseTest
{
    [Fact]
    public void Create_Should_Set_PropertyValues()
    {
        //Arrange --> Vamos a crear un MockFile --> UserMock

        //Act
        var user = User.Create(UserMock.Nombre, UserMock.Apellido, UserMock.Email, UserMock.Password);

        //Assert
        user.Nombre.Should().Be(UserMock.Nombre);
        user.Apellido.Should().Be(UserMock.Apellido);
        user.Email.Should().Be(UserMock.Email);
        user.PasswordHash.Should().Be(UserMock.Password);
    }

    [Fact]
    public void Create_Should_RaiseUserCreateDomainEvent()
    {
        var user = User.Create(UserMock.Nombre, UserMock.Apellido, UserMock.Email,UserMock.Password);
       // var domainEvent = user.GetDomainEvents().OfType<UserCreatedDomainEvent>().SingleOrDefault();
       var domainEvent = AssertDomainEventWasPublished<UserCreatedDomainEvent>(user);

        domainEvent!.userId.Should().Be(user.Id);
    }

}