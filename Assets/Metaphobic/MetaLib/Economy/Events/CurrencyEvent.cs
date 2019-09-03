using MetaLib.Events;

namespace MetaLib.Economy.Events
{
    public class CurrencyEvent : MetaEvent
    {
        protected CurrencyEvent(ICurrency currency)
        {
            Currency = currency;
        }

        public ICurrency Currency { get; }
    }
}