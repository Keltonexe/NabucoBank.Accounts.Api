using AutoMapper;
using NabucoBank.Accounts.Application.Interfaces;
using NabucoBank.Accounts.Application.Payloads;
using NabucoBank.Accounts.Application.ViewModels;
using NabucoBank.Accounts.Domain.Interfaces;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Application.Services
{
    public class BankServiceApp : IBankServiceApp
    {
        public IBankService _bankService;
        public IMapper _mapper;

        public BankServiceApp(IBankService bankService, IMapper mapper)
        {
            _bankService = bankService;
            _mapper = mapper;
        }
        public async Task<BankViewModel> CreateBankAsync(BankPayload bank) => _mapper.Map<BankViewModel>(await _bankService.CreateBankAsync(_mapper.Map<BankModel>(bank)));

        public async Task<bool> DeleteBankAsync(long id) => await _bankService.DeleteBankAsync(id);

        public async Task<IEnumerable<BankViewModel>> GetAllBanksAsync() => _mapper.Map<IEnumerable<BankViewModel>>(await _bankService.GetAllBanksAsync());

        public async Task<BankViewModel> GetBankByIdAsync(long id) => _mapper.Map<BankViewModel>(await _bankService.GetBankByIdAsync(id));

        public async Task<bool> UpdateBankAsync(BankPayload bank) => await _bankService.UpdateBankAsync(_mapper.Map<BankModel>(bank));
    }
}
