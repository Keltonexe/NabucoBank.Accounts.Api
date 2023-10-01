using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountModel>> GetAllAccountsAsync();
        Task<AccountModel> GetAccountByIdAsync(long id);
        Task<AccountModel> GetAccountByUserIdAsync(long id);
        Task<AccountModel> CreateAccountAsync(AccountModel account);
        Task<bool> UpdateAccountAsync(AccountModel account);
        Task<bool> DeleteAccountAsync(long id);
    }
}
