

using Cross_Zero.Core.Entities;

namespace Cross_Zero.Core.Repository
{
    public interface IUserRepository
    {
        Task<int> AddUser(User user);
        Task<List<User>> GetAllUsers(); 
    }
}
