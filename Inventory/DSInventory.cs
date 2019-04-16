using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace DwarvenSoftware.Framework.Inventory
{
    public abstract class DSInventory : IInventory
    {
        public List<IInventoryItem> Contents { get; }

        public IStorageCapacityProvider CapacityProvider { get; private set; }

        public int Capacity => CapacityProvider.Capacity;

        public int Count => Contents.Count;

        protected DSInventory(IStorageCapacityProvider capacityProvider = null)
        {
            Contents = new List<IInventoryItem>();
            
            CapacityProvider = capacityProvider ?? new DSSimpleStorageCapacityProvider(10);
        }

        protected IInventoryItem GetItem(IInventoryItem item)
        {
            return Contents.FirstOrDefault(i => i.Id == item.Id);
            
        }

        protected IInventoryStack GetAvailableStack(IInventoryItem item)
        {
            foreach (var i in Contents)
            {
                if (i is IInventoryStack stack && stack.Id == item.Id && stack.AvailableSpace > 0) 
                    return stack;
            }

            return null;
        }

        protected bool TryGetIndex(IInventoryItem item, out int index)
        {
            index = -1;
            for (var i = 0; i < Contents.Count; i++)
            {
                if (Contents[i].GetType() != item.GetType()) continue;
                
                index = i;
                return true;
            }

            return false;
        }

        protected int GetStackSize(int index)
        {
            return Contents[index] is IInventoryStack stack ? stack.Count : 1;
        }

        protected bool StackHasSpace(int index)
        {
            return Contents[index] is IInventoryStack stack && StackHasSpace(stack);
        }

        protected bool StackHasSpace(IInventoryStack stack)
        {
            return stack.Count < stack.Capacity;
        }

        protected IInventoryItem AddNewItem<T>(T original, int amount = 0) where T : IInventoryItem
        {
            var res = original is IInventoryStack stack ? 
                new InventoryStack(original.Id, original.Name, original.Weight, stack.Capacity, amount): 
                original is IInventoryItem item ? 
                    new InventoryItem(original.Id, original.Name, original.Weight) : 
                    null;
            
            Contents.Add(res);
            return res;
        }

        public void SetCapacityProvider([NotNull] IStorageCapacityProvider provider)
        {
            CapacityProvider = provider;
        }
        
        public abstract TransactionResult AddItem(IInventoryItem item, int amount = 1);

        public abstract TransactionResult RemoveItem(IInventoryItem item, int amount = 1);

    }
}