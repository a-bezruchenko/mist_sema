namespace mist_sema.DataClasses;

public class ComputerConfiguration
{
    public long Id { get; set; }

    public readonly ComputerComponent[] components;

    public ComputerConfiguration(ComputerComponent[] components)
    {
        this.components = components;
    }
}