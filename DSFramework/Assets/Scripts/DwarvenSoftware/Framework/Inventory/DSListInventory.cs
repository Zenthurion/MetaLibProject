namespace DwarvenSoftware.Framework.Inventory
{
    public class DSListInventory : DSInventory
    {
        public DSListInventory(IStorageCapacityProvider capacityProvider) : base(capacityProvider)
        {
            
        }
        public override void AddItem(IInventoryItem item, int amount = 1)
        {
            var stack = GetAvailableStack(item);
            if (stack == null || !stack.HasSpace)
            {
                if (Contents.Count >= Capacity.Capacity) return;
                stack = AddNewStack(item, 0);
            }
            
            if (stack.AvailableSpace < amount)
            {
                amount -= stack.AvailableSpace;
                stack.Add(stack.AvailableSpace);
                AddItem(item, amount);
            }
            else
            {
                stack.Add(amount);
            }
        }
        
        public override void RemoveItem(IInventoryItem item, int amount = 1)
        {
            IInventoryItemStack stack;
            while((stack = GetStack(item)) != null && amount > 0) {
                if (stack.Count <= amount)
                {
                    amount -= stack.Count;
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
}