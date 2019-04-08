namespace DwarvenSoftware.Framework.Inventory
{
    public class DSListInventory : DSInventory
    {
        public DSListInventory(IStorageCapacityProvider capacityProvider) : base(capacityProvider)
        {
            
        }
        public override TransactionResult AddItem(IInventoryItem item, int amount = 1)
        {
            var stack = GetAvailableStack(item);
            if (stack == null || !stack.HasSpace)
            {
                if (Contents.Count >= Capacity.Capacity) return new TransactionResult(item, 0, false);
                stack = AddNewStack(item, 0);
            }

            var lacking = 0;
            if (stack.AvailableSpace < amount)
            {
                lacking -= stack.AvailableSpace - amount;
                amount -= stack.AvailableSpace;
                stack.Add(stack.AvailableSpace);
                lacking += AddItem(item, amount).Remainder;
            }
            else
            {
                stack.Add(amount);
            }
            return new TransactionResult(item, lacking, true);
        }
        
        public override TransactionResult RemoveItem(IInventoryItem item, int amount = 1)
        {
            IInventoryItemStack stack;
            var lacking = amount;
            while((stack = GetStack(item)) != null && amount > 0) {
                if (stack.Count <= amount)
                {
                    lacking -= stack.Count;
                    amount -= stack.Count;
                    stack.Remove(stack.Count);
                    Contents.Remove(stack);
                }
                else
                {
                    lacking -= amount;
                    stack.Remove(amount);
                }
            }
            return new TransactionResult(item, lacking, true);
        }
    }
}