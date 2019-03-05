using System;
using Economy.Events;
using Events;
using JetBrains.Annotations;

namespace Economy
{
    public class DSCurrency : ICurrency
    {
        public DSCurrency([NotNull] string name, long value = 0)
        {
            Name = name;
            Value = value;
        }
        
        public string Name { get; private set; }

        public long Value { get; protected set; }

        public virtual bool TrySpend(long amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Attempting to spend negative amount of currency. Only positive values accepted!");
            }
            if (Value - amount < 0)
            {
                DSEvents.General.Raise(new CurrencyInsufficientEvent(this, amount - Value, amount));
                return false;
            }
            Value -= amount;
            DSEvents.General.Raise(new CurrencySpentEvent(this, amount));
            return true;
        }

        public virtual void Add(long amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Attempting to spend negative amount of currency. Only positive values accepted!");
            }
            DSEvents.General.Raise(new CurrencyAddedEvent(this, amount));
            Value += amount;
        }
    }
}