using mist_sema.DataClasses;

namespace mist_sema.Model
{
    public class ComponentRepository : IComponentRepository
    {


        public void Add<T>(T newComponent) where T : ComputerComponent
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public T? Get<T>(long id) where T : ComputerComponent
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : ComputerComponent
        {
            throw new NotImplementedException();
        }

        public GraphicCard GetGraphicCardAll()
        {

        }

        public GraphicCard GetGraphicCard(long id)
        {

        }
    }
}
