namespace mist_sema.DataClasses
{
    public abstract class ComputerComponent
    {
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public string Manufacturer { get; set; }
        public double Consumed_power { get; set; }

        protected ComputerComponent()
        {
            Name = "";
            ImageLink = "";
            Manufacturer = "";
        }
    }
}
