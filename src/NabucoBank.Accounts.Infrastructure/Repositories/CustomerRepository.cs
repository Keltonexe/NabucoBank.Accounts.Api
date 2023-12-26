using Dapper;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;
using System.Data;

namespace NabucoBank.Accounts.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly IDbConnection _connection;
        public CustomerRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<CustomerModel> CreateCustomerAsync(CustomerModel customer)
        {
            _connection.Open();
            try
            {
                customer.HashCode = Guid.NewGuid().ToString();
                string sql = @"INSERT INTO customers (DOCUMENT, INCOME, NAME, EMAIL, PHONE, DT_CREATED, HASH_CODE) VALUES (@Document, @Income, @Name, @Email, @Phone, @CreatedAt, @HashCode);
                               SELECT * FROM customers WHERE HASH_CODE = @HashCode;";
                return await _connection.QuerySingleAsync<CustomerModel>(sql, customer);
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<bool> DeleteCustomerAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = "DELETE FROM customers WHERE ID = @id;";
                return await _connection.ExecuteAsync(sql, new { id }) > 1;   
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomersAsync()
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM customers;";
                return await _connection.QueryAsync<CustomerModel>(sql);
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<CustomerModel> GetCustomerByDocumentAsync(string document)
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM customers WHERE DOCUMENT = @document;";
                return await _connection.QueryFirstOrDefaultAsync<CustomerModel>(sql, new { document });
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<CustomerModel> GetCustomerByIdAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM customers WHERE ID = @id;";
                return await _connection.QuerySingleAsync<CustomerModel>(sql, new { id });
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<bool> UpdateCustomerAsync(CustomerModel customer)
        {
            _connection.Open();
            try
            {
                customer.UpdatedAt = DateTime.Now;
                string sql = "UPDATE customers SET DOCUMENT = @Document, INCOME = @Income, NAME = @Name, EMAIL = @Email, PHONE = @Phone, DT_UPDATED = @UpdatedAt WHERE ID = @Id;";
                return await _connection.ExecuteAsync(sql, customer) > 1;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
