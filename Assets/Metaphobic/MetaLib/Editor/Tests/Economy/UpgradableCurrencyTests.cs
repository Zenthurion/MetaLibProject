using System.Collections.Generic;
using MetaLib.Economy;
using NUnit.Framework;

namespace MetaLib.Editor.Tests.Economy
{
    public class UpgradableCurrencyTests
    {
        [Test]
        public void UpgradableCurrency_UpgradeSuccessful()
        {
            var capacity = new CappedCurrencyCapacity(5, 10, 15);
            IUpgradableCurrency currency = new MCappedCurrency("Ice", capacity);

            Assert.IsTrue(currency.TryUpgradeCapacity());
        }
        
        [Test]
        public void UpgradableCurrency_UpgradeUnsuccessful()
        {
            var capacity = new CappedCurrencyCapacity(5, 10, 15);
            IUpgradableCurrency currency = new MCappedCurrency("Ice", capacity);

            Assert.IsTrue(currency.TryUpgradeCapacity());
            Assert.IsTrue(currency.TryUpgradeCapacity());
            Assert.IsFalse(currency.TryUpgradeCapacity());
        }
        
        [Test]
        public void UpgradableCurrency_CapacityParamsAndListsAreEqual()
        {
            var capacityParams = new CappedCurrencyCapacity(5, 10, 15);
            IUpgradableCurrency currency1 = new MCappedCurrency("Ice", capacityParams);

            var capacityList = new CappedCurrencyCapacity(new List<long> {5, 10, 15});
            IUpgradableCurrency currency2 = new MCappedCurrency("Ice", capacityList);

            currency1.TryUpgradeCapacity();
            currency2.TryUpgradeCapacity();
            
            Assert.AreEqual(currency1.Capacity, currency2.Capacity);
        }
    }
}