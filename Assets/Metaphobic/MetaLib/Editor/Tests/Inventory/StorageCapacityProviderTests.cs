using MetaLib.Inventory;
using NUnit.Framework;

namespace MetaLib.Editor.Tests.Inventory
{
    public class StorageCapacityProviderTests
    {
        [Test]
        public void StorageProvider_SimpleCapacity()
        {
            var provider = new MSimpleStorageCapacityProvider(5);
            var inventory = new MListInventory(provider);
            
            Assert.AreEqual(5, inventory.Capacity);
        }
        [Test]
        public void StorageProvider_SimpleCapacityChange()
        {
            var provider1 = new MSimpleStorageCapacityProvider(5);
            var inventory = new MListInventory(provider1);
            var provider2 = new MSimpleStorageCapacityProvider(15);
            inventory.SetCapacityProvider(provider2);
            
            Assert.AreEqual(15, inventory.Capacity);
        }
        [Test]
        public void StorageProvider_CompositeCapacity()
        {
            var provider1 = new MCompositeStorageCapacityProvider(new MSimpleStorageCapacityProvider(5), new MSimpleStorageCapacityProvider(5));
            var inventory = new MListInventory(provider1);

            
            Assert.AreEqual(10, inventory.Capacity);
        }
    }
}