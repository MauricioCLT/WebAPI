using FluentValidation;
using Core.DTOs;

namespace Core.Validation;

public class UpdateValidation : AbstractValidator<UpdateCustomerDTO>
{
    public UpdateValidation()
    {
        RuleFor(update => update.Id >= 0)
            .NotEmpty();

        RuleFor(update => update.FirstName)
            .Length(1);

        RuleFor(update => update.LastName)
            .Length(1);

        RuleFor(update => update.Email)
            .EmailAddress();

        RuleFor(update => update.Phone)
            .Length(10, 15);

        RuleFor(update => update.BirthDate)
            .NotEmpty();
    }
}