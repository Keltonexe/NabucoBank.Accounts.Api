using Microsoft.AspNetCore.Mvc;
using NabucoBank.Accounts.Application.Interfaces;
using NabucoBank.Accounts.Application.Payloads;

namespace NabucoBank.Accounts.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        readonly IBankServiceApp _bankServiceApp;

        public BankController(IBankServiceApp bankServiceApp)
        {
            _bankServiceApp = bankServiceApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(await _bankServiceApp.GetAllBanksAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id) => Ok(await _bankServiceApp.GetBankByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BankPayload playload) => Ok(await _bankServiceApp.CreateBankAsync(playload));

        [HttpPut]
        public async Task<IActionResult> PutAsync(BankPayload playload) => Ok(await _bankServiceApp.UpdateBankAsync(playload));

    }
}
