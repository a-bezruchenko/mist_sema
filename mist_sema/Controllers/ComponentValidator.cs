using mist_sema.DataClasses;
using System.Text;

namespace mist_sema.Controllers
{
    public class ComponentValidator
    {
        public ValidationResult Validate(ComputerConfiguration computerConfiguration)
        {
            StringBuilder errorBuilder = new StringBuilder();

            int systemBoardsCount = computerConfiguration.components.Count((ComputerComponent c) => c is SystemBoard);
            if (systemBoardsCount != 1)
                errorBuilder.Append("Должна быть ровно одна материнская плата");

            int processorsCount = computerConfiguration.components.Count((ComputerComponent c) => c is Processor);
            if (processorsCount != 1)
                errorBuilder.Append("Должен быть ровно один процессор");

            int powerSupplyCount = computerConfiguration.components.Count((ComputerComponent c) => c is PowerSupply);
            if (powerSupplyCount != 1)
                errorBuilder.Append("Должен быть ровно один блок питания");

            // далее предполагается, что материнка, процессор и БП существуют
            // если это не так, прекращаем проверку здесь
            if (errorBuilder.Length > 0)
                return ValidationResult.Failure(errorBuilder.ToString());

            int graphicCardCount = computerConfiguration.components.Count((ComputerComponent c) => c is GraphicCard);
            if (graphicCardCount != 1)
                errorBuilder.Append("Должна быть ровно одна видеокарта");

            SystemBoard systemBoard = (SystemBoard)computerConfiguration.components.First(c => c is SystemBoard);
            
            int storageDeviceCount = computerConfiguration.components.Count((ComputerComponent c) => c is StorageDevice);
            if (storageDeviceCount == 0)
                errorBuilder.Append("Должен быть хотя бы один накопитель");
            else if (storageDeviceCount > systemBoard.SataPortsCount)
                errorBuilder.Append("Накопителей должно быть не больше, чем число SATA портов в материнской плате");

            int ramCount = computerConfiguration.components.Count((ComputerComponent c) => c is Ram);
            if (ramCount == 0)
                errorBuilder.Append("Должна быть хотя бы одна планка памяти");
            else if (ramCount > systemBoard.MemorySlotsCount)
                errorBuilder.Append("Планок памяти должно быть не больше, чем число разъёмов под память в материнской плате");

            // далее предполагается, что память существует
            // если это не так, прекращаем проверку здесь
            if (errorBuilder.Length > 0)
                return ValidationResult.Failure(errorBuilder.ToString());

            int ramGenerationId = ((Ram)computerConfiguration.components.First((ComputerComponent c) => c is Ram)).GenerationId;
            bool memoryGenerationsEqual = computerConfiguration.components
                .Where((ComputerComponent c) => c is Ram)
                .All((ComputerComponent c) => ((Ram)c).GenerationId == ramGenerationId);

            if (!memoryGenerationsEqual)
                errorBuilder.Append("Поколения планок памяти должны быть одинаковы");
            else if (systemBoard.MemoryGenerationId != ramGenerationId)
                errorBuilder.Append("Поколения планок памяти и материнской платы должны быть одинаковы");

            PowerSupply powerSupply = (PowerSupply)computerConfiguration.components.First(c => c is PowerSupply);
            double providedPower = powerSupply.Consumed_power * powerSupply.Efficiency;
            double consumedPower = computerConfiguration.components
                .Where((ComputerComponent c) => c is not PowerSupply)
                .Select((ComputerComponent c) => c.Consumed_power)
                .Sum();

            if (consumedPower > providedPower)
                errorBuilder.Append("Недостаточно мощный блок питания");

            Processor processor = (Processor)computerConfiguration.components.First(c => c is Processor);
            if (processor.SocketTypeId != systemBoard.SocketTypeId)
                errorBuilder.Append("Разные сокеты у процессора и материнской платы");

            if (errorBuilder.Length > 0)
                return ValidationResult.Failure(errorBuilder.ToString());
            else
                return ValidationResult.Success();
        }
    }
}
