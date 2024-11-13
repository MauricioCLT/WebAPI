using Core.DTOs.Charge;
using Core.Interfaces.Repositories;
using FluentValidation;

namespace Infraestructura.Validation.Charge;

public class CreateChargeValidation : AbstractValidator<CreateChargeDTO>
{
    private readonly IChargeRepository _chargeRepository;

    public CreateChargeValidation()
    {
        RuleFor(create => create.Amount)
            .NotEmpty();

        RuleFor(create => create.Description)
            .MinimumLength(5);

        RuleFor(create => create.Date)
            .NotEmpty();
    }
}
