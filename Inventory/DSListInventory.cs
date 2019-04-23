namespace DwarvenSoftware.Framework.Inventory
{
    public class DSListInventory : DSInventory
    {
        public DSListInventory(IStorageCapacityProvider capacityProvider = null) : base(capacityProvider)
        {
        }

        public override TransactionResult AddItem(IInventoryItem item, int amount = 1)
        {
            var lacking = amount;
            if (item is IInventoryStack)
            {
                while (lacking > 0)
                {
                    var stack = GetAvailableStack(item);
                    if (stack == null || !stack.HasSpace)
                    {
                        if (Contents.Count >= Capacity) return new TransactionResult(item, lacking);
                        stack = AddNewItem(item, 0) as IInventoryStack;
                    }

                    if (stack.AvailableSpace < lacking)
                    {
                        lacking -= stack.AvailableSpace;
                        stack.Add(stack.AvailableSpace);
                    }
                    else
                    {
                        stack.Add(lacking);
                        lacking = 0;
                    }
                }

                return new TransactionResult(item, lacking);
            }

            while (lacking > 0 && Contents.Count < Capacity)
            {
                lacking--;
                AddNewItem(item);
            }

            return new TransactionResult(item, lacking);
        }

        public override TransactionResult RemoveItem(IInventoryItem item, int amount = 1)
        {
            IInventoryItem i;
            var lacking = amount;
            while ((i = GetItem(item)) != null && lacking > 0)
            {
                if (i is IInventoryStack stack)
                {
                    if (stack.Count <= lacking)
                    {
                        lacking -= stack.Count;
                        stack.Remove(stack.Count);
                        Contents.Remove(stack);
                    }
                    else
                    {
                        stack.Remove(lacking);
                        lacking = 0;
                    }
                }
                else
                {
                    Contents.Remove(i);
                    lacking--;
                }
            }

            return new TransactionResult(item, lacking);
        }

        public override bool CanFit(IInventoryItem item)
        {
            if (item is IInventoryStack stack)
                return stack.Capacity > stack.Count;
            
            return Capacity > Count;
        }
    }
}