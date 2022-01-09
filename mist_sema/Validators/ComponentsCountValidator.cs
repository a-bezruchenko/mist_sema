using mist_sema.DataClasses;

namespace mist_sema.Validators;

public class ComponentsCountValidator : IValidator
{
    public ValidationResult Validate(ComputerConfiguration computerConfiguration)
    {
        var systemBoard = computerConfiguration.components.FirstOrDefault(c => c is SystemBoard) as SystemBoard;

        var errors = new List<ValidationResult>()
        {
            ValidateComponentCount<Processor>(computerConfiguration, 1, 1,
                "Должен быть ровно один процессор"),
            ValidateComponentCount<SystemBoard>(computerConfiguration, 1, 1,
                "Должна быть ровно одна материнская плата"),
            ValidateComponentCount<PowerSupply>(computerConfiguration, 1, 1,
                "Должен быть ровно один блок питания"),
            ValidateComponentCount<GraphicCard>(computerConfiguration, 1, 1,
                "Должна быть ровно одна видеокарта"),
            ValidateComponentCount<StorageDevice>(computerConfiguration, 1, systemBoard?.SataPortsCount,
                "Должен быть хотя бы один накопитель",
                "Накопителей должно быть не больше, чем число SATA портов в материнской плате"),
            ValidateComponentCount<Ram>(computerConfiguration, 1, systemBoard?.MemorySlotsCount,
                "Должна быть хотя бы одна планка памяти",
                "Планок памяти должно быть не больше, чем число разъёмов под память в материнской плате")
        };

        return ValidationResult.Merge(errors);
    }

    private static ValidationResult ValidateComponentCount<T>(ComputerConfiguration computerConfiguration, int minCount,
        int? maxCount, string errorMessageTooFew, string errorMessageTooMany = "") where T : ComputerComponent
    {
        if (errorMessageTooMany == "")
            errorMessageTooMany = errorMessageTooFew;

        var componentCount = computerConfiguration.components.Count(c => c is T);
        if (componentCount < minCount)
            return ValidationResult.Failure(errorMessageTooFew);
        if (maxCount != null && componentCount > maxCount)
            return ValidationResult.Failure(errorMessageTooMany);
        return ValidationResult.Success();
    }
}