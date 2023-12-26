using Bogus;
using NabucoBank.Accounts.Domain.Interfaces;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Services
{
    public class AccountService : IAccountService
    {
        readonly IAccountRepository _accountRepository;
        readonly Faker _faker;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _faker = new("pt_BR");
        }
        public async Task<AccountModel> CreateAccountAsync(AccountModel account) =>
            await _accountRepository.CreateAccountAsync(new AccountModel(account.CustomerId, account.AddressId,
                _faker.Finance.Account(), _faker.Random.Int(min: 1000, max: 9999).ToString()));

        public async Task<bool> DeleteAccountAsync(long id) => await _accountRepository.DeleteAccountAsync(id);

        public async Task<AccountModel> GetAccountByCustomerIdAsync(long id) => await _accountRepository.GetAccountByCustomerIdAsync(id);

        public async Task<AccountModel> GetAccountByIdAsync(long id) => await _accountRepository.GetAccountByIdAsync(id);

        public async Task<IEnumerable<AccountModel>> GetAllAccountsAsync() => await _accountRepository.GetAllAccountsAsync();

        public async Task<bool> UpdateAccountAsync(AccountModel account) => await _accountRepository.UpdateAccountAsync(account);
    }
}
