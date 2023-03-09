
using Cross_Zero.Core.Context;
using Cross_Zero.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cross_Zero.Infrastructure.Context
{
    #pragma warning disable CS8618
    public class ApplicationContextEF : DbContext, IApplicationContextEF
    {
        public DbSet<Game> Games { get; }

        public DbSet<User> Users { get; }

        public ApplicationContextEF(DbContextOptions<ApplicationContextEF> options):base(options)
        {
            Database.EnsureCreated();
        }

        public Task<int> SaveChangesAsync()
        {
           return base.SaveChangesAsync();
        }
    }
}
