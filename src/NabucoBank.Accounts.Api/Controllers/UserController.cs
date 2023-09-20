using Microsoft.AspNetCore.Mvc;
using NabucoBank.Accounts.Application.Interfaces;
using NabucoBank.Accounts.Application.Payloads;

namespace NabucoBank.Accounts.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        readonly IUserServiceApp _userServiceApp;
        public UserController(IUserServiceApp userServiceApp)
        {
            _userServiceApp = userServiceApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _userServiceApp.GetAllUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var result = await _userServiceApp.GetUserByIdAsync(id);

            if (result == null)
                return NotFound("Usuário não encontrado.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UserPayload payload)
        {
            var result = await _userServiceApp.CreateUserAsync(payload);

            if (result == null)
                return Conflict("Usuário já cadastrado.");

            return Ok(await _userServiceApp.CreateUserAsync(payload));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] UserPayload payload, [FromRoute] long id)
        {
            return Ok(await _userServiceApp.UpdateUserAsync(payload, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _userServiceApp.DeleteUserAsync(id));
        }
    }
}
