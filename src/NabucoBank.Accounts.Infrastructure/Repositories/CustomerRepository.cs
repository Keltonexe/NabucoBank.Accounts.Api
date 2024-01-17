using Dapper;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;
using NabucoBank.Accounts.UnitOfWork.Interface;

namespace NabucoBank.Accounts.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly IUnitOfWork _unitOfWork;
        public CustomerRepository(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<CustomerModel> CreateCustomerAsync(CustomerModel customer)
        {
            try
            {
                customer.HashCode = Guid.NewGuid().ToString();
                string sql = @"INSERT INTO customers (DOCUMENT, INCOME, NAME, EMAIL, PHONE, DT_CREATED, HASH_CODE) VALUES (@Document, @Income, @Name, @Email, @Phone, @CreatedAt, @HashCode);
                               SELECT * FROM customers WHERE HASH_CODE = @HashCode;";
                return await _unitOfWork.Connection.QuerySingleAsync<CustomerModel>(sql, customer);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteCustomerAsync(long id)
        {
            try
            {
                string sql = "DELETE FROM customers WHERE ID = @id;";
                return await _unitOfWork.Connection.ExecuteAsync(sql, new { id }) > 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomersAsync()
        {
            try
            {
                string sql = "SELECT * FROM customers;";
                return await _unitOfWork.Connection.QueryAsync<CustomerModel>(sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<CustomerModel> GetCustomerByDocumentAsync(string document)
        {
            try
            {
                string sql = "SELECT * FROM customers WHERE DOCUMENT = @document;";
                return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<CustomerModel>(sql, new { document });
            }
            catch 
            {
                throw;
            }
        }

        public async Task<CustomerModel> GetCustomerByIdAsync(long id)
        {
            try
            {
                string sql = "SELECT * FROM customers WHERE ID = @id;";
                return await _unitOfWork.Connection.QuerySingleAsync<CustomerModel>(sql, new { id });
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateCustomerAsync(CustomerModel customer)
        {
            try
            {
                customer.UpdatedAt = DateTime.Now;
                string sql = "UPDATE customers SET DOCUMENT = @Document, INCOME = @Income, NAME = @Name, EMAIL = @Email, PHONE = @Phone, DT_UPDATED = @UpdatedAt WHERE ID = @Id;";
                return await _unitOfWork.Connection.ExecuteAsync(sql, customer) > 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
