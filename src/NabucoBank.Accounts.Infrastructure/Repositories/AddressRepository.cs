using Dapper;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;
using NabucoBank.Accounts.UnitOfWork.Interface;

namespace NabucoBank.Accounts.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        readonly IUnitOfWork _unitOfWork;
        public AddressRepository(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        public async Task<AddressModel> CreateAddressAsync(AddressModel address)
        {
            try
            {
                address.HashCode = Guid.NewGuid().ToString();
                string sql = @"INSERT INTO address (ZIPCODE, STREET, CITY, STATE, NUMBER, COMPLEMENT, DT_CREATED, HASH_CODE) 
                               VALUES (@Zipcode, @Street, @City, @State, @Number, @Complement, @CreatedAt, @HashCode);
                               SELECT * FROM address WHERE ID = LAST_INSERT_ID();";
                return await _unitOfWork.Connection.QuerySingleAsync<AddressModel>(sql, address);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertCustomerAddressAsync(CustomerAddressModel customerAddress)
        {
            try
            {
                string sql = "INSERT INTO customer_address (ID_CUSTOMER, ID_ADDRESS) VALUES (@CustomerId, @AddressId);";
                return await _unitOfWork.Connection.ExecuteAsync(sql, customerAddress) > 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteAddressAsync(long id)
        {
            try
            {
                string sql = "DELETE FROM address WHERE ID = @id;";
                return await _unitOfWork.Connection.ExecuteAsync(sql, new { id }) > 1;
            }
            catch
            {
                throw;
            }
        }

        public Task<AddressModel> GetAddressByIdAsync(long id)
        {
            try
            {
                string sql = "SELECT * FROM address WHERE ID = @id;";
                return _unitOfWork.Connection.QuerySingleAsync<AddressModel>(sql, new { id });
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<AddressModel>> GetAllAddressAsync()
        {
            try
            {
                string sql = "SELECT * FROM address;";
                return await _unitOfWork.Connection.QueryAsync<AddressModel>(sql);
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> UpdateAddressAsync(AddressModel address)
        {
            try
            {
                string sql = "UPDATE address SET ZIPCODE = @Zipcode, STREET = @Street, NUMBER = @Number, CITY = @City, STATE = @State, COMPLEMENT = @Complement, DT_UPDATED = @UpdatedAt WHERE ID = @Id;";
                return await _unitOfWork.Connection.ExecuteAsync(sql, new { UpdatedAt = DateTime.Now, address }) > 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
