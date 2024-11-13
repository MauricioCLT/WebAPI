using Core.DTOs.Payment;
using FluentValidation;

namespace Infraestructura.Validation.Payment;

public class CreatePaymentValidation : AbstractValidator<CreatePaymentDTO>
{
    public CreatePaymentValidation()
    {
        RuleFor(create => create.Date)
            .NotEmpty();

        RuleFor(create => create.PaymentMethod)
            .NotEmpty();

        RuleFor(create => create.Amount)
            .NotEmpty();
    }
}
