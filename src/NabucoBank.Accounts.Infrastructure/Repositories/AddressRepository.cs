using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public Task<AddressModel> CreateAddressAsync(AddressModel address)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAddressAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<AddressModel> GetAddressByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressModel>> GetAllAddressAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAddressAsync(AddressModel address, long id)
        {
            throw new NotImplementedException();
        }
    }
}
