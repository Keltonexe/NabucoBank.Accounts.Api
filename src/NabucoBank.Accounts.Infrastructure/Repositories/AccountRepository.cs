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

        public Task<bool> DeleteAccountAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountModel> GetAccountByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountModel>> GetAllAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAccountAsync(AccountModel account, long id)
        {
            throw new NotImplementedException();
        }
    }
}
