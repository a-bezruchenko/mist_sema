namespace mist_sema.DataClasses;

public class ComputerConfiguration
{
    public readonly ComputerComponent[] components;

    public ComputerConfiguration(ComputerComponent[] components)
    {
        this.components = components;
    }

    public long Id { get; set; }
}