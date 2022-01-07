using System.Runtime.Serialization;

namespace mist_sema.DataClasses
{
    public class Processor : ComputerComponent
    {
        public string ProcessorSocketType { get; set; }
        public double Perfomance { get; set; }

        public Processor()
        {
            ProcessorSocketType = "";
        }
    }
}