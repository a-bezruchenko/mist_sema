using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers
{
    public interface IControllerUtils
    {
        ComputerConfiguration? GetComputerConfiguration(IEnumerable<long> ids, IComponentRepository componentRepository);
    }
}
