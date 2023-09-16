using AutoMapper;
using NabucoBank.Accounts.Application.Interfaces;
using NabucoBank.Accounts.Application.Payloads;
using NabucoBank.Accounts.Application.ViewModels;
using NabucoBank.Accounts.Domain.Interfaces;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Application.Services
{
    public class UserServiceApp : IUserServiceApp
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;
        public UserServiceApp(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<UserViewModel> CreateUserAsync(UserPayload payload)
        {
            return _mapper.Map<UserViewModel>(await _userService.CreateUserAsync(_mapper.Map<UserModel>(payload)));
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            return await _userService.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(await _userService.GetAllUsersAsync());
        }

        public async Task<UserViewModel> GetUserByIdAsync(long id)
        {
            return _mapper.Map<UserViewModel>(await _userService.GetUserByIdAsync(id));
        }

        public async Task<bool> UpdateUserAsync(UserPayload payload, long id)
        {
            return await _userService.UpdateUserAsync(_mapper.Map<UserModel>(payload), id);
        }
    }
}
