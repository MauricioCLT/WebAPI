using FluentValidation;
using FluentValidation.Results;

namespace Infraestructura.Validation.Entity;

public class CreateEntityValidation : IValidator
{
    public ValidationResult Validate(IValidationContext context)
    {
        throw new NotImplementedException();
    }

    public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public IValidatorDescriptor CreateDescriptor()
    {
        throw new NotImplementedException();
    }

    public bool CanValidateInstancesOfType(Type type)
    {
        throw new NotImplementedException();
    }
}