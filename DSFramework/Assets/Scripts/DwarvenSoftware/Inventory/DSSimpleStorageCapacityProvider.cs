namespace DwarvenSoftware.Inventory
{
    public class DSSimpleStorageCapacityProvider : IStorageCapacityProvider
    {
        public int Capacity { get; }

        public DSSimpleStorageCapacityProvider(int capacity)
        {
            Capacity = capacity;
        }
    }
}