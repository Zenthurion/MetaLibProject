namespace DwarvenSoftware.Framework.Economy.Events
{
    public class CurrencySpentEvent : CurrencyChangedEvent
    {
        public CurrencySpentEvent(ICurrency currency, long amount) : base(currency, amount)
        {
        }
    }
}