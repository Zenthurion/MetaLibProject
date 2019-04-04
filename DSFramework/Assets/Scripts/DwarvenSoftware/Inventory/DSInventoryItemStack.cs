using System;

namespace DwarvenSoftware.Inventory
{
    public class DSInventoryItemStack : IInventoryItemStack
    {
        public IInventoryItem Type { get; }
        public int Count { get; set; }
        public int Capacity => Type.StackSize;
        public int AvailableSpace => Capacity - Count;
        public bool HasSpace => AvailableSpace > 0;

        public DSInventoryItemStack(IInventoryItem type, int amount = 0)
        {
            Type = type;
            
            Add(amount);
        }
        public void Add(int amount)
        {
            if(amount <= 0) return;
            
            if (Count + amount > Type.StackSize)
                Count = Type.StackSize;
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
    }
}