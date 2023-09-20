using NabucoBank.Accounts.Application.Payloads;
using NabucoBank.Accounts.Application.ViewModels;

namespace NabucoBank.Accounts.Application.Interfaces
{
    public interface IAccountServiceApp
    {
        Task<IEnumerable<AccountViewModel>> GetAllAccountsAsync();
        Task<AccountViewModel> GetAccountByIdAsync(long id);
        Task<AccountViewModel> CreateAccountAsync(AccountPayload payload);
        Task<bool> UpdateAccountAsync(AccountPayload payload);
        Task<bool> DeleteAccountAsync(long id);
    }
}
