using System.Reflection.Metadata.Ecma335;

namespace CleanArchitecture.Domain.Abstractions;

public abstract class Entity 
{

    protected Entity() {

    }
    private readonly List<IDomainEvent> _domainEvents = new();
    protected Entity(Guid id) 
    {
        Id = id;
    }
    
    //El Init hace que el Id nunca cambien
    public Guid Id {get;init;}

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