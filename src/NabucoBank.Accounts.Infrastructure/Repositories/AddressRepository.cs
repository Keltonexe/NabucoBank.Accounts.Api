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
                string sql = @"INSERT INTO address (ID_USER, STREET, STATE, CITY, NUMBER, COMPLEMENT, DT_CREATED, HASH_CODE) 
                               VALUES (@UserId, @Street, @State, @City, @Number, @Complement, @CreatedAt, @HashCode);
                               SELECT * FROM address WHERE ID = LAST_INSERT_ID();";
                return await _connection.QuerySingleAsync<AddressModel>(sql, address);
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
                string sql = "UPDATE address SET DT_DELETED = @DeletedAt WHERE ID = @id;";
                await _connection.ExecuteAsync(sql, new { DeletedAt = DateTime.Now, id });
                return true;
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

        public Task<IEnumerable<AddressModel>> GetAllAddressAsync()
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM address;";
                return _connection.QueryAsync<AddressModel>(sql);
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
                address.UpdatedAt = DateTime.Now;
                string sql = "UPDATE address SET STREET = @Street, STATE = @State, CITY = @City, NUMBER = @Number, COMPLEMENT = @Complement, DT_UPDATED = @UpdatedAt WHERE ID_USER = @UserId;";
                await _connection.ExecuteAsync(sql, address);
                return true;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
