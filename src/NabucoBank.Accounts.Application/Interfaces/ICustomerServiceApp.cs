using NabucoBank.Accounts.Application.Payloads;
using NabucoBank.Accounts.Application.ViewModels;

namespace NabucoBank.Accounts.Application.Interfaces
{
    public interface ICustomerServiceApp
    {
        Task<IEnumerable<CustomerViewModel>> GetAllCustomersAsync();
        Task<CustomerViewModel> GetCustomerByIdAsync(long id);
        Task<CustomerViewModel> GetCustomerByDocumentAsync(string document);
        Task<CustomerViewModel> CreateCustomerAsync(CustomerPayload payload);
        Task<bool> UpdateCustomerAsync(CustomerPayload payload);
        Task<bool> DeleteCustomerAsync(long id);
    }
}
