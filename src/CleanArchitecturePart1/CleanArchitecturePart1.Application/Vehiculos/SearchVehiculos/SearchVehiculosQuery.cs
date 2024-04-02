using ClearArchitecture.Application.Abstractions.Messaging;

namespace ClearArchitecture.Application.Vehiculos.SearchVehiculos;

public sealed record SearchVehiculosQuery(
    DateOnly FechaInicio,
    DateOnly FechaFin
): IQuery<IReadOnlyList<VehiculoResponse>>;