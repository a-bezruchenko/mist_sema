namespace mist_sema.Model
{
    public class StorageDeviceType
    {
        int Id
        {
            get; set;
        }
        string Name
        {
            get; set;
        }
        public StorageDeviceType()
        {
            Name = "";
        }
    }
}
