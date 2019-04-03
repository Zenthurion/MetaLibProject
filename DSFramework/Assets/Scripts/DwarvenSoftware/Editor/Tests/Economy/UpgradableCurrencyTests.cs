using System.Collections.Generic;
using DwarvenSoftware.Economy;
using NUnit.Framework;

namespace DwarvenSoftware.Editor.Tests.Economy
{
    public class UpgradableCurrencyTests
    {
        [Test]
        public void UpgradableCurrency_UpgradeSuccessful()
        {
            var capacity = new CappedCurrencyCapacity(5, 10, 15);
            IUpgradableCurrency currency = new DSCappedCurrency("Ice", capacity);

            Assert.IsTrue(currency.TryUpgradeCapacity());
        }
        
        [Test]
        public void UpgradableCurrency_UpgradeUnsuccessful()
        {
            var capacity = new CappedCurrencyCapacity(5, 10, 15);
            IUpgradableCurrency currency = new DSCappedCurrency("Ice", capacity);

            Assert.IsTrue(currency.TryUpgradeCapacity());
            Assert.IsTrue(currency.TryUpgradeCapacity());
            Assert.IsFalse(currency.TryUpgradeCapacity());
        }
        
        [Test]
        public void UpgradableCurrency_CapacityParamsAndListsAreEqual()
        {
            var capacityParams = new CappedCurrencyCapacity(5, 10, 15);
            IUpgradableCurrency currency1 = new DSCappedCurrency("Ice", capacityParams);

            var capacityList = new CappedCurrencyCapacity(new List<long> {5, 10, 15});
            IUpgradableCurrency currency2 = new DSCappedCurrency("Ice", capacityList);

            currency1.TryUpgradeCapacity();
            currency2.TryUpgradeCapacity();
            
            Assert.AreEqual(currency1.Capacity, currency2.Capacity);
        }
    }
}