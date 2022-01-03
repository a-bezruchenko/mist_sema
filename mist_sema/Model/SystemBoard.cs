namespace mist_sema.Model
{
    public class SystemBoard : ComputerComponent
    {
        int SocketTypeId { get; set; }
        int MemoryGenerationId { get; set; }
        int SataPortsCount { get; set; }
        int MemorySlotsCount { get; set; }
    }
}
