using DwarvenSoftware.Inventory;
using NSubstitute;
using NUnit.Framework;

namespace DwarvenSoftware.Editor.Tests.Inventory
{
    public class UniqueInventoryTests
    {
        [Test]
        public void UniqueInventory_EmptyNoCapacity()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(0);
            IInventory inventory = new DSUniqueInventory(provider);
            
            Assert.Zero(inventory.CurrentCapacity);
            Assert.Zero(inventory.StackCount);
        }
        
        [Test]
        public void UniqueInventory_AddingNoCapacity()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(0);
            IInventory inventory = new DSUniqueInventory(provider);

            var item = Substitute.For<IInventoryItem>();
            item.StackSize.Returns(1);
            
            inventory.AddItem(item);
            
            Assert.Zero(inventory.StackCount);
        }
        
        [Test]
        public void UniqueInventory_AddingWithCapacity()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSUniqueInventory(provider);

            var item = Substitute.For<IInventoryItem>();
            item.StackSize.Returns(1);
            
            inventory.AddItem(item);
            
            Assert.AreEqual(1,inventory.StackCount);
        }
        
        [Test]
        public void UniqueInventory_AddingSame()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSUniqueInventory(provider);

            var item = Substitute.For<IInventoryItem>();
            item.StackSize.Returns(1);
            
            inventory.AddItem(item);
            inventory.AddItem(item);
            
            Assert.AreEqual(1,inventory.StackCount);
        }
        
        [Test]
        public void UniqueInventory_AddingDifferent()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSUniqueInventory(provider);

            var item1 = Substitute.For<IInventoryItem>();
            item1.StackSize.Returns(1);
            
            var item2 = Substitute.For<IInventoryItem>();
            item2.StackSize.Returns(1);
            
            inventory.AddItem(item1);
            inventory.AddItem(item2);
            
            Assert.AreEqual(2,inventory.StackCount);
        }
        
        [Test]
        public void UniqueInventory_RemovingItem()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSUniqueInventory(provider);

            var item1 = Substitute.For<IInventoryItem>();
            item1.StackSize.Returns(1);
            
            var item2 = Substitute.For<IInventoryItem>();
            item2.StackSize.Returns(1);
            
            inventory.AddItem(item1);
            inventory.AddItem(item2);
            
            inventory.RemoveItem(item1);
            
            Assert.AreEqual(1,inventory.StackCount);
        }
        
        [Test]
        public void UniqueInventory_AddingToExistingStack()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSUniqueInventory(provider);

            var item1 = Substitute.For<IInventoryItem>();
            item1.StackSize.Returns(4);
            
            inventory.AddItem(item1);
            inventory.AddItem(item1, 2);
            
            Assert.AreEqual(1,inventory.StackCount);
            Assert.AreEqual(3, inventory.Contents[0].Count);
        }
        
        [Test]
        public void UniqueInventory_AddingToExistingStackOverflow()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSUniqueInventory(provider);

            var item1 = Substitute.For<IInventoryItem>();
            item1.StackSize.Returns(4);
            
            inventory.AddItem(item1);
            inventory.AddItem(item1, 5);
            
            Assert.AreEqual(1,inventory.StackCount);
            Assert.AreEqual(4, inventory.Contents[0].Count);
        }
    }
}