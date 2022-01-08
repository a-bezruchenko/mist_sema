using mist_sema.DataClasses;

namespace mist_sema.Model
{
    public class ComponentRepository : IComponentRepository
    {
        readonly protected ComponentContext _context;

        public ComponentRepository(ComponentContext context)
        {
            _context = context;
        }

        public void Add<T>(T newComponent) where T : ComputerComponent
        {
            _context.Set<T>().Add(newComponent);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public T? Get<T>(long id) where T : ComputerComponent
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll<T>() where T : ComputerComponent
        {
            return _context.Set<T>();
        }
    }
}
