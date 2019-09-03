using System;
using System.Collections.Generic;
using DwarvenSoftware.Framework.Economy;
using DwarvenSoftware.Framework.Utils;
using NUnit.Framework;

namespace DwarvenSoftware.Framework.Editor.Tests.Economy
{
    public class CurrencyTests
    {
        [Test]
        public void Currency_AddValueCorrect()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);

            currency.Add(1000);

            Assert.That(currency.Value == 1000);
        }

        [Test]
        public void Economy_AddCurrency()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);
            DSEconomy.Instance.AddCurrency(currency);

            Assert.That(DSEconomy.Instance[name].Name.Equals(name));
        }

        [Test]
        public void Currency_TrySpendReturnsFalse()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);

            Assert.That(currency.TrySpend(1000) == false);
        }

        [Test]
        public void Currency_TrySpendResultsInZero()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);

            currency.TrySpend(1000);

            Assert.That(currency.Value == 0);
        }

        [Test]
        public void Currency_AddNegative()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);

            Assert.Throws<ArgumentException>(() => currency.Add(-1000));
            Assert.That(currency.Value == 0);
        }

        [Test]
        public void Currency_TrySpendNegative()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);
            currency.Add(2000);

            Assert.Throws<ArgumentException>(() => currency.TrySpend(-1000));
            Assert.That(currency.Value == 2000);
        }

        [Test]
        public void Economy_RemoveCurrency()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);
            DSEconomy.Instance.AddCurrency(currency);

            DSEconomy.Instance.RemoveCurrency(currency);

            Assert.Throws<KeyNotFoundException>(() =>
            {
                var curr = DSEconomy.Instance[name];
            });
        }

        [Test]
        public void Economy_RemoveCurrencyNotExisting()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);

            Assert.Throws<InvalidOperationException>(() => DSEconomy.Instance.RemoveCurrency(currency));
        }

        [Test]
        public void Economy_AddCurrencyAlreadyExisting()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);
            DSEconomy.Instance.AddCurrency(currency);
            Assert.Throws<InvalidOperationException>(() => DSEconomy.Instance.AddCurrency(currency));
        }

        [Test]
        public void Economy_AddCurrencyAlreadyExistingNonIdentical()
        {
            var name = DSUtils.GetRandomString();
            ICurrency currency = new DSCurrency(name);
            ICurrency currency2 = new DSCurrency(name);
            DSEconomy.Instance.AddCurrency(currency);
            Assert.Throws<InvalidOperationException>(() => DSEconomy.Instance.AddCurrency(currency2));
        }
    }
}