using ClearArchitecture.Domain.Vehiculos;

namespace ClearArchitecture.Domain.Alquileres;

public record PrecioDetalle(Moneda precioPorPeriodo,
                            Moneda mantenimiento,
                            Moneda accesorios,
                            Moneda precioTotal);