using NabucoBank.Accounts.Application.Payloads;
using NabucoBank.Accounts.Application.ViewModels;

namespace NabucoBank.Accounts.Application.Interfaces
{
    public interface IBankServiceApp
    {
        Task<IEnumerable<BankViewModel>> GetAllBanksAsync();
        Task<BankViewModel> GetBankByIdAsync(long id);
        Task<BankViewModel> CreateBankAsync(BankPayload payload);
        Task<bool> UpdateBankAsync(BankPayload payload);
        Task<bool> DeleteBankAsync(long id);
    }
}
