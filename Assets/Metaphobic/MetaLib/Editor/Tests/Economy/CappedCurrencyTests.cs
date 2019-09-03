using MetaLib.Economy;
using NUnit.Framework;

namespace MetaLib.Editor.Tests.Economy
{
    public class CappedCurrencyTests
    {
        [Test]
        public void CappedCurrency_AddValueCorrect()
        {
            var capacity = new CappedCurrencyCapacity(5, 10, 15);
            ICurrency currency = new MCappedCurrency("Ice", capacity);

            var valueToAdd = 2;

            currency.Add(valueToAdd);

            Assert.That(currency.Value == valueToAdd);
        }
        
        [Test]
        public void CappedCurrency_AddValueRestricted()
        {
            var capacity = new CappedCurrencyCapacity(5, 10, 15);
            ICappedCurrency currency = new MCappedCurrency("Ice", capacity);

            var valueToAdd = 7;

            currency.Add(valueToAdd);

            Assert.That(currency.Value == currency.Capacity);
        }
        
    }
}