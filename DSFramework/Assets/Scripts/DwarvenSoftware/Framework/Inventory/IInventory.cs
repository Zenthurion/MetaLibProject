using System.Collections.Generic;
using JetBrains.Annotations;

namespace DwarvenSoftware.Framework.Inventory
{
    public interface IInventory
    {
        List<IInventoryItemStack> Contents { get; }
        IStorageCapacityProvider Capacity { get; }
        int CurrentCapacity { get; }
        int StackCount { get; }
        void AddItem(IInventoryItem item, int amount = 1);
        void RemoveItem(IInventoryItem item, int amount = 1);
        void SetCapacityProvider([NotNull] IStorageCapacityProvider provider);
    }
}