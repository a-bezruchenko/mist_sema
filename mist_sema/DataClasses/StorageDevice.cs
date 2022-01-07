namespace mist_sema.DataClasses
{
    public class StorageDevice : ComputerComponent
    {
        public string StorageType { get; set; }
        public double Volume { get; set; }

        public StorageDevice()
        {
            StorageType = "";
        }
    }
}