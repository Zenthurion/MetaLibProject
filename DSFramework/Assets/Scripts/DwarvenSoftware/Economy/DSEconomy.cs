using System;
using System.Collections.Generic;

namespace DwarvenSoftware.Economy
{
    public class DSEconomy
    {
        private static DSEconomy _instance;


        private readonly Dictionary<string, ICurrency> _currencies;


        private DSEconomy()
        {
            _currencies = new Dictionary<string, ICurrency>();
        }

        public static DSEconomy Instance => _instance ?? (_instance = new DSEconomy());

        public ICurrency this[string currencyKey] => _currencies[currencyKey];

        public void AddCurrency(ICurrency currency)
        {
            if (_currencies.ContainsKey(currency.Name))
                throw new InvalidOperationException($"Currency [{currency.Name}] already exists in DSEconomy");
            _currencies.Add(currency.Name, currency);
        }

        public void RemoveCurrency(ICurrency currency)
        {
            if (!_currencies.ContainsKey(currency.Name))
                throw new InvalidOperationException($"Currency [{currency.Name}] does not exist in DSEconomy");
            _currencies.Remove(currency.Name);
        }
    }
}