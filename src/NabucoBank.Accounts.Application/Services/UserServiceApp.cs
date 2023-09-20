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
            var user = await GetUserByCpf(payload.Cpf);

            if (user == null)
                return _mapper.Map<UserViewModel>(await _userService.CreateUserAsync(_mapper.Map<UserModel>(payload)));

            return null;
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            return await _userService.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            var usersResult = await _userService.GetAllUsersAsync();
            var activeUsers = usersResult.Where(user => !user.DeletedAt.HasValue).ToList();

            if (activeUsers.Count > 0)
                return _mapper.Map<IEnumerable<UserViewModel>>(activeUsers);
            
            return null;
        }

        public async Task<UserViewModel> GetUserByCpf(string cpf)
        {
            return _mapper.Map<UserViewModel>(await _userService.GetUserByCpf(cpf));
        }

        public async Task<UserViewModel> GetUserByIdAsync(long id)
        {
            var userResult = await _userService.GetUserByIdAsync(id);

            if (userResult.DeletedAt == null)
                return _mapper.Map<UserViewModel>(userResult);

            return null;
        }

        public async Task<bool> UpdateUserAsync(UserPayload payload, long id)
        {
            return await _userService.UpdateUserAsync(_mapper.Map<UserModel>(payload), id);
        }
    }
}
