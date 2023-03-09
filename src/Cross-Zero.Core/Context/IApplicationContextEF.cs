
using Cross_Zero.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cross_Zero.Core.Context
{
    public interface IApplicationContextEF
    {
        DbSet<Game> Games { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync();
    }
}