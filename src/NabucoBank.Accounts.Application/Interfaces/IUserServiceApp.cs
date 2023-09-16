using NabucoBank.Accounts.Application.Payloads;
using NabucoBank.Accounts.Application.ViewModels;

namespace NabucoBank.Accounts.Application.Interfaces
{
    public interface IUserServiceApp
    {
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
        Task<UserViewModel> GetUserByIdAsync(long id);
        Task<UserViewModel> CreateUserAsync(UserPayload payload);
        Task<bool> UpdateUserAsync(UserPayload payload, long id);
        Task<bool> DeleteUserAsync(long id);
    }
}
