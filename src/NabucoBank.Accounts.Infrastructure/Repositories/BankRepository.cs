using Dapper;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;
using NabucoBank.Accounts.UnitOfWork.Interface;

namespace NabucoBank.Accounts.Infrastructure.Repositories
{
    public class BankRepository : IBankRepository
    {
        readonly IUnitOfWork _unitOfWork;
        public BankRepository(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<BankModel> CreateBankAsync(BankModel bank)
        {
            try
            {
                bank.HashCode = Guid.NewGuid().ToString();
                string sql = @"INSERT INTO banks (NAME, CODE, DT_CREATED, HASH_CODE) VALUES (@Name, @Code, @CreatedAt, @HashCode);
                               SELECT * FROM banks WHERE HashCode = @HashCode;";
                return await _unitOfWork.Connection.QuerySingleAsync<BankModel>(sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteBankAsync(long id)
        {
            try
            {
                string sql = @"DELETE FROM banks WHERE ID = @id;";
                return await _unitOfWork.Connection.ExecuteAsync(sql) > 1;
                //^ condição de linhas afetadas
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<BankModel>> GetAllBanksAsync()
        {
            try
            {
                string sql = @"SELECT * FROM banks;";
                return await _unitOfWork.Connection.QueryAsync<BankModel>(sql);
            }
            catch
            {
                throw;
            }
        }

        public async Task<BankModel> GetBankByIdAsync(long id)
        {
            try
            {
                string sql = @"SELECT FROM banks WHERE ID = @id;";
                return await _unitOfWork.Connection.QuerySingleAsync<BankModel>(sql, new { id });
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateBankAsync(BankModel bank)
        {
            try
            {
                string sql = @"UPDATE banks SET NAME = @Name, CODE = @Code, DT_CREATED = @CreatedAt, HASH_CODE = @HashCode WHERE ID = @Id";
                return await _unitOfWork.Connection.ExecuteAsync(sql) > 1;                
            }
            catch
            {
                throw;
            }
        }
    }
}
