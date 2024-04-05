using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUsersRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}