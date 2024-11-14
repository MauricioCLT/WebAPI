using Core.DTOs.Charge;
using FluentValidation;

namespace Infraestructura.Validation.Charge;

public class CreateChargeValidation : AbstractValidator<CreateChargeDTO>
{
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
