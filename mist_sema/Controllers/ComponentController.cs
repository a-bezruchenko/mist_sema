using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;

namespace mist_sema.Controllers
{
    [ApiController]
    [Route("Components")]
    public class ComponentsController : ControllerBase
    {
        private readonly ILogger<ComponentsController> _logger;

        public ComponentsController(ILogger<ComponentsController> logger)
        {
            _logger = logger;
        }

        // TODO: читать из бд

        /*[HttpGet]
        public string Get()
        {
            return "kek";
        }*/

        [HttpGet]
        public IEnumerable<ComputerComponent> Get()
        {
            List<ComputerComponent> res = new List<ComputerComponent>();
            res.Add(new Processor() { 
                Consumed_power = 100, ImageLink = "nope.png", Manufacturer = "Intel", Name = "Triple Core T800", Perfomance = 100500, SocketTypeId = 1, Price = 50000
            });

            res.Add(new Processor() { 
                Consumed_power = 150, 
                ImageLink = "nope.png", 
                Manufacturer = "Intel", 
                Name = "Triple Core T805", 
                Perfomance = 100501, 
                SocketTypeId = 1, 
                Price = 100000
            });

            res.Add(new Processor() { 
                Consumed_power = 300, 
                ImageLink = "nope.png", 
                Manufacturer = "AMD", 
                Name = "Athlant", 
                Perfomance = 100000, 
                SocketTypeId = 2, 
                Price = 5000
            });

            res.Add(new Ram()
            {
                Consumed_power = 5,
                ImageLink = "nope.png",
                Manufacturer = "no name",
                Name = "4GB DDR4 RAM by noname",
                Volume = 4,
                GenerationId = 4,
                Price = 2000
            });

            res.Add(new SystemBoard()
            {
                Consumed_power = 5,
                ImageLink = "nope.png",
                Manufacturer = "no name",
                Name = "basic systemboard by noname",
                MemorySlotsCount = 2,
                MemoryGenerationId = 4,
                SataPortsCount = 2,
                SocketTypeId = 1,
                Price = 2000
            });

            res.Add(new SystemBoard()
            {
                Consumed_power = 5,
                ImageLink = "nope.png",
                Manufacturer = "no name",
                Name = "basic systemboard by noname",
                MemorySlotsCount = 2,
                MemoryGenerationId = 4,
                SataPortsCount = 2,
                SocketTypeId = 1,
                Price = 2000
            });


            return res;
        }
    }
}
