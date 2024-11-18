using Core.DTOs.Product;
using FluentValidation;

namespace Infraestructura.Validation.Product;

public class CreateProductValidation : AbstractValidator<CreateProductDTO>
{
    public CreateProductValidation()
    {
        RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ingrese un nombre");
        // RuleFor(x => x.StartDate).NotEmpty().WithMessage("Ingrese una fecha");
    }
}