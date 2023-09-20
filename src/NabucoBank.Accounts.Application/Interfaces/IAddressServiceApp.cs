using NabucoBank.Accounts.Application.Payloads;
using NabucoBank.Accounts.Application.ViewModels;

namespace NabucoBank.Accounts.Application.Interfaces
{
    public interface IAddressServiceApp
    {
        Task<IEnumerable<AddressViewModel>> GetAllAddressesAsync();
        Task<AddressViewModel> GetAddressByIdAsync(long id);
        Task<AddressViewModel> CreateAddressAsync(AddressPayload payload);
        Task<bool> UpdateAddressAsync(AddressPayload payload);
        Task<bool> DeleteAddressAsync(long id);
    }
}
