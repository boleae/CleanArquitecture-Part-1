using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User,UserId>, IUsersRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}