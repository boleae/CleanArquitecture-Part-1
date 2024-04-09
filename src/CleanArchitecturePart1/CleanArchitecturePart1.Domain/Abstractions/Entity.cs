using System.Reflection.Metadata.Ecma335;

namespace CleanArchitecture.Domain.Abstractions;

public abstract class Entity<TEntityId> : IEntity
{

    protected Entity() {

    }
    private readonly List<IDomainEvent> _domainEvents = new();
    protected Entity(TEntityId id) 
    {
        Id = id;
    }
    
    //El Init hace que el Id nunca cambien
    public TEntityId? Id {get;init;}

    public IReadOnlyList<IDomainEvent> GetDomainEvents() {
        return _domainEvents.ToList();
    }

    public void CleanDomainEvents() {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent) {
        _domainEvents.Add(domainEvent);
    }


}