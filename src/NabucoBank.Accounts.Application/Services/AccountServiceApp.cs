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
        readonly IUserService _userService;
        readonly IMapper _mapper;
        public AccountServiceApp(IAccountService accountService, IUserService userService, IMapper mapper)
        {
            _accountService = accountService;
            _userService = userService;
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

        public async Task<UserAccountViewModel> GetUserAccountByCpfAsync(string cpf)
        {
            var user = await _userService.GetUserByCpfAsync(cpf);
            var account = await _accountService.GetAccountByUserIdAsync(user.Id);

            return new UserAccountViewModel
            {
                UserId = user.Id,
                Balance = account.Balance,
                Number = account.Number,
                User = new UserViewModel
                {
                    Cpf = cpf,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    CreatedAt = user.CreatedAt.ToString()
                }
            };
        }

        public async Task<bool> UpdateAccountAsync(AccountPayload payload)
        {
            return await _accountService.UpdateAccountAsync(_mapper.Map<AccountModel>(payload));
        }
    }
}
