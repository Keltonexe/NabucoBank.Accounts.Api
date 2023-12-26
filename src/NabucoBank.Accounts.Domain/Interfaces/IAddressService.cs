using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressModel>> GetAllAddressAsync();
        Task<AddressModel> GetAddressByIdAsync(long id);
        Task<AddressModel> CreateAddressWithCustomerAsync(AddressModel address, long customerId);
        Task<AddressModel> CreateAddressAsync(AddressModel address);
        Task<bool> UpdateAddressAsync(AddressModel address);
        Task<bool> DeleteAddressAsync(long id);
    }
}
