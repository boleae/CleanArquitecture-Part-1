using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Application.Users.RegisterUser;

internal class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
    {
        _usersRepository = usersRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request, 
        CancellationToken cancellationToken)
    {
        var userExists = await _usersRepository.IsUserExists(new Domain.Users.Email(request.Email));
        if(userExists)
            return Result.Failure<Guid>(UserErrors.AlreadyExists);
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = User.Create(
            new Nombre(request.Nombre),
            new Apellido(request.Apellidos),
            new Email(request.Email),
            new PasswordHash(passwordHash)
        );

        _usersRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return user.Id!.Value;
       
        
    }
}
