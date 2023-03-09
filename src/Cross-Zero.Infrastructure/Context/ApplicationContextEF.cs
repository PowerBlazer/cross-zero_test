
using Cross_Zero.Core.Context;
using Cross_Zero.Core.Entities;
using Cross_Zero.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Cross_Zero.Infrastructure.Context
{
    #pragma warning disable CS8618
    public class ApplicationContextEF : DbContext, IApplicationContextEF
    {
        public ApplicationContextEF(DbContextOptions<ApplicationContextEF> options) : base(options)
        {         
            Database.EnsureCreated();
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<User> Users { get; set; }

        

        public Task<int> SaveChangesAsync()
        {
           return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
