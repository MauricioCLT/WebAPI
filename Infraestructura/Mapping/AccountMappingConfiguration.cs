using Core.DTOs.Customer;
using Core.Entities;
using Mapster;

namespace Infraestructura.Mapping;

public class AccountMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Account, DetailedCustomerDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Number, src => src.Number)
            .Map(dest => dest.Balance, src => src.Balance)
            .Map(dest => dest.OpeningDate, src => src.OpeningDate.ToShortDateString())
            .Map(dest => dest.Customer, src => src.Adapt<DetailedCustomerDTO>());
    }
}
