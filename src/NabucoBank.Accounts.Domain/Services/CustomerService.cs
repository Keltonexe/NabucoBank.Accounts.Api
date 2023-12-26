using NabucoBank.Accounts.Domain.Interfaces;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<CustomerModel> CreateCustomerAsync(CustomerModel customer) => await _customerRepository.CreateCustomerAsync(customer);

        public async Task<bool> DeleteCustomerAsync(long id) => await _customerRepository.DeleteCustomerAsync(id);

        public async Task<IEnumerable<CustomerModel>> GetAllCustomersAsync() => await _customerRepository.GetAllCustomersAsync();

        public async Task<CustomerModel> GetCustomerByDocumentAsync(string document) => await _customerRepository.GetCustomerByDocumentAsync(document);

        public async Task<CustomerModel> GetCustomerByIdAsync(long id) => await _customerRepository.GetCustomerByIdAsync(id);

        public async Task<bool> UpdateCustomerAsync(CustomerModel customer) => await _customerRepository.UpdateCustomerAsync(customer);
    }
}
