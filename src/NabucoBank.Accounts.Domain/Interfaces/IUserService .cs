using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByCpf(string cpf);
        Task<UserModel> GetUserByIdAsync(long id);
        Task<UserModel> CreateUserAsync(UserModel user);
        Task<bool> UpdateUserAsync(UserModel user, long id);
        Task<bool> DeleteUserAsync(long id);
    }
}
