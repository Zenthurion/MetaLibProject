using DwarvenSoftware.Economy.Events;
using DwarvenSoftware.Events;
using JetBrains.Annotations;

namespace DwarvenSoftware.Economy
{
    public class DSCappedCurrency : DSCurrency, IUpgradableCurrency
    {
        private readonly CappedCurrencyCapacity _capacity;

        public DSCappedCurrency([NotNull] string name, CappedCurrencyCapacity capacity, long value = 0) : base(name,
            value)
        {
            _capacity = capacity;
            Level = 0;
        }

        public int Level { get; private set; }

        public long Capacity => _capacity[Level];

        public override void Add(long amount)
        {
            if (Value + amount > Capacity)
                base.Add(Capacity - Value);
            else
                base.Add(amount);
        }

        public bool TryUpgradeCapacity()
        {
            if (Level >= _capacity.Count - 1)
            {
                DSEvents.RaiseEvent(new UpgradableCurrencyUpgradeFailedEvent(this));
                return false;
            }

            Level++;
            DSEvents.RaiseEvent(new UpgradableCurrencyUpgradeSuccessEvent(this));
            return true;
        }
    }
}