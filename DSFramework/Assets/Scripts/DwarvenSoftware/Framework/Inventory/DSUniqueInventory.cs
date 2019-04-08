namespace DwarvenSoftware.Framework.Inventory
{
    public class DSUniqueInventory : DSInventory
    {
        public DSUniqueInventory(IStorageCapacityProvider capacityProvider) : base(capacityProvider)
        {
            
        }
        public override TransactionResult AddItem(IInventoryItem item, int amount = 1)
        {
            if (TryGetIndex(item, out var index))
            {
                var stack = Contents[index];
                if (!StackHasSpace(index)) return new TransactionResult(item, 0, false);
                
                var overflow = amount - stack.AvailableSpace;
                stack.Add(amount);
                return new TransactionResult(item, overflow > 0 ? overflow : 0, true);
            }
            else if(Contents.Count < Capacity.Capacity)
            {
                var overflow = item.StackSize - amount;
                AddNewStack(item, amount);
                return new TransactionResult(item, overflow > 0 ? overflow : 0, true);
            }
            
            return new TransactionResult(item, 0, false);
        }
        
        public override TransactionResult RemoveItem(IInventoryItem item, int amount = 1)
        {
            var stack = GetStack(item);
            if(stack == null) return new TransactionResult(item, 0, false);
            var lacking = 0;
            if (stack.Count <= amount)
            {
                lacking = amount - stack.Count;
                stack.Remove(stack.Count);
                Contents.Remove(stack);
            }
            else
            {
                stack.Remove(amount);
            }
            return new TransactionResult(item, lacking, true);
        }
    }
}