using Core.DTOs.Card;
using FluentValidation;

namespace Infraestructura.Validation.Card;

public class CreateCardValidation : AbstractValidator<CreateCardDTO>
{
    public CreateCardValidation()
    {
        RuleFor(create => create.CustomerId)
            .GreaterThan(1);

        RuleFor(create => create.CardType)
            .NotEmpty();

        RuleFor(create => create.CreditLimit)
            .NotEmpty();

        RuleFor(create => create.ExpirationDate)
            .NotEmpty();

        RuleFor(create => create.InterestRate)
            .NotEmpty();
    }
}
