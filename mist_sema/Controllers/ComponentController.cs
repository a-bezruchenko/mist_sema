using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers;

public abstract class ComponentsControllerBase<T> : ControllerBase where T : ComputerComponent, new()
{
    private readonly IComponentRepository componentRepository;

    protected ComponentsControllerBase(IComponentRepository componentRepository)
    {
        this.componentRepository = componentRepository;
    }

    [HttpGet]
    public IEnumerable<T> Get()
    {
        return componentRepository.GetAll<T>();
    }
}