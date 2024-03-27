using ClearArchitecture.Domain.Users;

public interface IUsersRepository 
{
    Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(User user);

}