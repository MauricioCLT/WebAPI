using Core.DTOs.Entity;
using FluentValidation;

namespace Infraestructura.Validation.Entity;

public class CreateEntityValidator : AbstractValidator<CreateEntityDTO>
{
    public CreateEntityValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.EntityName).NotEmpty();
    }
}