namespace MetaLib.Inventory
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

        public virtual IInventoryItem Clone()
        {
            return new InventoryItem(Id, Name, Weight);
        }
    }
}