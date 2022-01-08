using mist_sema.DataClasses;

namespace mist_sema.Model;

public class ComponentRepository : IComponentRepository
{
    protected readonly ComponentContext _context;

    public ComponentRepository(ComponentContext context)
    {
        _context = context;
    }

    public void Add<T>(T newComponent) where T : ComputerComponent
    {
        _context.Set<T>().Add(newComponent);
        _context.SaveChanges();
    }

    public void Delete<T>(long id) where T : ComputerComponent
    {
        T? toDelete = _context.Set<T>().FirstOrDefault(x => x.Id == id);
        if (toDelete != null)
        {
            _context.Set<T>().Remove(toDelete);
            _context.SaveChanges();
        }

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