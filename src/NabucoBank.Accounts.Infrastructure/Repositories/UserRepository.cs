using Dapper;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;
using System.Data;

namespace NabucoBank.Accounts.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly IDbConnection _connection;
        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            _connection.Open();
            try
            {
                user.HashCode = Guid.NewGuid().ToString();
                string sql = @"INSERT INTO users (CPF, NAME, EMAIL, PASSWORD, PHONE, DT_CREATED, HASH_CODE) VALUES (@Cpf, @Name, @Email, @Password, @Phone, @CreatedAt, @HashCode);
                               SELECT * FROM users WHERE HASH_CODE = @HashCode;";
                return await _connection.QuerySingleAsync<UserModel>(sql, user);
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = "UPDATE users SET DT_DELETED = @DeletedAt WHERE ID = @id;";
                await _connection.ExecuteAsync(sql, new { DeletedAt = DateTime.Now, id });
                return true;
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM users;";
                return await _connection.QueryAsync<UserModel>(sql);
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<UserModel> GetUserByCpfAsync(string cpf)
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM users WHERE CPF = @cpf";
                return await _connection.QueryFirstOrDefaultAsync<UserModel>(sql, new { cpf });
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<UserModel> GetUserByIdAsync(long id)
        {
            _connection.Open();
            try
            {
                string sql = "SELECT * FROM users WHERE ID = @id;";
                return await _connection.QuerySingleAsync<UserModel>(sql, new { id });
            }
            finally
            {
                _connection.Close();
            }
        }

        public async Task<bool> UpdateUserAsync(UserModel user, long id)
        {
            _connection.Open();
            try
            {
                user.Id = id;
                user.UpdatedAt = DateTime.Now;
                string sql = "UPDATE users SET CPF = @Cpf, NAME = @Name, EMAIL = @Email, PASSWORD = @Password, PHONE = @Phone, DT_UPDATED = @UpdatedAt WHERE ID = @id;";
                await _connection.ExecuteAsync(sql, user);
                return true;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
