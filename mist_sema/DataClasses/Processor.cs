using System.Runtime.Serialization;

namespace mist_sema.DataClasses
{
    public class Processor : ComputerComponent
    {
        public int SocketTypeId { get; set; }
        public double Perfomance { get; set; }
    }
}
