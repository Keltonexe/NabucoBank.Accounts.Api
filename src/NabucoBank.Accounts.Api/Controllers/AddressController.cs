using Microsoft.AspNetCore.Mvc;
using NabucoBank.Accounts.Application.Interfaces;
using NabucoBank.Accounts.Application.Payloads;

namespace NabucoBank.Accounts.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        readonly IAddressServiceApp _addressServiceApp;
        public AddressController(IAddressServiceApp addressServiceApp) 
        {
            _addressServiceApp = addressServiceApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() 
        {
            return Ok(await _addressServiceApp.GetAllAddresssAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            return Ok(await _addressServiceApp.GetAddressByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddressPayload payload)
        {
            return Ok(await _addressServiceApp.CreateAddressAsync(payload));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] AddressPayload payload, [FromRoute] long id)
        {
            return Ok(await _addressServiceApp.UpdateAddressAsync(payload, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _addressServiceApp.DeleteAddressAsync(id));
        }
    }
}
