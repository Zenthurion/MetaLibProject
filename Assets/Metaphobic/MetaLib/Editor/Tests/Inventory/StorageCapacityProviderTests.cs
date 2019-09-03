using DwarvenSoftware.Framework.Inventory;
using NUnit.Framework;

namespace DwarvenSoftware.Framework.Editor.Tests.Inventory
{
    public class StorageCapacityProviderTests
    {
        [Test]
        public void StorageProvider_SimpleCapacity()
        {
            var provider = new DSSimpleStorageCapacityProvider(5);
            var inventory = new DSListInventory(provider);
            
            Assert.AreEqual(5, inventory.Capacity);
        }
        [Test]
        public void StorageProvider_SimpleCapacityChange()
        {
            var provider1 = new DSSimpleStorageCapacityProvider(5);
            var inventory = new DSListInventory(provider1);
            var provider2 = new DSSimpleStorageCapacityProvider(15);
            inventory.SetCapacityProvider(provider2);
            
            Assert.AreEqual(15, inventory.Capacity);
        }
        [Test]
        public void StorageProvider_CompositeCapacity()
        {
            var provider1 = new DSCompositeStorageCapacityProvider(new DSSimpleStorageCapacityProvider(5), new DSSimpleStorageCapacityProvider(5));
            var inventory = new DSListInventory(provider1);

            
            Assert.AreEqual(10, inventory.Capacity);
        }
    }
}