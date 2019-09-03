namespace MetaLib.Inventory
{
    public class InventoryStack : InventoryItem, IInventoryStack
    {
        public int Count { get; private set; }
        public int Capacity { get; }
        public int AvailableSpace => Capacity - Count;
        public bool HasSpace => AvailableSpace > 0;

        public InventoryStack(int id, string name, float weight, int capacity, int initialAmount = 0) : base(id, name, weight)
        {
            Capacity = capacity;
            Add(initialAmount);
        }
        public void Add(int amount)
        {
            if(amount <= 0) return;
            
            if (Count + amount > Capacity)
                Count = Capacity;
            else
                Count += amount;
        }

        public void Remove(int amount)
        {
            if(amount <= 0) return;
            
            if (Count - amount < 0)
                Count = 0;
            else
                Count -= amount;
        }

        public override IInventoryItem Clone()
        {
            return new InventoryStack(Id, Name, Weight, Capacity);
        }
    }
}