

using Cross_Zero.Core.Entities;
using Cross_Zero.Core.Repository;
using Cross_Zero.Core.Services;

namespace Cross_Zero.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<int> CreateUser(string nickName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsers()
        {
           return await _userRepository.GetAllUsers();
        }
    }
}
