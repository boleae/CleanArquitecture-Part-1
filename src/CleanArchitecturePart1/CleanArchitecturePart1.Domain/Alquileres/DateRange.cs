namespace ClearArchitecture.Domain.Alquileres;

public sealed record DateRange 
{
    private DateRange() {}

    public DateOnly Inicio {get;init;}
    public DateOnly Fin {get;init;}
    public int CantidadDias => Fin.DayNumber - Inicio.DayNumber;
    public static DateRange Create(DateOnly inicio, DateOnly final) {
        if(inicio > final)
            throw new ApplicationException("La fecha final es anterior a la fecha de inicio");
        return new DateRange {
            Inicio = inicio,
            Fin = final
        };
    }

}