using mist_sema.DataClasses;

namespace mist_sema.Validators;

public class MemoryCompatabilityValidator : IValidator
{
    public ValidationResult Validate(ComputerConfiguration computerConfiguration)
    {
        var systemBoard = computerConfiguration.components.FirstOrDefault(c => c is SystemBoard) as SystemBoard;
        var ramGenerationId = (computerConfiguration.components.FirstOrDefault(c => c is Ram) as Ram)?.GenerationName;
        var memoryGenerationsEqual = computerConfiguration.components
            .Where(c => c is Ram)
            .All(c => ((Ram)c).GenerationName == ramGenerationId);

        if (!memoryGenerationsEqual)
            return ValidationResult.Failure("Поколения планок памяти должны быть одинаковы");
        if (ramGenerationId == null || systemBoard == null)
            return ValidationResult.Failure(""); // уже протестировано другими тестами
        if (systemBoard?.MemoryGenerationName != ramGenerationId)
            return ValidationResult.Failure("Поколения планок памяти и материнской платы должны быть одинаковы");
        return ValidationResult.Success();
    }
}