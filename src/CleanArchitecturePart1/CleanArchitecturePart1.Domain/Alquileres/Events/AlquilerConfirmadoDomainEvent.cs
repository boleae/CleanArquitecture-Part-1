using ClearArchitecture.Domain.Abstractions;

namespace ClearArchitecture.Domain.Alquileres.Events;

public sealed record AlquilerConfirmadoDomainEvent(Guid alquilerId):IDomainEvent;