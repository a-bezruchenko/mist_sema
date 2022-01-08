namespace mist_sema.DataClasses;

public class Ram : ComputerComponent
{
    public Ram()
    {
        GenerationName = "";
    }

    public double Volume { get; set; }
    public string GenerationName { get; set; }
}