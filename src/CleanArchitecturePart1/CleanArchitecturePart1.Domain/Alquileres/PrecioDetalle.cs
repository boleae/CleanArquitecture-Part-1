using ClearArchitecture.Domain.Vehiculos;

namespace ClearArchitecture.Domain.Alquileres;

public record PrecioDetalle(Moneda PrecioPorPeriodo,
                            Moneda Mantenimiento,
                            Moneda Accesorios,
                            Moneda PrecioTotal);