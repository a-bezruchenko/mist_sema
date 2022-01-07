namespace mist_sema.DataClasses
{
    public class Ram : ComputerComponent
    {
        public double Volume { get; set; }
        public string GenerationName { get; set; }

        public Ram()
        {
            GenerationName = "";
        }
    }
}