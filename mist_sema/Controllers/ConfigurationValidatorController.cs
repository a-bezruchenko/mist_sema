using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;
using mist_sema.Validators;

namespace mist_sema.Controllers
{
    [ApiController]
    [Route("validate_configuration")]
    public class ConfigurationValidatorController : ControllerBase
    {
        readonly protected IConfigurationRepository configurationRepository;
        readonly protected IComponentRepository componentRepository;
        readonly protected IEnumerable<IValidator> componentValidators;
        readonly protected IControllerUtils controllerUtils;

        public ConfigurationValidatorController(IConfigurationRepository configurationRepository, 
            IComponentRepository componentRepository,
            IEnumerable<IValidator> validators,
            IControllerUtils controllerUtils)
        {
            this.configurationRepository = configurationRepository;
            this.componentRepository = componentRepository;
            componentValidators = validators;
            this.controllerUtils = controllerUtils;
        }

        [HttpGet]
        public ValidationResult Validate(IEnumerable<long> componentIds)
        {
            ComputerConfiguration? computerConfiguration = controllerUtils.GetComputerConfiguration(componentIds, componentRepository);
            if (computerConfiguration == null)
            {
                return ValidationResult.Failure("Не удалось найти все указанные компоненты");
            }

            var result = ValidationResult.Merge(componentValidators.Select((v) => v.Validate(computerConfiguration)));
            return result;
        }


    }
}
