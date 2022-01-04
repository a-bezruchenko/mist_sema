namespace mist_sema.DataClasses
{
    public class SystemBoard : ComputerComponent
    {
        public int SocketTypeId { get; set; }
        public int MemoryGenerationId { get; set; }
        public int SataPortsCount { get; set; }
        public int MemorySlotsCount { get; set; }
    }
}
