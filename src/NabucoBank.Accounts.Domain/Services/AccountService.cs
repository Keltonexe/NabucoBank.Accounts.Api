using NabucoBank.Accounts.Domain.Interfaces;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Services
{
    public class AccountService : IAccountService
    {
        readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<AccountModel> CreateAccountAsync(AccountModel account)
        {
            return await _accountRepository.CreateAccountAsync(account);
        }

        public async Task<bool> DeleteAccountAsync(long id)
        {
            return await _accountRepository.DeleteAccountAsync(id);
        }

        public async Task<AccountModel> GetAccountByIdAsync(long id)
        {
            return await _accountRepository.GetAccountByIdAsync(id);
        }

        public async Task<IEnumerable<AccountModel>> GetAllAccountsAsync()
        {
            return await _accountRepository.GetAllAccountsAsync();
        }

        public async Task<bool> UpdateAccountAsync(AccountModel account)
        {
            return await _accountRepository.UpdateAccountAsync(account);
        }
    }
}
