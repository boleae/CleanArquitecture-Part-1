using MediatR;

namespace CleanArchitecture.Domain.Abstractions;

//publisher: se encarga de enviar los eventos. Publicará un DomainEvent
// subscriber: se encarga de suscribirse a los eventos
public interface IDomainEvent: INotification
{

}