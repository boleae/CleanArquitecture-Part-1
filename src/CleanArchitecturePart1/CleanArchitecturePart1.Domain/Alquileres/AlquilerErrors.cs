using ClearArchitecture.Domain.Abstractions;

namespace ClearArchitecture.Domain.Alquileres;

public static class AlquilerErrors 
{
    public static Error NotFound = new Error(
        "Alquiler.NotFound",
        "El alquiler con el Id especificado no fue encontrado"
    );

    public static Error Overlap = new Error(
        "Alquiler.Overlap",
        "El alquiler está siendo tomado por dos o más clientes al mismo tiempo en la misma fecha"

    );

    public static Error NotReserved = new Error(
        "Alquiler.NotReserved",
        "El alquiler no está reservado"
    );

    public static Error NotConfirmed = new Error(
        "Alquiler.NotConfirmed",
        "El alquiler no está confirmado"
    );

    public static Error AlreadyStarted = new Error(
        "Alquiler.NotConfirmed",
        "El alquiler ya ha comenzado"
    );

}