using System.Collections.Generic;
using DwarvenSoftware.Economy;
using NUnit.Framework;

namespace DwarvenSoftware.Editor.Tests.Economy
{
    public class CappedCurrencyTests
    {
        [Test]
        public void CappedCurrency_AddValueCorrect()
        {
            var capacity = new CappedCurrencyCapacity(5, 10, 15);
            ICurrency currency = new DSCappedCurrency("Ice", capacity);

            var valueToAdd = 2;

            currency.Add(valueToAdd);

            Assert.That(currency.Value == valueToAdd);
        }
        
        [Test]
        public void CappedCurrency_AddValueRestricted()
        {
            var capacity = new CappedCurrencyCapacity(5, 10, 15);
            ICappedCurrency currency = new DSCappedCurrency("Ice", capacity);

            var valueToAdd = 7;

            currency.Add(valueToAdd);

            Assert.That(currency.Value == currency.Capacity);
        }
        
    }
}