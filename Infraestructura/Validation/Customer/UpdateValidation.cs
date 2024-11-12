using FluentValidation;
using Core.DTOs.Customer;

namespace Infraestructura.Validation.Customer;

public class UpdateValidation : AbstractValidator<UpdateCustomerDTO>
{
    public UpdateValidation()
    {
        RuleFor(update => update.Id).GreaterThan(0);

        RuleFor(update => update.FirstName).Length(1, 50);

        RuleFor(update => update.LastName).Length(1, 50);

        RuleFor(update => update.Email).EmailAddress();

        RuleFor(update => update.Phone).Length(10, 15).Matches(@"^\d+$")
                                       .WithMessage("El telefono deber contener solo digitos.");

        RuleFor(update => update.BirthDate).NotEmpty();
    }
}