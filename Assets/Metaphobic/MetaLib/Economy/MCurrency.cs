using System;
using JetBrains.Annotations;
using MetaLib.Economy.Events;
using MetaLib.Events;

namespace MetaLib.Economy
{
    public class MCurrency : ICurrency
    {
        public MCurrency([NotNull] string name, long value = 0)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public long Value { get; protected set; }

        public virtual bool TrySpend(long amount)
        {
            if (amount < 0)
                throw new ArgumentException(
                    "Attempting to spend negative amount of currency. Only positive values accepted!");
            if (Value - amount < 0)
            {
                MEvents.General.Raise(new CurrencyInsufficientEvent(this, amount - Value, amount));
                return false;
            }

            Value -= amount;
            MEvents.General.Raise(new CurrencySpentEvent(this, amount));
            return true;
        }

        public virtual void Add(long amount)
        {
            if (amount < 0)
                throw new ArgumentException(
                    "Attempting to spend negative amount of currency. Only positive values accepted!");
            MEvents.General.Raise(new CurrencyAddedEvent(this, amount));
            Value += amount;
        }
    }
}