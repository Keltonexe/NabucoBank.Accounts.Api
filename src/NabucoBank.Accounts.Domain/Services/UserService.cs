using NabucoBank.Accounts.Domain.Interfaces;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            return await _userRepository.CreateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<UserModel> GetUserByCpf(string cpf)
        {
            return await _userRepository.GetUserByCpf(cpf);
        }

        public async Task<UserModel> GetUserByIdAsync(long id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<bool> UpdateUserAsync(UserModel user, long id)
        {
            return await _userRepository.UpdateUserAsync(user, id);
        }
    }
}
