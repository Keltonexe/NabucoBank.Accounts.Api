using Dapper;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;
using System.Data;

namespace NabucoBank.Accounts.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        readonly IDbConnection _connection;
        public AddressRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<AddressModel> CreateAddressAsync(AddressModel address)
        {
            _connection.Open();
            try
            {
                address.HashCode = Guid.NewGuid().ToString();
                string sql = @"INSERT INTO address (ZIPCODE, STREET, CITY, STATE, NUMBER, COMPLEMENT, DT_CREATED, HASH_CODE) 
                               VALUES (@Zipcode, @Street, @City, @State, @Number, @Complement, @CreatedAt, @HashCode);
                               SELECT * FROM address WHERE ID = LAST_INSERT_ID();";
                return await _connection.QuerySingleAsync<AddressModel>(sql, address);
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<bool> InsertCustomerAddressAsync(CustomerAddressModel customerAddress)
        {
            _connection.Open();
            try
            {
                string sql = "INSERT INTO customer_address (ID_CUSTOMER, ID_ADDRESS) VALUES (@CustomerId, @AddressId);";
                return await _connection.ExecuteAsync(sql, customerAddress) > 1;
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<bool> DeleteAddressAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = "DELETE FROM address WHERE ID = @id;";
                return await _connection.ExecuteAsync(sql, new { id }) > 1;
            }
            finally
            {
                _connection.Close();
            }
        }

        public Task<AddressModel> GetAddressByIdAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM address WHERE ID = @id;";
                return _connection.QuerySingleAsync<AddressModel>(sql, new { id });
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<IEnumerable<AddressModel>> GetAllAddressAsync()
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM address;";
                return await _connection.QueryAsync<AddressModel>(sql);
            }
            finally
            {
                _connection.Close();
            }
        }


        public async Task<bool> UpdateAddressAsync(AddressModel address)
        {
            _connection.Open();
            try
            {
                string sql = "UPDATE address SET ZIPCODE = @Zipcode, STREET = @Street, NUMBER = @Number, CITY = @City, STATE = @State, COMPLEMENT = @Complement, DT_UPDATED = @UpdatedAt WHERE ID = @Id;";
                return await _connection.ExecuteAsync(sql, new { UpdatedAt = DateTime.Now, address }) > 1;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
