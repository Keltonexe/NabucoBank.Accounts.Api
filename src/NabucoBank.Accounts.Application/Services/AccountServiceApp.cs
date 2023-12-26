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
        readonly ICustomerService _customerService;
        readonly IAddressService _addressService;
        readonly IMapper _mapper;
        public AccountServiceApp(IAccountService accountService, ICustomerService customerService, IAddressService addressService, IMapper mapper)
        {
            _accountService = accountService;
            _customerService = customerService;
            _addressService = addressService;
            _mapper = mapper;
        }
        public async Task<AccountViewModel> CreateAccountAsync(AccountPayload payload)
        {
            var customer = await _customerService.CreateCustomerAsync(_mapper.Map<CustomerModel>(payload.Customer));
            var address = await _addressService.CreateAddressWithCustomerAsync(_mapper.Map<AddressModel>(payload.Address), customer.Id);
            return _mapper.Map<AccountViewModel>(await _accountService.CreateAccountAsync(new AccountModel(customer.Id, address.Id)));
        }

        public async Task<bool> DeleteAccountAsync(long id) => await _accountService.DeleteAccountAsync(id);

        public async Task<AccountViewModel> GetAccountByIdAsync(long id) => _mapper.Map<AccountViewModel>(await _accountService.GetAccountByIdAsync(id));

        public async Task<IEnumerable<AccountViewModel>> GetAllAccountsAsync() => _mapper.Map<IEnumerable<AccountViewModel>>(await _accountService.GetAllAccountsAsync());

        public async Task<CustomerAccountViewModel> GetCustomerAccountByDocumentAsync(string document)
        {
            var customer = await _customerService.GetCustomerByDocumentAsync(document);
            var account = await _accountService.GetAccountByCustomerIdAsync(customer.Id);

            return new CustomerAccountViewModel
            {
                Number = account.Number,
                Branch = account.Branch,
                Balance = account.Balance,
                Customer = new CustomerViewModel
                {
                    Document = document,
                    Name = customer.Name,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    CreatedAt = customer.CreatedAt.ToString()
                }
            };
        }

        public async Task<bool> UpdateAccountAsync(AccountPayload payload) => await _accountService.UpdateAccountAsync(_mapper.Map<AccountModel>(payload));
    }
}
