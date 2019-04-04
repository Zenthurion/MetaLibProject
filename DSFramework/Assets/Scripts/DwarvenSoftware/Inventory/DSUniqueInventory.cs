using UnityEngine.Serialization;

namespace DwarvenSoftware.Inventory
{
    public class DSUniqueInventory : DSInventory
    {
        public DSUniqueInventory(IStorageCapacityProvider capacityProvider) : base(capacityProvider)
        {
            
        }
        public override void AddItem(IInventoryItem item, int amount = 1)
        {
            if (TryGetIndex(item, out var index))
            {
                if(StackHasSpace(index)) Contents[index].Add(amount);
            }
            else if(Contents.Count < Capacity.Capacity)
            {
                AddNewStack(item, amount);
            }
        }
        
        public override void RemoveItem(IInventoryItem item, int amount = 1)
        {
            var stack = GetStack(item);
            if(stack == null) return;
            if (stack.Count <= amount)
            {
                stack.Remove(stack.Count);
                Contents.Remove(stack);
            }
            else
            {
                stack.Remove(amount);
            }
        }
    }
}