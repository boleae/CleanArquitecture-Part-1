using ClearArchitecture.Application.Abstractions.Email;
using ClearArchitecture.Domain.Alquileres;
using ClearArchitecture.Domain.Alquileres.Events;
using MediatR;

namespace ClearArchitecture.Application.Alquileres.ReservarAlquiler;

internal sealed class ReservarAlquilerDomainEventHandler
: INotificationHandler<AlquilerReservadoDomainEvent>
{
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly IUsersRepository _userRepository;
    private readonly IEmailService _emailService;
public ReservarAlquilerDomainEventHandler(IAlquilerRepository alquilerRepository, 
                                            IUsersRepository userRepository, 
                                            IEmailService emailService)
    {
        _alquilerRepository = alquilerRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(AlquilerReservadoDomainEvent notification, CancellationToken cancellationToken)
    {
        var alquiler = await _alquilerRepository.GetByIdAsync(notification.alquilerId, cancellationToken);
        if(alquiler is null)
            return;
        var user = await _userRepository.GetByIdAsync(alquiler.UserId, cancellationToken);
        if(user is null)
            return;
        await _emailService.SendAsync(user.Email!, "Alquiler reservado", "Tienes que confirmar esta reserva, de lo contrario se perderá");

    }
}
