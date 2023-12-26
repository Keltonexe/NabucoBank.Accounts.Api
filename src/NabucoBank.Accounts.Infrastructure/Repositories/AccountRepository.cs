using Dapper;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;
using System.Data;

namespace NabucoBank.Accounts.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        readonly IDbConnection _connection;
        public AccountRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<AccountModel> CreateAccountAsync(AccountModel account)
        {
            _connection.Open();
            try
            {
                account.HashCode = Guid.NewGuid().ToString();
                string sql = @"INSERT INTO accounts (ID_CUSTOMER, ID_ADDRESS, NUMBER, BRANCH, BALANCE, DT_CREATED, HASH_CODE) VALUES (@CustomerId, @AddressId, @Number, @Branch, @Balance, @CreatedAt, @HashCode);
                               SELECT * FROM accounts WHERE ID = LAST_INSERT_ID();";
                return await _connection.QuerySingleAsync<AccountModel>(sql, account);
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<bool> DeleteAccountAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = "DELETE FROM accounts WHERE ID = @id;";
                return await _connection.ExecuteAsync(sql, new { id }) > 1;                
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<AccountModel> GetAccountByCustomerIdAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM accounts WHERE ID_CUSTOMER = @id;";
                return await _connection.QueryFirstOrDefaultAsync<AccountModel>(sql, new { id });
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<AccountModel> GetAccountByIdAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM accounts WHERE ID = @id;";
                return await _connection.QueryFirstOrDefaultAsync<AccountModel>(sql, new { id });
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<IEnumerable<AccountModel>> GetAllAccountsAsync()
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM accounts;";
                return await _connection.QueryAsync<AccountModel>(sql);
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<bool> UpdateAccountAsync(AccountModel account)
        {
            _connection.Open();
            try
            {
                string sql = "UPDATE accounts SET NUMBER = @Number, BALANCE = @Balance, DT_UPDATED = @UpdatedAt WHERE ID = @Id;";
                return await _connection.ExecuteAsync(sql, new { UpdatedAt = DateTime.Now, account }) > 1;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
