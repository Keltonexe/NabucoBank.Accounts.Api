using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<AddressModel>> GetAllAddressAsync();
        Task<AddressModel> GetAddressByIdAsync(long id);
        Task<AddressModel> CreateAddressAsync(AddressModel address);
        Task<bool> InsertCustomerAddressAsync(CustomerAddressModel customerAddress);
        Task<bool> UpdateAddressAsync(AddressModel address);
        Task<bool> DeleteAddressAsync(long id);
    }
}
