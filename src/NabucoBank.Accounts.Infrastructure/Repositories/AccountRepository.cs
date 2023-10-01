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
                string sql = @"INSERT INTO accounts (ID_USER, NUMBER, BALANCE, DT_CREATED, HASH_CODE) VALUES (@UserId, @Number, @Balance, @CreatedAt, @HashCode);
                               SELECT * FROM accounts WHERE ID_USER = LAST_INSERT_ID();";
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
                string sql = "UPDATE accounts SET DT_DELETED = @DeletedAt WHERE ID = @id;";
                await _connection.ExecuteAsync(sql, new { DeletedAt = DateTime.Now, id });
                return true;
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<AccountModel> GetAccountByUserIdAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM accounts WHERE ID_USER = @id;";
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
                account.UpdatedAt = DateTime.Now;
                string sql = "UPDATE accounts SET NUMBER = @Number, BALANCE = @Balance, DT_UPDATED = @UpdatedAt WHERE ID_USER = @UserId;";
                await _connection.ExecuteAsync(sql, account);
                return true;

            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
