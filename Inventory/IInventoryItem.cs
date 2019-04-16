namespace DwarvenSoftware.Framework.Inventory
{
    public interface IInventoryItem
    {
        int Id { get; }
        string Name { get; }
        float Weight { get; }
    }
}