using FluentValidation;
using Core.DTOs;

namespace Core.Validation;

public class CreateValidation : AbstractValidator<CreateCustomerDTO>
{
    public CreateValidation()
    {
        RuleFor(create => create.FirstName)
            .Length(3, 40);

        RuleFor(create => create.LastName)
            .Length(3, 40);

        RuleFor(create => create.Phone)
            .Length(10, 15);

        RuleFor(create => create.Email)
            .EmailAddress();

        RuleFor(x => x.BirthDate)
            .NotEmpty();
    }
}
