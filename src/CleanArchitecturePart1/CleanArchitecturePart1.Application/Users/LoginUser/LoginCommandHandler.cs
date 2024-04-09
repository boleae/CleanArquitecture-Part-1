using CleanArchitecture.Application.Abstractions.Authentication;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Application.Users.LoginUser;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{

    private readonly IUsersRepository usersRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IUsersRepository usersRepository, IJwtProvider jwtprovider)
    {
        this.usersRepository = usersRepository;
        this._jwtProvider = jwtprovider;
    }

    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.GetByEmailAsync(new Domain.Users.Email(request.Email), cancellationToken);
        if(user is null)
            return Result.Failure<string>(UserErrors.NotFound);
        if(!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash!.Value))
            return Result.Failure<string>(UserErrors.InvalidCredentials);
        var token = await _jwtProvider.Generate(user);
        return token;
        
    }
}
