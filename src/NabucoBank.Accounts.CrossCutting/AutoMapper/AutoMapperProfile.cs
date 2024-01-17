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
            CreateMap<AccountViewModel, CustomerModel>().ReverseMap();
            CreateMap<AccountViewModel, AddressModel>().ReverseMap();
            CreateMap<CustomerModel, CustomerViewModel>().ForMember(dest => dest.CreatedAt, map => map.MapFrom(src => src.CreatedAt.ToString("dd/MM/yyyy"))).ReverseMap();
            CreateMap<AddressViewModel, AddressModel>().ReverseMap();
            CreateMap<BankViewModel, BankModel>().ReverseMap();
            
            CreateMap<AccountPayload, AccountModel>().ReverseMap();
            CreateMap<CustomerPayload, CustomerModel>().ReverseMap();
            CreateMap<AddressPayload, AddressModel>().ReverseMap();
        }
    }
}
