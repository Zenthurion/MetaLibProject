namespace DwarvenSoftware.Framework.Inventory
{
    public interface IInventoryStack : IInventoryItem
    {
        int Capacity { get; }
        int Count { get; }
        
        int AvailableSpace { get; }
        bool HasSpace { get; }

        void Add(int amount);
        void Remove(int amount);
    }
}