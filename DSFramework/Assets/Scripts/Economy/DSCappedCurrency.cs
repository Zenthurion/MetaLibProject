using Economy.Events;
using Events;
using JetBrains.Annotations;

namespace Economy
{
    public class DSCappedCurrency : DSCurrency, ICappedCurrency
    {
        private readonly CappedCurrencyCapacity _capacity;
        private int _level;

        public int Level => _level;

        public long Capacity => _capacity[_level];

        public DSCappedCurrency([NotNull] string name, CappedCurrencyCapacity capacity, long value = 0) : base(name, value)
        {
            _capacity = capacity;
            _level = 0;
        }

        public override void Add(long amount)
        {
            if (Value + amount > Capacity)
            {
                base.Add(Capacity - Value);
            }
            else
            {
                base.Add(amount);
            }
        }

        public bool TryUpgradeCapacity()
        {
            if (_level >= _capacity.Count - 1)
            {
                DSEvents.RaiseEvent(new CappedCurrencyUpgradeFailedEvent(this));
                return false;
            }
            _level++;
            DSEvents.RaiseEvent(new CappedCurrencyUpgradeSuccessEvent(this));
            return true;
        }
    }
}