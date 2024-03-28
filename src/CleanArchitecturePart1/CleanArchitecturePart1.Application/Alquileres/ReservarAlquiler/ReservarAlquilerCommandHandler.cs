using ClearArchitecture.Application.Abstractions.Messaging;
using ClearArchitecture.Domain.Abstractions;
using ClearArchitecture.Domain.Alquileres;
using ClearArchitecture.Domain.Users;
using ClearArchitecture.Domain.Vehiculos;

namespace ClearArchitecture.Application.Alquileres.ReservarAlquiler;

internal sealed class ReservarAlquilerCommandHandler : ICommandHandler<ReservarAlquilerCommand, Guid>
{
    private readonly IUsersRepository _userRepository;
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly PrecioService _precioService;
    private readonly IUnitOfWork _unitOfWork;

    public ReservarAlquilerCommandHandler(
        IUsersRepository userRepository, 
        IVehiculoRepository vehiculoRepository, 
        IAlquilerRepository alquilerRepository, 
        PrecioService precioService, 
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _vehiculoRepository = vehiculoRepository;
        _alquilerRepository = alquilerRepository;
        _precioService = precioService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(ReservarAlquilerCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if(user == null) 
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var vehiculo = await _vehiculoRepository.GetByIdAsync(request.VehiculoId, cancellationToken);
        if(vehiculo == null)
        {
            return Result.Failure<Guid>(VehiculoErrors.NotFound);
        }

        var duracion = DateRange.Create(request.FechaInicio, request.FechaFin);
        if(await _alquilerRepository.IsOverlappingAsync(vehiculo, duracion, cancellationToken)) {
            return Result.Failure<Guid>(AlquilerErrors.Overlap);
        }

        var alquiler = Alquiler.Reservar(vehiculo, request.UserId, duracion, DateTime.UtcNow, _precioService);
        _alquilerRepository.Add(alquiler);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return alquiler.Id;
    }
}
