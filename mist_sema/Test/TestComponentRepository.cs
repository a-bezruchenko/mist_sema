using mist_sema.DataClasses;

namespace mist_sema.Model
{
    public class TestComponentRepository : IComponentRepository
    {
        static List<ComputerComponent> data = new List<ComputerComponent>
        {
            new GraphicCard()
            {
                Id = 1,
                Consumed_power = 9010,
                ImageLink = "nope.png",
                Manufacturer = "NVidia",
                Name = "RTX 4099",
                Perfomance = 100501,
                MemoryVolume = 128,
                Price = 5000000000
            },

            new GraphicCard()
            {
                Id = 2,
                Consumed_power = 9000,
                ImageLink = "nope.png",
                Manufacturer = "NVidia",
                Name = "RTX 3090",
                Perfomance = 100000,
                MemoryVolume = 32,
                Price = 50000000
            },

            new GraphicCard()
            {
                Id = 3,
                Consumed_power = 1500,
                ImageLink = "nope.png",
                Manufacturer = "AMD",
                Name = "Radeon XR8600 XXL",
                Perfomance = 90000,
                MemoryVolume = 16,
                Price = 50000
            },
            new GraphicCard()
            {
                Id = 4,
                Consumed_power = 50,
                ImageLink = "nope.png",
                Manufacturer = "NVidia",
                Name = "GTX 110M",
                Perfomance = 5,
                MemoryVolume = 0.25,
                Price = 1000
            },
            new PowerSupply()
            {
                Id = 5,
                Consumed_power = 500,
                ImageLink = "nope.png",
                Manufacturer = "no name",
                Name = "basic power supply by noname",
                Efficiency = 0.9,
                Price = 2000
            },
            new PowerSupply()
            {
                Id = 6,
                Consumed_power = 1000,
                ImageLink = "nope.png",
                Manufacturer = "no name",
                Name = "advanced power supply by noname",
                Efficiency = 0.99,
                Price = 4000
            },
            new Processor()
            {
                Id = 7,
                Consumed_power = 100,
                ImageLink = "https://items.s1.citilink.ru/1593041_v01_b.jpg",
                Manufacturer = "Intel",
                Name = "Core i7 12700K",
                Perfomance = 100500,
                ProcessorSocketType = "LGA 1700",
                Price = 37690
            },
            new Processor()
            {
                Id = 8,
                Consumed_power = 150,
                ImageLink = "https://items.s1.citilink.ru/1593058_v01_b.jpg",
                Manufacturer = "Intel",
                Name = "Core i9 12900K",
                Perfomance = 100501,
                ProcessorSocketType = "LGA 1700",
                Price = 54490
            },
            new Processor()
            {
                Id = 9,
                Consumed_power = 300,
                ImageLink = "https://items.s1.citilink.ru/1527909_v01_b.jpg",
                Manufacturer = "AMD",
                Name = "Ryzen Threadripper 3990X",
                Perfomance = 100000,
                ProcessorSocketType = "sTRX4",
                Price = 412520
            },
            new Ram()
            {
                Id = 10,
                Consumed_power = 5,
                ImageLink = "nope.png",
                Manufacturer = "Corsair",
                Name = "Corsair DDR4 16GB",
                GenerationName = "DDR4",
                Volume = 16,
                Price = 4500
            },
            new Ram()
            {
                Id = 11,
                Consumed_power = 5,
                ImageLink = "nope.png",
                Manufacturer = "Corsair",
                Name = "Corsair DDR4 8GB",
                GenerationName = "DDR4",
                Volume = 8,
                Price = 3000
            },
            new Ram()
            {
                Id = 12,
                Consumed_power = 5,
                ImageLink = "nope.png",
                Manufacturer = "noname",
                Name = "noname DDR3 4GB",
                GenerationName = "DDR3",
                Volume = 4,
                Price = 500
            },
            new StorageDevice()
            {
                Id = 13,
                Consumed_power = 10,
                ImageLink = "nope.png",
                Manufacturer = "WD",
                Name = "WD Green HDD 500GB",
                StorageType = "HDD",
                Volume = 500,
                Price = 3000
            },
            new StorageDevice()
            {
                Id = 14,
                Consumed_power = 10,
                ImageLink = "nope.png",
                Manufacturer = "WD",
                Name = "WD Green HDD 1TB",
                StorageType = "HDD",
                Volume = 1000,
                Price = 4000
            },
            new StorageDevice()
            {
                Id = 15,
                Consumed_power = 10,
                ImageLink = "nope.png",
                Manufacturer = "WD",
                Name = "WD Green SSD 250GB",
                StorageType = "SSD",
                Volume = 250,
                Price = 4000
            },
            new SystemBoard()
            {
                Id = 16,
                Consumed_power = 5,
                ImageLink = "nope.png",
                Manufacturer = "no name",
                Name = "basic systemboard by noname",
                MemorySlotsCount = 2,
                MemoryGenerationName = "DDR4",
                SataPortsCount = 2,
                ProcessorSocketType = "LGA 1700",
                Price = 2000
            },
            new SystemBoard()
            {
                Id = 17,
                Consumed_power = 5,
                ImageLink = "nope.png",
                Manufacturer = "no name",
                Name = "basic systemboard by noname",
                MemorySlotsCount = 2,
                MemoryGenerationName = "DDR4",
                SataPortsCount = 2,
                ProcessorSocketType = "LGA 1700",
                Price = 2000
            },
        };

        public IEnumerable<T> GetAll<T>() where T : ComputerComponent
        {
            return data.OfType<T>();
        }

        public T? Get<T>(long id) where T : ComputerComponent
        {
            return data.FirstOrDefault((x) => x.Id == id) as T;
        }

        public void Add<T>(T newComponent) where T : ComputerComponent
        {
            data.Add(newComponent);
        }

        public void Delete(long id)
        {
            var component = data.FirstOrDefault((x) => x.Id == id);
            if (component != null)
                data.Remove(component);
        }
    }
}