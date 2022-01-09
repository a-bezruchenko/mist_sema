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

namespace Tests
{
    public class ConfigurationSummaryControllerTest
    {
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

            var controller = new ConfigurationSummaryController(componentRepository, controllerUtils);

            // Act
            var res = controller.GetAmount(componentIds);

            // Assert
            Assert.True(res.Error?.Length > 0);
        }

        [Fact]
        public void ReturnsSum()
        {
            // Arrange
            long componentId = 4;
            IEnumerable<long> componentIds = new List<long>() { componentId };

            IComponentRepository componentRepository = new TestComponentRepository();
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[] { new Processor() { Price = 100 } });

            var validatorMock = new Mock<IValidator>();
            validatorMock.Setup(utils => utils.Validate(computerConfiguration)).Returns(ValidationResult.Failure("test"));

            var controllerUtilsMock = new Mock<IControllerUtils>();
            controllerUtilsMock.Setup(utils => utils.GetComputerConfiguration(componentIds, componentRepository)).Returns(computerConfiguration);
            IControllerUtils controllerUtils = controllerUtilsMock.Object;

            var controller = new ConfigurationSummaryController(componentRepository, controllerUtils);

            // Act
            var res = controller.GetAmount(componentIds);

            // Assert
            Assert.Equal("100", res.TotalPrice );
        }

    }
}
