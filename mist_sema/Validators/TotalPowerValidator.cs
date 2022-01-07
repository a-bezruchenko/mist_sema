using mist_sema.DataClasses;

namespace mist_sema.Validators
{
    public class TotalPowerValidator : IValidator
    {
        public ValidationResult Validate(ComputerConfiguration computerConfiguration)
        {
            PowerSupply? powerSupply = computerConfiguration.components.FirstOrDefault(c => c is PowerSupply) as PowerSupply;

            if (powerSupply == null)
                return ValidationResult.Failure(""); // уже протестировано другим тестом

            double providedPower = powerSupply.Consumed_power * powerSupply.Efficiency;
            double consumedPower = computerConfiguration.components
                .Where((ComputerComponent c) => c is not PowerSupply)
                .Select((ComputerComponent c) => c.Consumed_power)
                .Sum();

            if (consumedPower > providedPower)
                return ValidationResult.Failure("Недостаточно мощный блок питания");
            else
                return ValidationResult.Success();
        }
    }
}
