using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers
{
    [ApiController]
    [Route("validate_configuration")]
    public class ConfigurationController : ControllerBase
    {
        readonly protected IConfigurationRepository configurationRepository;
        readonly protected IComponentRepository componentRepository;
        readonly protected ComponentValidator componentValidator;

        public ConfigurationController(IConfigurationRepository configurationRepository, IComponentRepository componentRepository)
        {
            this.configurationRepository = configurationRepository;
            this.componentRepository = componentRepository;
            componentValidator = new ComponentValidator();
        }

        [HttpPost]
        public string Validate(IEnumerable<long> componentIds)
        {
            ComputerConfiguration computerConfiguration;
            if (!GetComputerConfiguration(componentIds, out computerConfiguration))
            {
                return "Не удалось найти все указанные компоненты";
            }

            var result = componentValidator.Validate(computerConfiguration);
            return result.IsValid ? "" : result.Message;
        }

        protected bool GetComputerConfiguration(IEnumerable<long> ids, out ComputerConfiguration computerConfiguration)
        {
            bool isOk = true;
            List<ComputerComponent> res = new List<ComputerComponent>();
            foreach (long id in ids)
            {
                ComputerComponent? computerComponent = componentRepository.Get<ComputerComponent>(id);
                if (computerComponent == null)
                {
                    isOk = false;
                    break;
                }
                else
                {
                    res.Add(computerComponent);
                }
            }

            ComputerComponent[] components = isOk ? res.ToArray() : new ComputerComponent[0];
            computerConfiguration = new ComputerConfiguration(components);
            return isOk;
        }
    }
}
