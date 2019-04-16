namespace DwarvenSoftware.Framework.Inventory
{
    public class InventoryItem : IInventoryItem
    {
        public int Id { get; }
        public string Name { get; }
        public float Weight { get; }

        public InventoryItem(int id, string name, float weight)
        {
            Id = id;
            Name = name;
            Weight = weight;
        }
    }
}