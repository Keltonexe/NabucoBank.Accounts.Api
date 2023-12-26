using Microsoft.AspNetCore.Mvc;
using NabucoBank.Accounts.Application.Interfaces;
using NabucoBank.Accounts.Application.Payloads;

namespace NabucoBank.Accounts.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerServiceApp _customerServiceApp;
        public CustomerController(ICustomerServiceApp customerServiceApp)
        {
            _customerServiceApp = customerServiceApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(await _customerServiceApp.GetAllCustomersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var result = await _customerServiceApp.GetCustomerByIdAsync(id);

            if (result is null)
                return NotFound("Cliente não encontrado.");

            return Ok(result);
        }

        [HttpGet("{document}")]
        public async Task<IActionResult> GetByDocumentAsync([FromRoute] string document)
        {
            var result = await _customerServiceApp.GetCustomerByDocumentAsync(document);

            if (result is null)
                return NotFound("Cliente não encontrado.");

            return Ok(result);
        }

        //[HttpPost]
        //public async Task<IActionResult> PostAsync([FromBody] CustomerPayload payload)
        //{
        //    var result = await _customerServiceApp.CreateCustomerAsync(payload);

        //    if (result is null)
        //        return Conflict("Cliente já cadastrado.");

        //    return Ok(await _customerServiceApp.CreateCustomerAsync(payload));
        //}

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] CustomerPayload payload) => Ok(await _customerServiceApp.UpdateCustomerAsync(payload));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id) => Ok(await _customerServiceApp.DeleteCustomerAsync(id));
    }
}
