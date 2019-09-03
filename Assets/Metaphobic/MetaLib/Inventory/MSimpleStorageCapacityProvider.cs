namespace MetaLib.Inventory
{
    public class MSimpleStorageCapacityProvider : IStorageCapacityProvider
    {
        public int Capacity { get; }

        public MSimpleStorageCapacityProvider(int capacity)
        {
            Capacity = capacity;
        }
    }
}