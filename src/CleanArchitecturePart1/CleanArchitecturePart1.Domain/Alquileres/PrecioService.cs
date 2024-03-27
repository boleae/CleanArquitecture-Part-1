using ClearArchitecture.Domain.Vehiculos;

namespace ClearArchitecture.Domain.Alquileres;

public class PrecioService 
{
    public PrecioDetalle CalcularPrecio(Vehiculo vehiculo, DateRange periodo)
    {
        var moneda = vehiculo.Precio!.TipoMoneda;
        var precioPorPeriodo = new Moneda(
            periodo.CantidadDias * vehiculo.Precio.Monto, 
            moneda);
        decimal porcentageChange = 0;

        foreach(var accesorio in vehiculo.Accesorios)
        {
            porcentageChange += accesorio switch 
            {
                Accesorio.AppleCar or Accesorio.AndroidCar => 0.05m,
                Accesorio.AireAcondicionado => 0.01m,
                Accesorio.Mapas => 0.01m,
                 _=> 0

            };

        }

        var accesorioCharges = Moneda.Zero(moneda);
        if(porcentageChange > 0)
            accesorioCharges = new Moneda(precioPorPeriodo.Monto * porcentageChange, moneda);
        
        var precioTotal = Moneda.Zero(moneda);
        precioTotal += precioPorPeriodo;
        if(!vehiculo!.Mantenimiento!.IsZero(moneda)) {
            precioTotal += vehiculo.Mantenimiento;

        }

        precioTotal += accesorioCharges;

        return new PrecioDetalle(precioPorPeriodo, 
                                vehiculo.Mantenimiento,
                                accesorioCharges,
                                precioTotal);

    }
}