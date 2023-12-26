using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<AccountModel>> GetAllAccountsAsync();
        Task<AccountModel> GetAccountByIdAsync(long id);
        Task<AccountModel> GetAccountByCustomerIdAsync(long id);
        Task<AccountModel> CreateAccountAsync(AccountModel account);
        Task<bool> UpdateAccountAsync(AccountModel account);
        Task<bool> DeleteAccountAsync(long id);
    }
}
