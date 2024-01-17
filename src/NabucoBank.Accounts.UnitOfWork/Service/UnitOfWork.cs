using NabucoBank.Accounts.UnitOfWork.Interface;
using System.Data;

namespace NabucoBank.Accounts.UnitOfWork.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
        }

        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => _transaction;

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }

        public void BeginTransaction()
        {
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
    }
}
