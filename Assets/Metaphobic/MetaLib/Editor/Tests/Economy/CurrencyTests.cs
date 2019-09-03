using System;
using System.Collections.Generic;
using MetaLib.Economy;
using MetaLib.Utils;
using NUnit.Framework;

namespace MetaLib.Editor.Tests.Economy
{
    public class CurrencyTests
    {
        [Test]
        public void Currency_AddValueCorrect()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);

            currency.Add(1000);

            Assert.That(currency.Value == 1000);
        }

        [Test]
        public void Economy_AddCurrency()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);
            MEconomy.Instance.AddCurrency(currency);

            Assert.That(MEconomy.Instance[name].Name.Equals(name));
        }

        [Test]
        public void Currency_TrySpendReturnsFalse()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);

            Assert.That(currency.TrySpend(1000) == false);
        }

        [Test]
        public void Currency_TrySpendResultsInZero()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);

            currency.TrySpend(1000);

            Assert.That(currency.Value == 0);
        }

        [Test]
        public void Currency_AddNegative()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);

            Assert.Throws<ArgumentException>(() => currency.Add(-1000));
            Assert.That(currency.Value == 0);
        }

        [Test]
        public void Currency_TrySpendNegative()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);
            currency.Add(2000);

            Assert.Throws<ArgumentException>(() => currency.TrySpend(-1000));
            Assert.That(currency.Value == 2000);
        }

        [Test]
        public void Economy_RemoveCurrency()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);
            MEconomy.Instance.AddCurrency(currency);

            MEconomy.Instance.RemoveCurrency(currency);

            Assert.Throws<KeyNotFoundException>(() =>
            {
                var curr = MEconomy.Instance[name];
            });
        }

        [Test]
        public void Economy_RemoveCurrencyNotExisting()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);

            Assert.Throws<InvalidOperationException>(() => MEconomy.Instance.RemoveCurrency(currency));
        }

        [Test]
        public void Economy_AddCurrencyAlreadyExisting()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);
            MEconomy.Instance.AddCurrency(currency);
            Assert.Throws<InvalidOperationException>(() => MEconomy.Instance.AddCurrency(currency));
        }

        [Test]
        public void Economy_AddCurrencyAlreadyExistingNonIdentical()
        {
            var name = MUtils.GetRandomString();
            ICurrency currency = new MCurrency(name);
            ICurrency currency2 = new MCurrency(name);
            MEconomy.Instance.AddCurrency(currency);
            Assert.Throws<InvalidOperationException>(() => MEconomy.Instance.AddCurrency(currency2));
        }
    }
}