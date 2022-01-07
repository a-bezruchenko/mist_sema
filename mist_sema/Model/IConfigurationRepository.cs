using mist_sema.DataClasses;

namespace mist_sema.Model
{
    public interface IConfigurationRepository
    {
        IEnumerable<ComputerConfiguration> GetAll();
        ComputerConfiguration? Get(long id);
        void Add(ComputerConfiguration computerConfiguration);
        void Update(ComputerConfiguration configuration);
        void Delete(long id);
    }
}
