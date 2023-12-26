using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Interfaces.Repositories
{
    public interface IBankRepository
    {
        Task<IEnumerable<BankModel>> GetAllBanksAsync();
        Task<BankModel> GetBankByIdAsync(long id);
        Task<BankModel> CreateBankAsync(BankModel bank);
        Task<bool> UpdateBankAsync(BankModel bank);
        Task<bool> DeleteBankAsync(long id);
    }
}
