using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Reviews;

public static class ReviewErrors 
{
    public static readonly Error NotElegible = new(
        "Review.NotElegible",
        "Este review y calificacion no es elegible porque aun no está completado el alquiler"
    );
}