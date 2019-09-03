using MetaLib.Inventory;
using NSubstitute;
using NUnit.Framework;

namespace MetaLib.Editor.Tests.Inventory
{
    public class UniqueInventoryTests
    {
        [Test]
        public void UniqueInventory_EmptyNoCapacity()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(0);
            IInventory inventory = new MUniqueInventory(provider);
            
            Assert.Zero(inventory.Capacity);
            Assert.Zero(inventory.Count);
        }
        
        [Test]
        public void UniqueInventory_AddingNoCapacity()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(0);
            IInventory inventory = new MUniqueInventory(provider);

            var item = Substitute.For<IInventoryItem>();
            item.Id.Returns(1);
            
            inventory.AddItem(item);
            
            Assert.Zero(inventory.Count);
        }
        
        [Test]
        public void UniqueInventory_AddingWithCapacity()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new MUniqueInventory(provider);

            var item = Substitute.For<IInventoryItem>();
            item.Id.Returns(1);
            
            inventory.AddItem(item);
            
            Assert.AreEqual(1,inventory.Count);
        }
        
        [Test]
        public void UniqueInventory_AddingSame()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new MUniqueInventory(provider);

            var item = Substitute.For<IInventoryItem>();
            item.Id.Returns(1);
            
            inventory.AddItem(item);
            inventory.AddItem(item);
            
            Assert.AreEqual(1,inventory.Count);
        }
        
        [Test]
        public void UniqueInventory_AddingDifferent()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new MUniqueInventory(provider);

            var item1 = Substitute.For<IInventoryItem>();
            item1.Id.Returns(1);
            
            var item2 = Substitute.For<IInventoryStack>();
            item2.Capacity.Returns(1);
            item2.Id.Returns(2);
            
            inventory.AddItem(item1);
            inventory.AddItem(item2);
            
            Assert.AreEqual(2,inventory.Count);
        }
        
        [Test]
        public void UniqueInventory_RemovingItem()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new MUniqueInventory(provider);

            var item1 = Substitute.For<IInventoryItem>();
            item1.Id.Returns(1);
            
            var item2 = Substitute.For<IInventoryItem>();
            item2.Id.Returns(2);
            
            inventory.AddItem(item1);
            inventory.AddItem(item2);
            
            inventory.RemoveItem(item1);
            
            Assert.AreEqual(1,inventory.Count);
        }
        
        [Test]
        public void UniqueInventory_RemovingTooMuchItem()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new MUniqueInventory(provider);

            var item1 = Substitute.For<IInventoryItem>();
            item1.Id.Returns(1);
            
            var item2 = Substitute.For<IInventoryItem>();
            item2.Id.Returns(2);
            
            inventory.AddItem(item1);
            inventory.AddItem(item2);
            
            var res = inventory.RemoveItem(item1, 5);
            
            Assert.AreEqual(4, res.Remainder);
        }
        
        [Test]
        public void UniqueInventory_RemovingTooMuchStack()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new MUniqueInventory(provider);

            var item1 = Substitute.For<IInventoryStack>();
            item1.Capacity.Returns(1);
            item1.Id.Returns(1);
            
            var item2 = Substitute.For<IInventoryStack>();
            item2.Capacity.Returns(1);
            item2.Id.Returns(2);
            
            inventory.AddItem(item1);
            inventory.AddItem(item2);
            
            Assert.AreEqual(1, (inventory.Contents[0] as IInventoryStack)?.Count);
            
            var res = inventory.RemoveItem(item1, 5);
            
            Assert.AreEqual(4, res.Remainder);
        }
        
        [Test]
        public void UniqueInventory_AddingToExistingStack()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new MUniqueInventory(provider);

            var item1 = Substitute.For<IInventoryStack>();
            item1.Capacity.Returns(4);
            item1.Id.Returns(1);
            
            inventory.AddItem(item1);
            inventory.AddItem(item1, 2);
            
            Assert.AreEqual(1,inventory.Count);
            Assert.AreEqual(3, (inventory.Contents[0] as IInventoryStack)?.Count);
        }
        
        [Test]
        public void UniqueInventory_AddingToExistingStackOverflow()
        {
            var provider = Substitute.For<IStorageCapacityProvider>();
            provider.Capacity.Returns(10);
            IInventory inventory = new MUniqueInventory(provider);

            var item1 = Substitute.For<IInventoryStack>();
            item1.Capacity.Returns(4);
            item1.Id.Returns(1);
            
            inventory.AddItem(item1);
            var res = inventory.AddItem(item1, 5);
            
            Assert.AreEqual(1,inventory.Count);
            Assert.AreEqual(4, (inventory.Contents[0] as IInventoryStack)?.Count);
            Assert.AreEqual(2, res.Remainder);
        }
    }
}