using Microsoft.AspNetCore.Mvc;
using mist_sema.Model;
using mist_sema.Validators;

namespace mist_sema.Controllers;

[ApiController]
[Route("validate_configuration")]
public class ConfigurationValidatorController : ControllerBase
{
    protected readonly IComponentRepository componentRepository;
    protected readonly IEnumerable<IValidator> componentValidators;
    protected readonly IControllerUtils controllerUtils;

    public ConfigurationValidatorController(IComponentRepository componentRepository,
        IEnumerable<IValidator> validators,
        IControllerUtils controllerUtils)
    {
        this.componentRepository = componentRepository;
        componentValidators = validators;
        this.controllerUtils = controllerUtils;
    }

    [HttpPost]
    public ValidationResult Validate([FromBody] IEnumerable<long> componentIds)
    {
        var computerConfiguration =
            controllerUtils.GetComputerConfiguration(componentIds, componentRepository);
        if (computerConfiguration == null) return ValidationResult.Failure("Не удалось найти все указанные компоненты");

        var result = ValidationResult.Merge(componentValidators.Select(v => v.Validate(computerConfiguration)));
        return result;
    }
}