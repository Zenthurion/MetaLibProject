using System;
using System.Collections.Generic;

namespace DwarvenSoftware.Inventory
{
    public class DSInventory
    {
        private List<IInventoryItemStack> _contents;

        private int _capacity;
        
        public DSInventory(int capacity = -1)
        {
            _contents = new List<IInventoryItemStack>();
        }

        public void AddItem(IInventoryItem item)
        {
            
        }

        public void RemoveItem(IInventoryItem item)
        {
            
        }
        
    }
}