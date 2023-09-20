using NabucoBank.Accounts.Domain.Interfaces;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Services
{
    public class AddressService : IAddressService
    {
        readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<AddressModel> CreateAddressAsync(AddressModel address)
        {
            return await _addressRepository.CreateAddressAsync(address);
        }

        public async Task<bool> DeleteAddressAsync(long id)
        {
            return await _addressRepository.DeleteAddressAsync(id);
        }

        public async Task<AddressModel> GetAddressByIdAsync(long id)
        {
            return await _addressRepository.GetAddressByIdAsync(id);
        }

        public async Task<IEnumerable<AddressModel>> GetAllAddressAsync()
        {
            return await _addressRepository.GetAllAddressAsync();
        }

        public async Task<bool> UpdateAddressAsync(AddressModel address)
        {
            return await _addressRepository.UpdateAddressAsync(address);
        }
    }
}
