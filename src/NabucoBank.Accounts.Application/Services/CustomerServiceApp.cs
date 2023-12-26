using AutoMapper;
using NabucoBank.Accounts.Application.Interfaces;
using NabucoBank.Accounts.Application.Payloads;
using NabucoBank.Accounts.Application.ViewModels;
using NabucoBank.Accounts.Domain.Interfaces;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Application.Services
{
    public class CustomerServiceApp : ICustomerServiceApp
    {
        readonly ICustomerService _customerService;
        readonly IMapper _mapper;
        public CustomerServiceApp(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        public async Task<CustomerViewModel> CreateCustomerAsync(CustomerPayload payload)
        {
            var customer = await GetCustomerByDocumentAsync(payload.Document);

            if (customer == null)
                return _mapper.Map<CustomerViewModel>(await _customerService.CreateCustomerAsync(_mapper.Map<CustomerModel>(payload)));

            return null;
        }

        public async Task<bool> DeleteCustomerAsync(long id) => await _customerService.DeleteCustomerAsync(id);

        public async Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync() => _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerService.GetAllCustomersAsync());

        public async Task<CustomerViewModel> GetCustomerByDocumentAsync(string document) => _mapper.Map<CustomerViewModel>(await _customerService.GetCustomerByDocumentAsync(document));

        public async Task<CustomerViewModel> GetCustomerByIdAsync(long id) => _mapper.Map<CustomerViewModel>(await _customerService.GetCustomerByIdAsync(id));

        public async Task<bool> UpdateCustomerAsync(CustomerPayload payload) => await _customerService.UpdateCustomerAsync(_mapper.Map<CustomerModel>(payload));
    }
}
