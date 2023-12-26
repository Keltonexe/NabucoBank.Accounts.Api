using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerModel>> GetAllCustomersAsync();
        Task<CustomerModel> GetCustomerByDocumentAsync(string document);
        Task<CustomerModel> GetCustomerByIdAsync(long id);
        Task<CustomerModel> CreateCustomerAsync(CustomerModel customer);
        Task<bool> UpdateCustomerAsync(CustomerModel customer);
        Task<bool> DeleteCustomerAsync(long id);
    }
}
