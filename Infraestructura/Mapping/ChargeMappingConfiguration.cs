using Core.DTOs.Charge;
using Core.Entities;
using Mapster;

namespace Infraestructura.Mapping;

public class ChargeMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateChargeDTO, Charge>()
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Date, src => src.Date);
    }
}
