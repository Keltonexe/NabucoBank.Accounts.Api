using System.Data;

namespace NabucoBank.Accounts.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
