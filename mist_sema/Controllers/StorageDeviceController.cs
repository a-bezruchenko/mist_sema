using Microsoft.AspNetCore.Mvc;
using mist_sema.DataClasses;
using mist_sema.Model;

namespace mist_sema.Controllers
{
    [ApiController]
    [Route("storage_devices")]
    public class StorageDeviceController : ComponentsControllerBase<StorageDevice>
    {
        public StorageDeviceController(IComponentRepository componentRepository) : base(componentRepository)
        {
        }
    }
}