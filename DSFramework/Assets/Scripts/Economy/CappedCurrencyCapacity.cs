using System.Collections.Generic;

namespace Economy
{
    public class CappedCurrencyCapacity
    {
        private readonly List<long> _capacities;

        public CappedCurrencyCapacity(List<long> capacities)
        {
            _capacities = capacities;
        }

        public CappedCurrencyCapacity(params long[] capacities) : this(new List<long>(capacities))
        {
        }

        public long this[int index] => GetCapacity(index);

        public int Count => _capacities.Count;
        
        public long GetCapacity(int index)
        {
            return _capacities[index];
        }
    }
}