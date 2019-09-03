using DwarvenSoftware.Framework.Inventory;
using NSubstitute;
using NUnit.Framework;

namespace DwarvenSoftware.Framework.Editor.Tests.Inventory
{
    public class ListInventoryTests
    {
        [Test]
        public void ListInventory_EmptyNoCapacity()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(0);
            IInventory inventory = new DSListInventory(provider);
            
            Assert.Zero(inventory.Capacity);
            Assert.Zero(inventory.Count);
        }
        
        [Test]
        public void ListInventory_AddingItemNoCapacity()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(0);
            IInventory inventory = new DSListInventory(provider);

            var item = Substitute.For<IInventoryItem>();
            
            inventory.AddItem(item);
            
            Assert.Zero(inventory.Count);
        }
        
        [Test]
        public void ListInventory_AddingStackNoCapacity()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(0);
            IInventory inventory = new DSListInventory(provider);

            var item = Substitute.For<IInventoryStack>();
            item.Capacity.Returns(2);
            
            inventory.AddItem(item);
            
            Assert.Zero(inventory.Count);
        }
        
        [Test]
        public void ListInventory_AddingItemWithCapacity()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSListInventory(provider);

            var item = Substitute.For<IInventoryItem>();
            
            inventory.AddItem(item);
            
            Assert.AreEqual(1,inventory.Count);
        }
        
        [Test]
        public void ListInventory_AddingStackWithCapacity()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSListInventory(provider);

            var item = Substitute.For<IInventoryStack>();
            item.Capacity.Returns(2);
            
            inventory.AddItem(item);
            
            Assert.AreEqual(1,inventory.Count);
            Assert.AreEqual(1, (inventory.Contents[0] as IInventoryStack)?.Count);
        }
        
        [Test]
        public void ListInventory_AddingSame()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSListInventory(provider);

            var item = Substitute.For<IInventoryItem>();
            
            inventory.AddItem(item);
            inventory.AddItem(item);
            
            Assert.AreEqual(2,inventory.Count);
        }
        
        [Test]
        public void ListInventory_AddingDifferent()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSListInventory(provider);

            var item1 = Substitute.For<IInventoryItem>();
            
            var item2 = Substitute.For<IInventoryItem>();
            
            inventory.AddItem(item1);
            inventory.AddItem(item2);
            
            Assert.AreEqual(2,inventory.Count);
        }
        
        [Test]
        public void ListInventory_RemovingItem()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSListInventory(provider);

            var item1 = Substitute.For<IInventoryItem>();
            
            var item2 = Substitute.For<IInventoryItem>();
            
            inventory.AddItem(item1);
            inventory.AddItem(item2);
            
            inventory.RemoveItem(item1);
            
            Assert.AreEqual(1,inventory.Count);
        }
        
        [Test]
        public void ListInventory_RemovingTooMuchItem()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSUniqueInventory(provider);

            var item1 = Substitute.For<IInventoryItem>();
            
            var item2 = Substitute.For<IInventoryItem>();
            
            inventory.AddItem(item1);
            inventory.AddItem(item2);
            
            var res = inventory.RemoveItem(item1, 5);
            
            Assert.AreEqual(4, res.Remainder);
        }
        
        [Test]
        public void ListInventory_RemovingTooMuchStack()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSUniqueInventory(provider);

            var item1 = Substitute.For<IInventoryStack>();
            item1.Capacity.Returns(1);
            
            var item2 = Substitute.For<IInventoryStack>();
            item2.Capacity.Returns(1);
            
            inventory.AddItem(item1);
            inventory.AddItem(item2);
            
            var res = inventory.RemoveItem(item1, 5);
            
            Assert.AreEqual(4, res.Remainder);
        }
        
        [Test]
        public void ListInventory_AddingToExistingStack()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSListInventory(provider);

            var item1 = Substitute.For<IInventoryStack>();
            item1.Capacity.Returns(4);
            
            inventory.AddItem(item1);
            inventory.AddItem(item1, 2);
            
            Assert.AreEqual(1,inventory.Count);
            Assert.AreEqual(3, (inventory.Contents[0] as IInventoryStack)?.Count);
        }
        
        [Test]
        public void ListInventory_AddingToExistingStackOverflow()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new DSListInventory(provider);

            var item1 = Substitute.For<IInventoryStack>();
            item1.Capacity.Returns(4);
            
            inventory.AddItem(item1);
            inventory.AddItem(item1, 5);
            
            Assert.AreEqual(2,inventory.Count);
            Assert.AreEqual(4, (inventory.Contents[0] as IInventoryStack)?.Count);
            Assert.AreEqual(2, (inventory.Contents[1] as IInventoryStack)?.Count);
        }
        
        [Test]
        public void ListInventory_AddingToExistingStackOverflowAtCapacity()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(2);
            IInventory inventory = new DSListInventory(provider);

            var item1 = Substitute.For<IInventoryStack>();
            item1.Capacity.Returns(4);
            
            inventory.AddItem(item1);
            inventory.AddItem(item1, 5);
            var res = inventory.AddItem(item1, 5);
            
            Assert.AreEqual(2,inventory.Count);
            Assert.AreEqual(4, (inventory.Contents[0] as IInventoryStack)?.Count);
            Assert.AreEqual(4, (inventory.Contents[1] as IInventoryStack)?.Count);
            Assert.AreEqual(3, res.Remainder);
        }
    }
}