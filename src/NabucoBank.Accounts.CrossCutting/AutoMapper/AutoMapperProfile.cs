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
            CreateMap<UserModel, UserViewModel>().ForMember(dest => dest.CreatedAt, map => map.MapFrom(src => src.CreatedAt.ToString("dd/MM/yyyy"))).ReverseMap();
            CreateMap<AddressViewModel, AddressModel>().ReverseMap();
            
            CreateMap<AccountPayload, AccountModel>().ReverseMap();
            CreateMap<UserPayload, UserModel>().ReverseMap();
            CreateMap<AddressPayload, AddressModel>().ReverseMap();
        }
    }
}
