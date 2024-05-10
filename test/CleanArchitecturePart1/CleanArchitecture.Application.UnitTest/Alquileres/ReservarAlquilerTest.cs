using CleanArchitecture.Application.Abstractions.Clock;
using CleanArchitecture.Application.Alquileres.ReservarAlquiler;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Vehiculos;
using NSubstitute;

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

}