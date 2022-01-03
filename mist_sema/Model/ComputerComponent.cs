namespace mist_sema.Model
{
    public abstract class ComputerComponent
    {
        string Name { get; set; }
        string ImageLink { get; set; }
        string Manufacturer { get; set; }
        double Consumed_power { get; set; }

        protected ComputerComponent()
        {
            Name = "";
            ImageLink = "";
            Manufacturer = "";
        }
    }
}
