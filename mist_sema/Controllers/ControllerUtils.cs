using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers;

public class ControllerUtils : IControllerUtils
{
    public ComputerConfiguration? GetComputerConfiguration(IEnumerable<long> ids,
        IComponentRepository componentRepository)
    {
        var isOk = true;
        var res = new List<ComputerComponent>();
        foreach (var id in ids)
        {
            var computerComponent = componentRepository.Get<ComputerComponent>(id);
            if (computerComponent == null)
            {
                isOk = false;
                break;
            }

            res.Add(computerComponent);
        }

        return isOk ? new ComputerConfiguration(res.ToArray()) : null;
    }
}