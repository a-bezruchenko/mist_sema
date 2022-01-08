using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using mist_sema.Model;

namespace mist_sema.Controllers;

public class ConfigurationSummary
{
    public string? TotalPrice { get; set; }
    public string? Error { get; set; }
}

[ApiController]
[Route("configuration_summary")]
public class ConfigurationSummaryController : ControllerBase
{
    private readonly IComponentRepository componentRepository;
    private readonly IControllerUtils controllerUtils;

    public ConfigurationSummaryController(IConfigurationRepository configurationRepository,
        IComponentRepository componentRepository,
        IControllerUtils controllerUtils)
    {
        this.componentRepository = componentRepository;
        this.controllerUtils = controllerUtils;
    }

    [HttpPost]
    public ConfigurationSummary GetAmount([FromBody] IEnumerable<long> componentIds)
    {
        var res = new ConfigurationSummary();

        var computerConfiguration = controllerUtils.GetComputerConfiguration(componentIds, componentRepository);
        if (computerConfiguration == null)
        {
            res.Error = "Не удалось найти все указанные компоненты";
            return res;
        }

        var sum = computerConfiguration.components.Select(c => c.Price).Sum();
        res.TotalPrice = sum.ToString(CultureInfo.CurrentCulture);

        return res;
    }
}