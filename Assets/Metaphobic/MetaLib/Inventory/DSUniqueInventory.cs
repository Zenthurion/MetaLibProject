namespace DwarvenSoftware.Framework.Inventory
{
    public class DSUniqueInventory : DSInventory
    {
        public DSUniqueInventory(IStorageCapacityProvider capacityProvider) : base(capacityProvider)
        {
            
        }
        public override TransactionResult AddItem(IInventoryItem item, int amount = 1)
        {
            var lacking = amount;
            var i = GetItem(item); 
            if (i != null)
            { 
                if (!(i is IInventoryStack stack) || !stack.HasSpace) 
                    return new TransactionResult(item, lacking);

                lacking = amount >= stack.AvailableSpace ? amount - stack.AvailableSpace : 0;
                stack.Add(amount);
                return new TransactionResult(item, lacking);

            }

            if (Contents.Count < Capacity)
            {
                i = AddNewItem(item);
                if (i is IInventoryStack stack)
                {
                    lacking = amount >= stack.AvailableSpace ? amount - stack.AvailableSpace : 0;
                    stack.Add(amount);
                }
            }

            return new TransactionResult(item, lacking);
        }
        
        public override TransactionResult RemoveItem(IInventoryItem item, int amount = 1)
        {
            var i = GetItem(item);
            if(i == null) return new TransactionResult(item, 0);
            var lacking = amount;
            if (i is IInventoryStack stack)
            {
                if (stack.Count <= lacking)
                {
                    lacking = amount - stack.Count;
                    stack.Remove(stack.Count);
                    Contents.Remove(stack);
                }
                else
                {
                    stack.Remove(amount);
                }
            }
            else
            {
                Contents.Remove(i);
                lacking--;
            }
            return new TransactionResult(item, lacking);
        }

        public override bool CanFit(IInventoryItem item)
        {
            if (!Contents.Contains(item) && Capacity > Count) return true;
            if (item is IInventoryStack stack) return stack.Capacity > stack.Count;
            return false;

        }
    }
}