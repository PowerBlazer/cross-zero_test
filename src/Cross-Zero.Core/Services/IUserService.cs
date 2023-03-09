

using Cross_Zero.Core.Entities;

namespace Cross_Zero.Core.Services
{
    public interface IUserService
    {
        Task<int> CreateUser(string nickName);
        Task<List<User>> GetUsers();
    }
}
