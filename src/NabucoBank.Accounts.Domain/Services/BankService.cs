using NabucoBank.Accounts.Domain.Interfaces;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Domain.Services
{
    public class BankService : IBankService
    {
        public Task<BankModel> CreateBankAsync(BankModel bank) => throw new NotImplementedException();

        public Task<bool> DeleteBankAsync(long id) => throw new NotImplementedException();

        public Task<IEnumerable<BankModel>> GetAllBanksAsync() => throw new NotImplementedException();

        public Task<BankModel> GetBankByIdAsync(long id) => throw new NotImplementedException();

        public Task<bool> UpdateBankAsync(BankModel bank) => throw new NotImplementedException();
    }
}
