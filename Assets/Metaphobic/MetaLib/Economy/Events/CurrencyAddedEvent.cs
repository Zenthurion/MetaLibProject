namespace MetaLib.Economy.Events
{
    public class CurrencyAddedEvent : CurrencyChangedEvent
    {
        public CurrencyAddedEvent(ICurrency currency, long amount) : base(currency, amount)
        {
        }
    }
}