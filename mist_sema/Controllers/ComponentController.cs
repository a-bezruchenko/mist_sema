using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers
{

    abstract public class ComponentsControllerBase<T> : ControllerBase where T : ComputerComponent, new()
    {
        readonly protected IComponentRepository componentRepository;

        public ComponentsControllerBase(IComponentRepository componentRepository)
        {
            this.componentRepository = componentRepository;
        }

        [HttpGet]
        public IEnumerable<T> Get()
        {
            return componentRepository.GetAll<T>();
        }
    }
}
