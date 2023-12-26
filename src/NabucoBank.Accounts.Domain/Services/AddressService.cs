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

        public async Task<AddressModel> CreateAddressWithCustomerAsync(AddressModel address, long customerId)
        {
            var createdAddress = await CreateAddressAsync(address);
            await AssociateAddressWithCustomerAsync(customerId, createdAddress.Id);
            return createdAddress;
        }

        private async Task AssociateAddressWithCustomerAsync(long customerId, long addressId)
        {
            var customerAddress = new CustomerAddressModel(customerId, addressId);
            await _addressRepository.InsertCustomerAddressAsync(customerAddress);
        }

        public async Task<bool> DeleteAddressAsync(long id) => await _addressRepository.DeleteAddressAsync(id);

        public async Task<AddressModel> GetAddressByIdAsync(long id) => await _addressRepository.GetAddressByIdAsync(id);

        public async Task<IEnumerable<AddressModel>> GetAllAddressAsync() => await _addressRepository.GetAllAddressAsync();

        public async Task<bool> UpdateAddressAsync(AddressModel address) => await _addressRepository.UpdateAddressAsync(address);
    }
}
