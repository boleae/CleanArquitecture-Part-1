using ClearArchitecture.Domain.Abstractions;

namespace ClearArchitecture.Domain.Vehiculos;

public sealed class Vehiculo : Entity
{
    public Vehiculo(Guid id):base(id)
    {

    }
    
    public string? Modelo {get;private set;}
    public string? Vin {get;private set;}
    public string? Calle {get;private set;}
    public string? Departamento {get;private set;}
    public string? Provincia {get;private set;}
    public string? Ciudad {get;private set;}
    public string? Pais {get;private set;}
    public decimal Precion {get;private set;}
    public string? TipoMoneda {get;private set;}
    public decimal Mantenimiento {get;private set;}
    public string? MantenimientoTipoMoneda {get;private set;}
    public DateTime? FechaUltimoAlquiler {get;private set;}
    public List<Accesorio> Accesorios {get;private set;} = new();

}