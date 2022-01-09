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

namespace Tests.Validators
{
    public class TotalPowerValidatorTest
    {
        [Fact]
        public void EnoughPower()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor() { Consumed_power = 100 },
                new SystemBoard() { Consumed_power = 100 },
                new GraphicCard() { Consumed_power = 100 },
                new StorageDevice() { Consumed_power = 100 },
                new PowerSupply() { Consumed_power = 1000, Efficiency = 1 },
                new Ram() { Consumed_power = 100 },
            });

            IValidator validator = new TotalPowerValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.True(res.IsValid);
        }

        [Fact]
        public void NotEnoughPower()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor() { Consumed_power = 100 },
                new SystemBoard() { Consumed_power = 100 },
                new GraphicCard() { Consumed_power = 100 },
                new StorageDevice() { Consumed_power = 100 },
                new PowerSupply() { Consumed_power = 100, Efficiency = 1 },
                new Ram() { Consumed_power = 100 },
            });

            IValidator validator = new TotalPowerValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void NoPowerSupply()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor() { Consumed_power = 100 },
                new SystemBoard() { Consumed_power = 100 },
                new GraphicCard() { Consumed_power = 100 },
                new StorageDevice() { Consumed_power = 100 },
                new Ram() { Consumed_power = 100 },
            });

            IValidator validator = new TotalPowerValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }
    }
}
