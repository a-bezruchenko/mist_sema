using mist_sema.DataClasses;

namespace mist_sema.Validators;

public interface IValidator
{
    ValidationResult Validate(ComputerConfiguration computerConfiguration);
}