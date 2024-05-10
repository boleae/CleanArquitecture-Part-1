using System.Diagnostics;
using CleanArchitecture.Application.Abstractions.Clock;
using CleanArchitecture.Application.Alquileres.ReservarAlquiler;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.UnitTest.Users;
using CleanArchitecture.Application.UnitTest.Vehiculos;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Vehiculos;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace CleanArchitecture.Application.UnitTest.Alquileres;

public class ReservarAlquilerTests
{
    private readonly ReservarAlquilerCommandHandler _handlerMock;

    private readonly IUsersRepository _userRepositoryMock;
    private readonly IVehiculoRepository _vehiculoRepositoryMock;
    private readonly IAlquilerRepository _alquilerRepositoryMock;
    private readonly IUnitOfWork _unitOfWorkMock;
    private readonly DateTime UtcNow = DateTime.UtcNow;
    private readonly ReservarAlquilerCommand Command = new(
        Guid.NewGuid(),
        Guid.NewGuid(),
        new DateOnly(2024,1,1),
        new DateOnly(2025,1,1)

    );

    public ReservarAlquilerTests() 
    {
        _userRepositoryMock = Substitute.For<IUsersRepository>();
        _vehiculoRepositoryMock = Substitute.For<IVehiculoRepository>();
        _alquilerRepositoryMock = Substitute.For<IAlquilerRepository>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();
        IDateTimeProvider dateTimeProviderMock = Substitute.For<IDateTimeProvider>();
        dateTimeProviderMock.currentTime.Returns(UtcNow);

        _handlerMock = new ReservarAlquilerCommandHandler(
            _userRepositoryMock, 
            _vehiculoRepositoryMock,
            _alquilerRepositoryMock,
            new PrecioService(),
            _unitOfWorkMock,
            dateTimeProviderMock);
        
        


    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenUserIsNull()
    {
        //arrange
        _userRepositoryMock.GetByIdAsync(new UserId(Command.UserId), Arg.Any<CancellationToken>()).Returns((User?)null);
        

        //act
        var resultado = await _handlerMock.Handle(Command, default);

        //assert

        resultado.Error.Should().Be(UserErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenVehiculoIsNull()
    {
        //arrange
        var user = UserMock.Create();
        _userRepositoryMock.GetByIdAsync(new UserId(Command.UserId), Arg.Any<CancellationToken>()).Returns(user);

        _vehiculoRepositoryMock.GetByIdAsync( 
            new VehiculoId(Command.VehiculoId),
            Arg.Any<CancellationToken>()

        ).Returns((Vehiculo?)null);

        //act
        var resultados = await _handlerMock.Handle(Command, default);

        //assert

        resultados.Error.Should().Be(VehiculoErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenVehiculoIsAlquilado()
    {
        //arrange
        var user = UserMock.Create();
        var vehiculo = VehiculoMock.Create();
        var duracion = DateRange.Create(Command.FechaInicio, Command.FechaFin);

        _userRepositoryMock.GetByIdAsync(new UserId(Command.UserId), Arg.Any<CancellationToken>()).Returns(user);
        _vehiculoRepositoryMock.GetByIdAsync(new VehiculoId(Command.VehiculoId), Arg.Any<CancellationToken>()).Returns(vehiculo);

        _alquilerRepositoryMock.IsOverlappingAsync(vehiculo, duracion, Arg.Any<CancellationToken>()).Returns(true);

        //Act
        var resultados = await _handlerMock.Handle(Command, default);

        //Asserts
        resultados.Error.Should().Be(AlquilerErrors.Overlap);


    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenUnitOfWorkThrowException()
    {
        var user = UserMock.Create();
        var vehiculo = VehiculoMock.Create();
        var duracion = DateRange.Create(Command.FechaInicio, Command.FechaFin);

        _userRepositoryMock.GetByIdAsync(new UserId(Command.UserId), Arg.Any<CancellationToken>()).Returns(user);
        _vehiculoRepositoryMock.GetByIdAsync(new VehiculoId(Command.VehiculoId), Arg.Any<CancellationToken>()).Returns(vehiculo);

         _alquilerRepositoryMock.IsOverlappingAsync(vehiculo, duracion, Arg.Any<CancellationToken>()).Returns(false);

         _unitOfWorkMock.SaveChangesAsync().ThrowsAsync(
            new ConcurrencyException("Concurrency", new Exception())
         );

         //Act
         var resultado = await _handlerMock.Handle(Command, default);

         //Assert
         resultado.Error.Should().Be(AlquilerErrors.Overlap);


    }

    [Fact]
    public async Task Handle_Should_ReturnSuccess_WhenAlquilerIsReservado()
    {
        //Arrange
        var user = UserMock.Create();
        var vehiculo = VehiculoMock.Create();
        var duracion = DateRange.Create(Command.FechaInicio, Command.FechaFin);

        _userRepositoryMock.GetByIdAsync(new UserId(Command.UserId), Arg.Any<CancellationToken>()).Returns(user);
        _vehiculoRepositoryMock.GetByIdAsync(new VehiculoId(Command.VehiculoId), Arg.Any<CancellationToken>()).Returns(vehiculo);

        _alquilerRepositoryMock.IsOverlappingAsync(vehiculo, duracion, Arg.Any<CancellationToken>()).Returns(false);

        //Act

        var resultado = await _handlerMock.Handle(Command, default);

        //Assert

        resultado.IsSuccess.Should().BeTrue();

    }

}