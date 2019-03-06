using DwarvenSoftware.Events;

namespace DwarvenSoftware.Economy.Events
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