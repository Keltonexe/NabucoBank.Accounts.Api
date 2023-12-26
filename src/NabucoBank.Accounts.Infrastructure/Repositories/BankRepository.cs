using Dapper;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;
using System.Data;

namespace NabucoBank.Accounts.Infrastructure.Repositories
{
    public class BankRepository : IBankRepository
    {
        public IDbConnection _connection {  get; set; }

        public BankRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<BankModel> CreateBankAsync(BankModel bank)
        {
            _connection.Open();
            try
            {
                bank.HashCode = Guid.NewGuid().ToString();
                string sql = @"INSERT INTO banks (NAME, CODE, DT_CREATED, HASH_CODE) VALUES (@Name, @Code, @CreatedAt, @HashCode);
                               SELECT * FROM banks WHERE HashCode = @HashCode;";
                return await _connection.QuerySingleAsync<BankModel>(sql);
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<bool> DeleteBankAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = @"DELETE FROM banks WHERE ID = @id;";
                return await _connection.ExecuteAsync(sql) > 1;
                //^ condição de linhas afetadas
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<IEnumerable<BankModel>> GetAllBanksAsync()
        {
            _connection.Open();
            try
            {
                string sql = @"SELECT * FROM banks;";
                return await _connection.QueryAsync<BankModel>(sql);
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<BankModel> GetBankByIdAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = @"SELECT FROM banks WHERE ID = @id;";
                return await _connection.QuerySingleAsync<BankModel>(sql, new { id });
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<bool> UpdateBankAsync(BankModel bank)
        {
            _connection.Open();
            try
            {
                string sql = @"UPDATE banks SET NAME = @Name, CODE = @Code, DT_CREATED = @CreatedAt, HASH_CODE = @HashCode WHERE ID = @Id";
                return await _connection.ExecuteAsync(sql) > 1;                
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
