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
    public class ComponentCountValidatorTest
    {
        [Fact]
        public void ValidConfiguration()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram(),
            });

            IValidator validator = new ComponentsCountValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.True(res.IsValid);
        }

        [Fact]
        public void NoProcessor()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram(),
            });

            IValidator validator = new ComponentsCountValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void TooManyProcessors()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new Processor(),
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram(),
            });

            IValidator validator = new ComponentsCountValidator();

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
                new Ram(),
            });

            IValidator validator = new ComponentsCountValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void TooManySystemBoards()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram(),
            });

            IValidator validator = new ComponentsCountValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void NoGraphicCard()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new StorageDevice(),
                new PowerSupply(),
                new Ram(),
            });

            IValidator validator = new ComponentsCountValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void TooManyGraphicCards()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new GraphicCard(),
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram(),
            });

            IValidator validator = new ComponentsCountValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void NoStorageDevice()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new GraphicCard(),
                new PowerSupply(),
                new Ram(),
            });

            IValidator validator = new ComponentsCountValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void TooManyStorageDevices()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new GraphicCard(),
                new StorageDevice(),
                new StorageDevice(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram(),
            });

            IValidator validator = new ComponentsCountValidator();

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
                new Processor(),
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new GraphicCard(),
                new StorageDevice(),
                new Ram(),
            });

            IValidator validator = new ComponentsCountValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void TooManyPowerSupplies()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new PowerSupply(),
                new Ram(),
            });

            IValidator validator = new ComponentsCountValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void NoRam()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
            });

            IValidator validator = new ComponentsCountValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }

        [Fact]
        public void TooManyRams()
        {
            // Arrange
            ComputerConfiguration computerConfiguration = new ComputerConfiguration(new ComputerComponent[]
            {
                new Processor(),
                new SystemBoard() { SataPortsCount = 2, MemorySlotsCount = 2 },
                new GraphicCard(),
                new StorageDevice(),
                new PowerSupply(),
                new Ram(),
                new Ram(),
                new Ram(),
            });

            IValidator validator = new ComponentsCountValidator();

            // Act
            var res = validator.Validate(computerConfiguration);

            // Assert
            Assert.False(res.IsValid);
        }
    }
}
