using CleanArchitecture.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure;

public sealed class ApplicationDbContext : DbContext,IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options):base(options) 
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}