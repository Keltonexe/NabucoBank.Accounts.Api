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
<<<<<<< HEAD
        public async Task<IActionResult> GetAllAsync() => Ok(await _accountServiceApp.GetAllAccountsAsync());
=======
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _accountServiceApp.GetAllAccountsAsync());
        }
>>>>>>> 0657ab333240d3fcd04d90498c504d380c5ac846

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id) => Ok(await _accountServiceApp.GetAccountByIdAsync(id));

        [HttpGet("{document}")]
        public async Task<IActionResult> GetCustomerAccountByDocumentAsync([FromRoute] string document) => Ok(await _accountServiceApp.GetCustomerAccountByDocumentAsync(document));

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AccountPayload payload) => Ok(await _accountServiceApp.CreateAccountAsync(payload));

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] AccountPayload payload) => Ok(await _accountServiceApp.UpdateAccountAsync(payload));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id) => Ok(await _accountServiceApp.DeleteAccountAsync(id));
    }
}
