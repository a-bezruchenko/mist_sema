using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers
{
    [ApiController]
    [Route("configuration_summary")]
    public class ConfigurationSummaryController : ControllerBase
    {
        readonly protected IConfigurationRepository configurationRepository;
        readonly protected IComponentRepository componentRepository;
        readonly protected IControllerUtils controllerUtils;

        public ConfigurationSummaryController(IConfigurationRepository configurationRepository,
            IComponentRepository componentRepository,
            IControllerUtils controllerUtils)
        {
            this.configurationRepository = configurationRepository;
            this.componentRepository = componentRepository;
            this.controllerUtils = controllerUtils;
        }

        [HttpPost]
        public string GetAmount(IEnumerable<long> componentIds)
        {
            ComputerConfiguration? computerConfiguration = controllerUtils.GetComputerConfiguration(componentIds, componentRepository);
            if (computerConfiguration == null)
            {
                return "Не удалось найти все указанные компоненты";
            }

            decimal sum = computerConfiguration.components.Select(c => c.Price).Sum();
            return sum.ToString();
        }
    }
}
