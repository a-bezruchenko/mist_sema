using mist_sema.DataClasses;

namespace mist_sema.Model
{
    public class TestConfigurationRepository : IConfigurationRepository
    {
        static List<ComputerConfiguration> data = new List<ComputerConfiguration>();

        readonly protected IComponentRepository componentRepository;

        public TestConfigurationRepository(IComponentRepository componentRepository)
        {
            this.componentRepository = componentRepository;
        }

        public void Add(ComputerConfiguration computerConfiguration)
        {
            data.Add(computerConfiguration);
        }

        public void Delete(long id)
        {
            var configuration = data.FirstOrDefault((x) => x.Id == id);
            if (configuration != null)
                data.Remove(configuration);
        }

        public ComputerConfiguration? Get(long id)
        {
            return data.FirstOrDefault((x) => x.Id == id);
        }

        public IEnumerable<ComputerConfiguration> GetAll()
        {
            return data;
        }

        public void Update(ComputerConfiguration configuration)
        {
            Delete(configuration.Id);
            Add(configuration);
        }


    }
}
