using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers;

[ApiController]
[Route("rams")]
public class RamController : ComponentsControllerBase<Ram>
{
    public RamController(IComponentRepository componentRepository) : base(componentRepository)
    {
    }
}