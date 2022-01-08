using mist_sema.DataClasses;

namespace mist_sema.Validators;

public class TotalPowerValidator : IValidator
{
    public ValidationResult Validate(ComputerConfiguration computerConfiguration)
    {
        var powerSupply = computerConfiguration.components.FirstOrDefault(c => c is PowerSupply) as PowerSupply;

        if (powerSupply == null)
            return ValidationResult.Failure(""); // уже протестировано другим тестом

        var providedPower = powerSupply.Consumed_power * powerSupply.Efficiency;
        var consumedPower = computerConfiguration.components
            .Where(c => c is not PowerSupply)
            .Select(c => c.Consumed_power)
            .Sum();

        return consumedPower > providedPower
            ? ValidationResult.Failure("Недостаточно мощный блок питания")
            : ValidationResult.Success();
    }
}