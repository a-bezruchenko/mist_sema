using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers;

[ApiController]
[Route("system_boards")]
public class SystemBoardController : ComponentsControllerBase<SystemBoard>
{
    public SystemBoardController(IComponentRepository componentRepository) : base(componentRepository)
    {
    }
}