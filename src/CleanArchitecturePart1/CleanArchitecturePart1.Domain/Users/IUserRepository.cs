using CleanArchitecture.Domain.Users;

public interface IUsersRepository 
{
    Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);
    void Add(User user);

}