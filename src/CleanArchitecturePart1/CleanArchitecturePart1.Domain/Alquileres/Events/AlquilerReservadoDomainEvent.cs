using ClearArchitecture.Domain.Abstractions;

namespace ClearArchitecture.Domain.Alquileres.Events;

public sealed record AlquilerReservadoDomainEvent(Guid alquilerId):IDomainEvent;