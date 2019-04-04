namespace DwarvenSoftware.Inventory
{
    public interface IInventoryItemStack
    {
        IInventoryItem Type { get; }
        int Count { get; set; }
        int Capacity { get; }
        int AvailableSpace { get; }
        bool HasSpace { get; }
        void Add(int amount);
        void Remove(int amount);
    }
}