using Events;

namespace Economy.Events
{
    public class CurrencyEvent : GameEvent
    {
        public ICurrency Currency { get; private set; }

        protected CurrencyEvent(ICurrency currency)
        {
            Currency = currency;
        }
    }
}