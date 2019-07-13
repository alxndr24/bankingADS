using Banking.Domain.Accounts.Entities;
using Banking.Domain.Customers.Entities;
using AutoMapper;
using Banking.Application.Accounts.Dtos;

namespace Banking.Application.Accounts.Profiles
{
    public class NewAccountProfile : Profile
    {
        public NewAccountProfile()
        {
            CreateMap<NewAccountDto, Account>()
                .ForMember(
                    dest => dest.Customer,
                    opts => opts.MapFrom(
                        src => new Customer(src.CustomerId)
                    )
                ).ReverseMap();
        }
    }
}
