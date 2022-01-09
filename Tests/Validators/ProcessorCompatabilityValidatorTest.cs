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

namespace Tests.Validators
{
    public class ProcessorCompatabilityValidatorTest
    {
        [Fact]
        public void Compatible()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor() { ProcessorSocketType = "123" },
                new SystemBoard() { ProcessorSocketType = "123" },
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram(),
            });

            IValidator validator = new ProcessorCompatabilityValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.True(res.IsValid);
        }

        [Fact]
        public void NotCompatible()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor() { ProcessorSocketType = "123" },
                new SystemBoard() { ProcessorSocketType = "321" },
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram(),
            });

            IValidator validator = new ProcessorCompatabilityValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }
    }
}
