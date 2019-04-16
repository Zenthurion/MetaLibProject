using System.Collections.Generic;
using JetBrains.Annotations;

namespace DwarvenSoftware.Framework.Inventory
{
    public interface IInventory
    {
        List<IInventoryItem> Contents { get; }
        IStorageCapacityProvider CapacityProvider { get; }
        int Capacity { get; }
        int Count { get; }
        TransactionResult AddItem(IInventoryItem item, int amount = 1);
        TransactionResult RemoveItem(IInventoryItem item, int amount = 1);
        void SetCapacityProvider([NotNull] IStorageCapacityProvider provider);
    }
}