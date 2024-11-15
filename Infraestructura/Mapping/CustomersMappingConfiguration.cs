using Core.DTOs.Customer;
using Core.DTOs.Entity;
using Core.Entities;
using Mapster;

namespace Infraestructura.Mapping;

public class CustomersMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Customer, CustomerDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Phone, src => src.Phone)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
            .Map(dest => dest.BirthDate, src => src.BirthDate.ToShortDateString())
            .Map(dest => dest.Accounts, src => src.Accounts.Select(x => x.Adapt<DetailedCustomerDTO>()));

        //config.NewConfig < Account, DetailedCustomerDTO>()
        //    .Map(dest => dest.Id, src => src.Id)
        //    .Map(dest => dest.Number, src => src.Number)
        //    .Map(dest => dest.Balance, src => src.Balance)
        //    .Map(dest => dest.OpeningDate, src => src.OpeningDate.ToShortDateString());

        config.NewConfig<UpdateCustomerDTO, Customer>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Phone, src => src.Phone)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.BirthDate, src => src.BirthDate);

        config.NewConfig<CreateCustomerDTO, Customer>()
            .Map(dest => dest.FirstName, src => src.FirstName);

        config.NewConfig<CreateEntityDTO, Customer>()
            .Map(dest => dest.Id, src => src.CustomerId);
    }
}
