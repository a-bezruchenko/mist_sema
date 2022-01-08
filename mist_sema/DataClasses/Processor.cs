namespace mist_sema.DataClasses;

public class Processor : ComputerComponent
{
    public Processor()
    {
        ProcessorSocketType = "";
    }

    public string ProcessorSocketType { get; set; }
    public double Perfomance { get; set; }
}