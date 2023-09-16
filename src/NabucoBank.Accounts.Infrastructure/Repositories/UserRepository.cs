using Dapper;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Models;
using System.Data;
using System.Security.Principal;

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

        public Task<bool> DeleteUserAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(UserModel user, long id)
        {
            throw new NotImplementedException();
        }
    }
}
