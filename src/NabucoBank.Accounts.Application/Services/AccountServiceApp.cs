using AutoMapper;
using NabucoBank.Accounts.Application.Interfaces;
using NabucoBank.Accounts.Application.Payloads;
using NabucoBank.Accounts.Application.ViewModels;
using NabucoBank.Accounts.Domain.Interfaces;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Application.Services
{
    public class AccountServiceApp : IAccountServiceApp
    {
        readonly IAccountService _accountService;
        readonly IMapper _mapper;
        public AccountServiceApp(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
        public async Task<AccountViewModel> CreateAccountAsync(AccountPayload payload)
        {
            return _mapper.Map<AccountViewModel>(await _accountService.CreateAccountAsync(_mapper.Map<AccountModel>(payload)));
        }

        public async Task<bool> DeleteAccountAsync(long id)
        {
            return await _accountService.DeleteAccountAsync(id);
        }

        public async Task<AccountViewModel> GetAccountByIdAsync(long id)
        {
            return _mapper.Map<AccountViewModel>(await _accountService.GetAccountByIdAsync(id));
        }

        public async Task<IEnumerable<AccountViewModel>> GetAllAccountsAsync()
        {
            return _mapper.Map<IEnumerable<AccountViewModel>>(await _accountService.GetAllAccountsAsync());
        }

        public async Task<bool> UpdateAccountAsync(AccountPayload payload, long id)
        {
            return await _accountService.UpdateAccountAsync(_mapper.Map<AccountModel>(payload), id);
        }
    }
}
