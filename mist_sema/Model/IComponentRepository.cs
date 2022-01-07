using mist_sema.DataClasses;

namespace mist_sema.Model
{
    public interface IComponentRepository
    {
        IEnumerable<T> GetAll<T>() where T : ComputerComponent;

        T? Get<T>(long id) where T : ComputerComponent;

        void Add<T>(T newComponent) where T : ComputerComponent;

        void Delete(long id);
    }
}