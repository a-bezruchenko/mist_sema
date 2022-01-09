using mist_sema.Controllers;
using mist_sema.DataClasses;
using mist_sema.Model;
using mist_sema.Validators;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Controllers
{
    public class ConfigurationValidatorControllerTest
    {
        [Fact]
        public void ValidWhenNoValidators()
        {
            // Arrange
            IComponentRepository componentRepository = new TestComponentRepository();
            IEnumerable<IValidator> validators = new List<IValidator>();
            IControllerUtils controllerUtils = new ControllerUtils();

            var controller = new ConfigurationValidatorController(componentRepository, validators, controllerUtils);
            IEnumerable<long> componentIds = new List<long>();

            // Act
            var res = controller.Validate(componentIds);

            // Assert
            Assert.True(res.IsValid);
        }

        [Fact]
        public void ReturnsErrorWhenCantConvert()
        {
            // Arrange
            long componentId = 4;
            IEnumerable<long> componentIds = new List<long>() { componentId };

            IComponentRepository componentRepository = new TestComponentRepository();
            IEnumerable<IValidator> validators = new List<IValidator>();
            var controllerUtilsMock = new Mock<IControllerUtils>();
            controllerUtilsMock.Setup(utils => utils.GetComputerConfiguration(componentIds, componentRepository)).Returns((ComputerConfiguration?)null);
            IControllerUtils controllerUtils = controllerUtilsMock.Object;

            var controller = new ConfigurationValidatorController(componentRepository, validators, controllerUtils);
            
            // Act
            var res = controller.Validate(componentIds);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void ReturnsErrorWhenValidationFails()
        {
            // Arrange
            long componentId = 4;
            IEnumerable<long> componentIds = new List<long>() { componentId };

            IComponentRepository componentRepository = new TestComponentRepository();
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[0]);

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(utils => utils.Validate(computerConfiguration)).Returns(ValidationResult.Failure("test"));

            var controllerUtilsMock = new Mock<IControllerUtils>();
            controllerUtilsMock.Setup(utils => utils.GetComputerConfiguration(componentIds, componentRepository)).Returns(computerConfiguration);
            IControllerUtils controllerUtils = controllerUtilsMock.Object;
            IEnumerable<IValidator> validators = new List<IValidator>() { validatorMock.Object };

            var controller = new ConfigurationValidatorController(componentRepository, validators, controllerUtils);

            // Act
            var res = controller.Validate(componentIds);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void ReturnsValidWhenValidationSucceeds()
        {
            // Arrange
            long componentId = 4;
            IEnumerable<long> componentIds = new List<long>() { componentId };

            IComponentRepository componentRepository = new TestComponentRepository();
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[0]);

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(utils => utils.Validate(computerConfiguration)).Returns(ValidationResult.Success());

            var controllerUtilsMock = new Mock<IControllerUtils>();
            controllerUtilsMock.Setup(utils => utils.GetComputerConfiguration(componentIds, componentRepository)).Returns(computerConfiguration);
            IControllerUtils controllerUtils = controllerUtilsMock.Object;
            IEnumerable<IValidator> validators = new List<IValidator>() { validatorMock.Object };

            var controller = new ConfigurationValidatorController(componentRepository, validators, controllerUtils);

            // Act
            var res = controller.Validate(componentIds);

            // Assert
            Assert.True(res.IsValid);
        }
    }
}
