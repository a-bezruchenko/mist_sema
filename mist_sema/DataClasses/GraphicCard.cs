using System.Runtime.Serialization;

namespace mist_sema.DataClasses
{
    public class GraphicCard : ComputerComponent
    {
        public double MemoryVolume { get; set; }
        public double Perfomance { get; set; }
    }
}
