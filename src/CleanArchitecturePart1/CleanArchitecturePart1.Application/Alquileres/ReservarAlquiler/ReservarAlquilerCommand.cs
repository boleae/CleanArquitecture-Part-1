namespace ClearArchitecture.Application.Alquileres.ReservarAlquiler;
using ClearArchitecture.Application.Abstractions.Messaging;

public record ReservarAlquilerCommand(
    Guid VehiculoId,
    Guid UserId,
    DateOnly FechaInicio,
    DateOnly FechaFin
) : ICommand<Guid>;