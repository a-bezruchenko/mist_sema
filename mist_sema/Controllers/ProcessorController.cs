using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers
{
    [ApiController]
    [Route("processors")]
    public class ProcessorController : ComponentsControllerBase<Processor>
    {
        public ProcessorController(IComponentRepository componentRepository) : base(componentRepository)
        {
        }
    }
}
