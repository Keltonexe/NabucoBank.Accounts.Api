using Dapper;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;
using NabucoBank.Accounts.UnitOfWork.Interface;

namespace NabucoBank.Accounts.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        readonly IUnitOfWork _unitOfWork;
        public AccountRepository(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<AccountModel> CreateAccountAsync(AccountModel account)
        {
            try
            {
                account.HashCode = Guid.NewGuid().ToString();
                string sql = @"INSERT INTO accounts (ID_CUSTOMER, ID_ADDRESS, NUMBER, BRANCH, BALANCE, DT_CREATED, HASH_CODE) VALUES (@CustomerId, @AddressId, @Number, @Branch, @Balance, @CreatedAt, @HashCode);
                               SELECT * FROM accounts WHERE ID = LAST_INSERT_ID();";
                return await _unitOfWork.Connection.QuerySingleAsync<AccountModel>(sql, account);
            }
            catch
            {
                //Implementar ErrorHandler
                throw;
            }
        }

        public async Task<bool> DeleteAccountAsync(long id)
        {
            try
            {
                string sql = "DELETE FROM accounts WHERE ID = @id;";
                return await _unitOfWork.Connection.ExecuteAsync(sql, new { id }) > 1;                
            }
            catch
            {
                throw;
            }
        }

        public async Task<AccountModel> GetAccountByCustomerIdAsync(long id)
        {
            try
            {
                string sql = "SELECT * FROM accounts WHERE ID_CUSTOMER = @id;";
                return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<AccountModel>(sql, new { id });
            }
            catch
            {
                throw;
            }
        }

        public async Task<AccountModel> GetAccountByIdAsync(long id)
        {
            try
            {
                string sql = "SELECT * FROM accounts WHERE ID = @id;";
                return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<AccountModel>(sql, new { id });
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<AccountModel>> GetAllAccountsAsync()
        {
            try
            {
                string sql = "SELECT * FROM accounts;";
                return await _unitOfWork.Connection.QueryAsync<AccountModel>(sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateAccountAsync(AccountModel account)
        {
            try
            {
                string sql = "UPDATE accounts SET NUMBER = @Number, BALANCE = @Balance, DT_UPDATED = @UpdatedAt WHERE ID = @Id;";
                return await _unitOfWork.Connection.ExecuteAsync(sql, new { UpdatedAt = DateTime.Now, account }) > 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
