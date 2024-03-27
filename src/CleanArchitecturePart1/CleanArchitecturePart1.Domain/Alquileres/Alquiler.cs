using ClearArchitecture.Domain.Abstractions;

namespace ClearArchitecture.Domain.Alquileres;

public sealed class Alquiler : Entity
{
    public Alquiler(Guid id) : base(id)
    {

    }

    public AlquilerStatus Statis {get;private set;}
}
