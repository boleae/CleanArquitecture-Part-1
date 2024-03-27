namespace ClearArchitecture.Domain.Abstractions;

public abstract class Entity 
{
    protected Entity(Guid id) 
    {
        Id = id;
    }
    
    //El Init hace que el Id nunca cambien
    public Guid Id {get;init;}

}