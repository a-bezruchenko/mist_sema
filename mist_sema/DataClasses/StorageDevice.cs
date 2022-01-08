namespace mist_sema.DataClasses;

public class StorageDevice : ComputerComponent
{
    public StorageDevice()
    {
        StorageType = "";
    }

    public string StorageType { get; set; }
    public double Volume { get; set; }
}