using System;
using System.Collections.Generic;
using DwarvenSoftware.Economy;
using JetBrains.Annotations;

namespace DwarvenSoftware.Inventory
{
    public abstract class DSInventory : IInventory
    {
        public List<IInventoryItemStack> Contents { get; }

        public IStorageCapacityProvider Capacity { get; private set; }

        public int CurrentCapacity => Capacity.Capacity;

        public int StackCount => Contents.Count;

        protected DSInventory(IStorageCapacityProvider capacity = null)
        {
            Contents = new List<IInventoryItemStack>();
            
            Capacity = capacity ?? new DSSimpleStorageCapacityProvider(10);
        }

        protected IInventoryItemStack GetStack(IInventoryItem item)
        {
            foreach (var stack in Contents)
            {
                if (stack.Type == item) return stack;
            }

            return null;
        }

        protected IInventoryItemStack GetAvailableStack(IInventoryItem item)
        {
            foreach (var stack in Contents)
            {
                if (stack.Type == item && stack.AvailableSpace > 0) return stack;
            }

            return null;
        }

        protected bool TryGetIndex(IInventoryItem item, out int index)
        {
            index = -1;
            for (var i = 0; i < Contents.Count; i++)
            {
                if (Contents[i].Type != item) continue;
                
                index = i;
                return true;
            }

            return false;
        }

        protected int GetStackSize(int index)
        {
            return Contents[index].Count;
        }

        protected bool StackHasSpace(int index)
        {
            return StackHasSpace(Contents[index]);
        }

        protected bool StackHasSpace(IInventoryItemStack stack)
        {
            return stack.Count < stack.Type.StackSize;
        }

        protected IInventoryItemStack AddNewStack(IInventoryItem item, int amount = 0)
        {
            var stack = new DSInventoryItemStack(item, amount);
            Contents.Add(stack);
            return stack;
        }

        public void SetCapacityProvider([NotNull] IStorageCapacityProvider provider)
        {
            Capacity = provider;
        }
        
        public abstract void AddItem(IInventoryItem item, int amount = 1);

        public abstract void RemoveItem(IInventoryItem item, int amount = 1);

    }
}