using mist_sema.DataClasses;

namespace mist_sema.Validators
{
    public class MemoryCompatabilityValidator : IValidator
    {
        public ValidationResult Validate(ComputerConfiguration computerConfiguration)
        {
            SystemBoard? systemBoard = computerConfiguration.components.FirstOrDefault(c => c is SystemBoard) as SystemBoard;
            string? ramGenerationId = (computerConfiguration.components.FirstOrDefault((ComputerComponent c) => c is Ram) as Ram)?.GenerationName;
            bool memoryGenerationsEqual = computerConfiguration.components
                .Where((ComputerComponent c) => c is Ram)
                .All((ComputerComponent c) => ((Ram)c).GenerationName == ramGenerationId);

            if (!memoryGenerationsEqual)
                return ValidationResult.Failure("Поколения планок памяти должны быть одинаковы");
            else if (ramGenerationId == null || systemBoard == null)
                return ValidationResult.Failure(""); // уже протестировано другими тестами
            else if (systemBoard?.MemoryGenerationName != ramGenerationId)
                return ValidationResult.Failure("Поколения планок памяти и материнской платы должны быть одинаковы");
            else
                return ValidationResult.Success();
        }
    }
}
