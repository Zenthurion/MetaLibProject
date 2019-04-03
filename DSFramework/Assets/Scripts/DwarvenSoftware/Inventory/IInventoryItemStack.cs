namespace DwarvenSoftware.Inventory
{
    public interface IInventoryItemStack
    {
        IInventoryItem Type { get; }
        int Count { get; set; }
        void Add(int amount);
        void Remove(int amount);
    }
}