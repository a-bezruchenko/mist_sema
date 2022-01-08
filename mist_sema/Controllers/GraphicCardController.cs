using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers;

[ApiController]
[Route("graphic_cards")]
public class GraphicCardController : ComponentsControllerBase<GraphicCard>
{
    public GraphicCardController(IComponentRepository componentRepository) : base(componentRepository)
    {
    }
}