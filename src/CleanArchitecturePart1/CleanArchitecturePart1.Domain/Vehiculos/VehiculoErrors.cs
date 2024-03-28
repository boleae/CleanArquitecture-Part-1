using ClearArchitecture.Domain.Abstractions;

namespace ClearArchitecture.Domain.Vehiculos;

public static class VehiculoErrors
{
    public static Error NotFound = new(
        "Vehiculo.NotFound",
        "No existe un vehiculo con ese Id"
    );
}