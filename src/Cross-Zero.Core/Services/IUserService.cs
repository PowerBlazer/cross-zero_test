

namespace Cross_Zero.Core.Services
{
    public interface IUserService
    {
        Task<int> CreateUser(string nickName);
    }
}
