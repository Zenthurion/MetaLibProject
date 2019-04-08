using DwarvenSoftware.Framework.Events;

namespace DwarvenSoftware.Framework.Economy.Events
{
    public class CurrencyEvent : GameEvent
    {
        protected CurrencyEvent(ICurrency currency)
        {
            Currency = currency;
        }

        public ICurrency Currency { get; }
    }
}