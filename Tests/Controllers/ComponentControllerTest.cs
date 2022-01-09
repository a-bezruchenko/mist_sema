using mist_sema.Controllers;
using mist_sema.DataClasses;
using mist_sema.Model;
using System.Linq;
using Xunit;

namespace Tests.Controllers
{
    public class ComponentControllerTest
    {
        [Fact]
        public void GraphicCardsControllerWorks()
        {
            // Arrange
            IComponentRepository componentRepository = new TestComponentRepository();
            var componentsControllerBase = new GraphicCardController(componentRepository);

            // Act
            var res = componentsControllerBase.Get();

            // Assert
            Assert.NotNull(res);
            Assert.Equal(componentRepository.GetAll<GraphicCard>().Count(), res?.Count());
        }

        [Fact]
        public void ProcessorControllerWorks()
        {
            // Arrange
            IComponentRepository componentRepository = new TestComponentRepository();
            var componentsControllerBase = new ProcessorController(componentRepository);

            // Act
            var res = componentsControllerBase.Get();

            // Assert
            Assert.NotNull(res);
            Assert.Equal(componentRepository.GetAll<Processor>().Count(), res?.Count());
        }


        [Fact]
        public void PowerSupplyControllerWorks()
        {
            // Arrange
            IComponentRepository componentRepository = new TestComponentRepository();
            var componentsControllerBase = new PowerSupplyController(componentRepository);

            // Act
            var res = componentsControllerBase.Get();

            // Assert
            Assert.NotNull(res);
            Assert.Equal(componentRepository.GetAll<PowerSupply>().Count(), res?.Count());
        }

        [Fact]
        public void RamControllerWorks()
        {
            // Arrange
            IComponentRepository componentRepository = new TestComponentRepository();
            var componentsControllerBase = new RamController(componentRepository);

            // Act
            var res = componentsControllerBase.Get();

            // Assert
            Assert.NotNull(res);
            Assert.Equal(componentRepository.GetAll<Ram>().Count(), res?.Count());
        }

        [Fact]
        public void StorageDeviceControllerWorks()
        {
            // Arrange
            IComponentRepository componentRepository = new TestComponentRepository();
            var componentsControllerBase = new StorageDeviceController(componentRepository);

            // Act
            var res = componentsControllerBase.Get();

            // Assert
            Assert.NotNull(res);
            Assert.Equal(componentRepository.GetAll<StorageDevice>().Count(), res?.Count());
        }

        [Fact]
        public void SystemBoardControllerWorks()
        {
            // Arrange
            IComponentRepository componentRepository = new TestComponentRepository();
            var componentsControllerBase = new SystemBoardController(componentRepository);

            // Act
            var res = componentsControllerBase.Get();

            // Assert
            Assert.NotNull(res);
            Assert.Equal(componentRepository.GetAll<SystemBoard>().Count(), res?.Count());
        }
    }
}