using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mist_sema.DataClasses;

public abstract class ComputerComponent
{
    protected ComputerComponent()
    {
        Name = "";
        ImageLink = "";
        Manufacturer = "";
    }

    [Key]

    public long Id { get; set; }

    public string Name { get; set; }

    public string ImageLink { get; set; }

    public string Manufacturer { get; set; }

    public double Consumed_power { get; set; }

    public decimal Price { get; set; }
}