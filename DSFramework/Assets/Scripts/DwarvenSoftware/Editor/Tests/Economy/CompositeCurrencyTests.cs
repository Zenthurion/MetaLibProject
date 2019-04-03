using DwarvenSoftware.Economy;
using NSubstitute;
using NUnit.Framework;


namespace DwarvenSoftware.Editor.Tests.Economy
{
    public class CompositeCurrencyTests
    {
        [Test]
        public void CompositeCurrency_NoProviders()
        {
            ICompositeCurrency currency = new CompositeCurrency("Glue");
            Assert.Zero(currency.Capacity);
            Assert.Zero(currency.Value);
        }
        
        [Test]
        public void CompositeCurrency_SingleProvider()
        {
            ICompositeCurrency currency = new CompositeCurrency("Glue");

            var provider = Substitute.For<ICurrencyCapacityProvider>();
            provider.CurrencyCapacity.Returns(5);
            
            currency.AddProviders(provider);
            
            Assert.AreEqual(5, currency.Capacity);
        }
        
        [Test]
        public void CompositeCurrency_MultipleProviders()
        {
            ICompositeCurrency currency = new CompositeCurrency("Glue");

            var provider1 = Substitute.For<ICurrencyCapacityProvider>();
            provider1.CurrencyCapacity.Returns(5);
            
            var provider2 = Substitute.For<ICurrencyCapacityProvider>();
            provider2.CurrencyCapacity.Returns(10);
            
            var provider3 = Substitute.For<ICurrencyCapacityProvider>();
            provider3.CurrencyCapacity.Returns(15);
            
            currency.AddProviders(provider1, provider2, provider3);
            
            Assert.AreEqual(30, currency.Capacity);
        }
        
        [Test]
        public void CompositeCurrency_AddProvider()
        {
            ICompositeCurrency currency = new CompositeCurrency("Glue");

            var provider1 = Substitute.For<ICurrencyCapacityProvider>();
            provider1.CurrencyCapacity.Returns(5);
            
            currency.AddProviders(provider1);
            
            Assert.AreEqual(5, currency.Capacity);
            
            var provider2 = Substitute.For<ICurrencyCapacityProvider>();
            provider2.CurrencyCapacity.Returns(10);
            
            currency.AddProviders(provider2);
            
            Assert.AreEqual(15, currency.Capacity);
        }
        
        [Test]
        public void CompositeCurrency_RemoveProvider()
        {
            ICompositeCurrency currency = new CompositeCurrency("Glue");

            var provider1 = Substitute.For<ICurrencyCapacityProvider>();
            provider1.CurrencyCapacity.Returns(5);
            var provider2 = Substitute.For<ICurrencyCapacityProvider>();
            provider2.CurrencyCapacity.Returns(10);
            
            currency.AddProviders(provider1);
            currency.AddProviders(provider2);
            
            Assert.AreEqual(15, currency.Capacity);
            
            currency.RemoveProviders(provider2);
            
            Assert.AreEqual(5, currency.Capacity);
        }
    }
}