using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers
{
    [ApiController]
    [Route("power_supplies")]
    public class PowerSupplyController : ComponentsControllerBase<PowerSupply>
    {
        public PowerSupplyController(IComponentRepository componentRepository) : base(componentRepository)
        {
        }
    }
}