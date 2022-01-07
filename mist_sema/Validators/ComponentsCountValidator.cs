using mist_sema.DataClasses;

namespace mist_sema.Validators
{
    public class ComponentsCountValidator : IValidator
    {
        public ValidationResult Validate(ComputerConfiguration computerConfiguration)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            errors.Add(ValidateComponentCount<Processor>(computerConfiguration, 1, 1,
                "Должен быть ровно один процессор"));

            errors.Add(ValidateComponentCount<SystemBoard>(computerConfiguration, 1, 1,
                "Должна быть ровно одна материнская плата"));

            errors.Add(ValidateComponentCount<PowerSupply>(computerConfiguration, 1, 1,
                "Должен быть ровно один блок питания"));

            errors.Add(ValidateComponentCount<GraphicCard>(computerConfiguration, 1, 1,
                "Должна быть ровно одна видеокарта"));

            SystemBoard? systemBoard =
                computerConfiguration.components.FirstOrDefault(c => c is SystemBoard) as SystemBoard;

            errors.Add(ValidateComponentCount<StorageDevice>(computerConfiguration, 1, systemBoard?.SataPortsCount,
                "Должен быть хотя бы один накопитель",
                "Накопителей должно быть не больше, чем число SATA портов в материнской плате"));

            errors.Add(ValidateComponentCount<Ram>(computerConfiguration, 1, systemBoard?.MemorySlotsCount,
                "Должна быть хотя бы одна планка памяти",
                "Планок памяти должно быть не больше, чем число разъёмов под память в материнской плате"));

            return ValidationResult.Merge(errors);
        }

        private ValidationResult ValidateComponentCount<T>(ComputerConfiguration computerConfiguration, int minCount,
            int? maxCount, string errorMessageTooFew, string errorMessageTooMany = "") where T : ComputerComponent
        {
            if (errorMessageTooMany == "")
                errorMessageTooMany = errorMessageTooFew;

            int componentCount = computerConfiguration.components.Count((ComputerComponent c) => c is T);
            if (componentCount < minCount)
                return ValidationResult.Failure(errorMessageTooFew);
            else if ((maxCount != null && componentCount > maxCount))
                return ValidationResult.Failure(errorMessageTooMany);
            else
                return ValidationResult.Success();
        }
    }
}
