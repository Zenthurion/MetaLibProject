using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace DwarvenSoftware.Framework.Economy
{
    public class CompositeCurrency : DSCurrency, ICompositeCurrency
    {
        private readonly HashSet<ICurrencyCapacityProvider> _providers;

        public CompositeCurrency([NotNull] string name, long value = 0) : base(name, value)
        {
            _providers = new HashSet<ICurrencyCapacityProvider>();
        }

        public long Capacity => _providers.Sum(provider => provider.CurrencyCapacity);

        public void AddProviders(params ICurrencyCapacityProvider[] providers)
        {
            foreach (var p in providers)
            {
                if (_providers.Contains(p)) return;
                _providers.Add(p);
            }
        }

        public void RemoveProviders(params ICurrencyCapacityProvider[] providers)
        {
            foreach (var p in providers)
            {
                if (!_providers.Contains(p)) return;
                _providers.Remove(p);
            }
        }
    }
}