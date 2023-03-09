using Cross_Zero.Core.Context;
using Cross_Zero.Core.Entities;
using Cross_Zero.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cross_Zero.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationContextEF _context;
        public UserRepository(IApplicationContextEF context)
        {
            _context = context;
        }

        public Task<int> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var result = await _context.Users.ToListAsync();

            return result;
        }
    }
}
