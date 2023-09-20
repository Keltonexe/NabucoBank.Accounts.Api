using AutoMapper;
using NabucoBank.Accounts.Application.Interfaces;
using NabucoBank.Accounts.Application.Payloads;
using NabucoBank.Accounts.Application.ViewModels;
using NabucoBank.Accounts.Domain.Interfaces;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.Application.Services
{
    public class AddressServiceApp : IAddressServiceApp
    {
        readonly IAddressService _addressService;
        readonly IMapper _mapper;
        public AddressServiceApp(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }
        public async Task<AddressViewModel> CreateAddressAsync(AddressPayload payload)
        {
            return _mapper.Map<AddressViewModel>(await _addressService.CreateAddressAsync(_mapper.Map<AddressModel>(payload)));
        }

        public Task<bool> DeleteAddressAsync(long id)
        {
            return _addressService.DeleteAddressAsync(id);
        }

        public async Task<AddressViewModel> GetAddressByIdAsync(long id)
        {
            return _mapper.Map<AddressViewModel>(await _addressService.GetAddressByIdAsync(id));
        }

        public async Task<IEnumerable<AddressViewModel>> GetAllAddressesAsync()
        {
            return _mapper.Map<IEnumerable<AddressViewModel>>(await _addressService.GetAllAddressAsync());
        }

        public async Task<bool> UpdateAddressAsync(AddressPayload payload)
        {
            return await _addressService.UpdateAddressAsync(_mapper.Map<AddressModel>(payload));
        }
    }
}
