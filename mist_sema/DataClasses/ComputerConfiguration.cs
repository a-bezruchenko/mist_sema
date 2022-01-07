namespace mist_sema.DataClasses
{
    public class ComputerConfiguration
    {
        public long Id { get; set; }
        readonly public ComputerComponent[] components;

        public ComputerConfiguration(ComputerComponent[] components)
        {
            this.components = components;
        }
    }
}
