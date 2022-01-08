using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers
{
    public class ConfigurationSummary
    {
        public string? TotalPrice { get; set; }
        public string? Error { get; set; }
    }

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

        [HttpGet]
        public ConfigurationSummary GetAmount(IEnumerable<long> componentIds)
        {
            ConfigurationSummary res = new ConfigurationSummary();

            ComputerConfiguration? computerConfiguration = controllerUtils.GetComputerConfiguration(componentIds, componentRepository);
            if (computerConfiguration == null)
            {
                res.Error = "Не удалось найти все указанные компоненты";
                return res;
            }

            decimal sum = computerConfiguration.components.Select(c => c.Price).Sum();
            res.TotalPrice = sum.ToString();

            return res;
        }
    }
}
