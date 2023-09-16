using AutoMapper;
using NabucoBank.Accounts.Application.Payloads;
using NabucoBank.Accounts.Application.ViewModels;
using NabucoBank.Accounts.Domain.Models;

namespace NabucoBank.Accounts.CrossCutting.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<AccountViewModel, AccountModel>().ReverseMap();
            CreateMap<UserViewModel, UserModel>().ReverseMap();
            CreateMap<AddressViewModel, AddressModel>().ReverseMap();
            
            CreateMap<AccountPayload, AccountModel>().ReverseMap();
            CreateMap<UserPayload, UserModel>().ReverseMap();
            CreateMap<AddressPayload, AddressModel>().ReverseMap();
        }
    }
}
