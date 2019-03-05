using System.Collections.Generic;
using Economy;
using NUnit.Framework;

namespace Editor.Tests.Economy
{
    public class RestrictiveCurrencyTests
    {
        [Test]
        public void RestrictiveCurrency_AddValueCorrect()
        {
            var capacity = new CappedCurrencyCapacity(5, 10, 15);
            ICurrency currency = new DSCappedCurrency("Ice", capacity);

            var valueToAdd = 2;

            currency.Add(valueToAdd);

            Assert.That(currency.Value == valueToAdd);
        }
        
        [Test]
        public void RestrictiveCurrency_AddValueRestricted()
        {
            var capacity = new CappedCurrencyCapacity(5, 10, 15);
            ICappedCurrency currency = new DSCappedCurrency("Ice", capacity);

            var valueToAdd = 7;

            currency.Add(valueToAdd);

            Assert.That(currency.Value == currency.Capacity);
        }
        
        [Test]
        public void RestrictiveCurrency_UpgradeSuccessful()
        {
            var capacity = new CappedCurrencyCapacity(5, 10, 15);
            ICappedCurrency currency = new DSCappedCurrency("Ice", capacity);

            Assert.IsTrue(currency.TryUpgradeCapacity());
        }
        
        [Test]
        public void RestrictiveCurrency_UpgradeUnsuccessful()
        {
            var capacity = new CappedCurrencyCapacity(5, 10, 15);
            ICappedCurrency currency = new DSCappedCurrency("Ice", capacity);

            Assert.IsTrue(currency.TryUpgradeCapacity());
            Assert.IsTrue(currency.TryUpgradeCapacity());
            Assert.IsFalse(currency.TryUpgradeCapacity());
        }
        
        [Test]
        public void RestrictiveCurrency_CapacityParamsAndListsAreEqual()
        {
            var capacityParams = new CappedCurrencyCapacity(5, 10, 15);
            ICappedCurrency currency1 = new DSCappedCurrency("Ice", capacityParams);

            var capacityList = new CappedCurrencyCapacity(new List<long> {5, 10, 15});
            ICappedCurrency currency2 = new DSCappedCurrency("Ice", capacityList);

            currency1.TryUpgradeCapacity();
            currency2.TryUpgradeCapacity();
            
            Assert.AreEqual(currency1.Capacity, currency2.Capacity);
        }
    }
}