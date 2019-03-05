using System;
using System.Collections.Generic;

namespace Economy
{
    public class DSEconomy
    {
        private static DSEconomy _instance;

        public static DSEconomy Instance => _instance ?? (_instance = new DSEconomy());

        
        private readonly Dictionary<string, ICurrency> _currencies;

        public ICurrency this[string currencyKey] => _currencies[currencyKey];

        
        private DSEconomy()
        {
            _currencies = new Dictionary<string, ICurrency>();
        }

        public void AddCurrency(ICurrency currency)
        {
            if (_currencies.ContainsKey(currency.Name))
            {
                throw new InvalidOperationException($"Currency [{currency.Name}] already exists in DSEconomy");
            }
            _currencies.Add(currency.Name, currency);
        }

        public void RemoveCurrency(ICurrency currency)
        {
            if (!_currencies.ContainsKey(currency.Name))
            {
                throw new InvalidOperationException($"Currency [{currency.Name}] does not exist in DSEconomy");
            }
            _currencies.Remove(currency.Name);
        }
    }
}