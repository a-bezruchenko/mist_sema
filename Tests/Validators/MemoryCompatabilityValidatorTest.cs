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
    public class MemoryCompatabilityValidatorTest
    {
        [Fact]
        public void Compatible()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new SystemBoard() { MemoryGenerationName = "123" },
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram() { GenerationName = "123" },
            });

            IValidator validator = new MemoryCompatabilityValidator();

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
                new Processor(),
                new SystemBoard() { MemoryGenerationName = "123" },
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram() { GenerationName = "321" },
            });

            IValidator validator = new MemoryCompatabilityValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void DifferentGenerationsInRamDevices()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new SystemBoard() { MemoryGenerationName = "123" },
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram() { GenerationName = "321" },
                new Ram() { GenerationName = "123" },
            });

            IValidator validator = new MemoryCompatabilityValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void NoSystemBoard()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram() { GenerationName = "321" },
            });

            IValidator validator = new MemoryCompatabilityValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }
    }
}
