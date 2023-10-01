using Microsoft.AspNetCore.Mvc;
using NabucoBank.Accounts.Application.Interfaces;
using NabucoBank.Accounts.Application.Payloads;

namespace NabucoBank.Accounts.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        readonly IAccountServiceApp _accountServiceApp;
        public AccountController(IAccountServiceApp accountServiceApp) 
        {
            _accountServiceApp = accountServiceApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() 
        {
            return Ok(await _accountServiceApp.GetAllAccountsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            return Ok(await _accountServiceApp.GetAccountByIdAsync(id));
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetUserAccountByCpfAsync([FromRoute] string cpf)
        {
            return Ok(await _accountServiceApp.GetUserAccountByCpfAsync(cpf));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AccountPayload payload)
        {
            return Ok(await _accountServiceApp.CreateAccountAsync(payload));
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] AccountPayload payload)
        {
            return Ok(await _accountServiceApp.UpdateAccountAsync(payload));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _accountServiceApp.DeleteAccountAsync(id));
        }
    }
}
