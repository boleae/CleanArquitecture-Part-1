using MediatR.NotificationPublishers;

namespace CleanArchitecture.Application.Vehiculos.SearchVehiculos;

public sealed class VehiculoResponse 
{
    public Guid Id {get;init;}
    public string? Description {get;init;}
    public decimal Precio {get;init;}
    public string? TipoMoneda {get;init;}
    public string? Modelo {get;init;}
    public string? Vin {get;set;}
    public DireccionResponse? Direccion {get;set;}
}