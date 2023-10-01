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
        [Route("cep/{cep}")]
        public async Task<IActionResult> GetCEP([FromRoute] string cep)
        {
            using HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            return Ok(await response.Content.ReadAsStringAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() 
        {
            return Ok(await _addressServiceApp.GetAllAddressesAsync());
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

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] AddressPayload payload)
        {
            return Ok(await _addressServiceApp.UpdateAddressAsync(payload));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _addressServiceApp.DeleteAddressAsync(id));
        }
    }
}
