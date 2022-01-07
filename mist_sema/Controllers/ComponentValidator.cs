using mist_sema.DataClasses;
using System.Text;

namespace mist_sema.Controllers
{
    public class ComponentValidator
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

            errors.Add(CheckMemoryCompatability(computerConfiguration));

            errors.Add(CheckPower(computerConfiguration));

            errors.Add(CheckProcessorCompatability(computerConfiguration));

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

        private ValidationResult CheckPower(ComputerConfiguration computerConfiguration)
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

        private ValidationResult CheckMemoryCompatability(ComputerConfiguration computerConfiguration)
        {
            SystemBoard? systemBoard = computerConfiguration.components.FirstOrDefault(c => c is SystemBoard) as SystemBoard;
            int? ramGenerationId = (computerConfiguration.components.FirstOrDefault((ComputerComponent c) => c is Ram) as Ram)?.GenerationId;
            bool memoryGenerationsEqual = computerConfiguration.components
                .Where((ComputerComponent c) => c is Ram)
                .All((ComputerComponent c) => ((Ram)c).GenerationId == ramGenerationId);

            if (!memoryGenerationsEqual)
                return ValidationResult.Failure("Поколения планок памяти должны быть одинаковы");
            else if (ramGenerationId == null || systemBoard == null)
                return ValidationResult.Failure(""); // уже протестировано другими тестами
            else if (systemBoard?.MemoryGenerationId != ramGenerationId)
                return ValidationResult.Failure("Поколения планок памяти и материнской платы должны быть одинаковы");
            else
                return ValidationResult.Success();
        }

        private ValidationResult CheckProcessorCompatability(ComputerConfiguration computerConfiguration)
        {
            Processor? processor = computerConfiguration.components.FirstOrDefault(c => c is Processor) as Processor;
            SystemBoard? systemBoard = computerConfiguration.components.FirstOrDefault(c => c is SystemBoard) as SystemBoard;
            if (processor == null || systemBoard == null)
                return ValidationResult.Failure(""); // уже протестировано другими тестами
            else if (processor.SocketTypeId != systemBoard.SocketTypeId)
                return ValidationResult.Failure("Разные сокеты у процессора и материнской платы");
            else
                return ValidationResult.Success();
        }
    }
}