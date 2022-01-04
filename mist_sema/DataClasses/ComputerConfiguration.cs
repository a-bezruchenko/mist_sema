namespace mist_sema.DataClasses
{
    public class ComputerConfiguration
    {
        readonly public ComputerComponent[] components;

        public ComputerConfiguration(ComputerComponent[] components)
        {
            this.components = components;
        }
    }
}
