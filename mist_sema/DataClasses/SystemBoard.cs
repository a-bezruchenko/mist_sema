namespace mist_sema.DataClasses
{
    public class SystemBoard : ComputerComponent
    {
        public string ProcessorSocketType { get; set; }
        public string MemoryGenerationName { get; set; }
        public int SataPortsCount { get; set; }
        public int MemorySlotsCount { get; set; }

        public SystemBoard()
        {
            ProcessorSocketType = "";
            MemoryGenerationName = "";
        }
    }
}