namespace ClearArchitecture.Domain.Abstractions;

/* el patrón Unidad de Trabajo viene al rescate encapsulando estas interacciones y gestionándolas como una única unidad lógica. Esto garantiza que todos los cambios se confirmen juntos 
o se reviertan por completo en caso de error, preservando la coherencia de los datos.*/

public interface IUnitOfWork {
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
}