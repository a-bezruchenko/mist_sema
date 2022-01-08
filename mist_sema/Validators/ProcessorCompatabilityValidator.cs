using mist_sema.DataClasses;

namespace mist_sema.Validators;

public class ProcessorCompatabilityValidator : IValidator
{
    public ValidationResult Validate(ComputerConfiguration computerConfiguration)
    {
        var processor = computerConfiguration.components.FirstOrDefault(c => c is Processor) as Processor;
        var systemBoard = computerConfiguration.components.FirstOrDefault(c => c is SystemBoard) as SystemBoard;
        if (processor == null || systemBoard == null)
            return ValidationResult.Failure(""); // уже протестировано другими тестами
        if (processor.ProcessorSocketType != systemBoard.ProcessorSocketType)
            return ValidationResult.Failure("Разные сокеты у процессора и материнской платы");
        return ValidationResult.Success();
    }
}