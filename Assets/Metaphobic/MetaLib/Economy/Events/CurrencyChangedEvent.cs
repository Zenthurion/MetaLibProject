namespace MetaLib.Economy.Events
{
    public abstract class CurrencyChangedEvent : CurrencyEvent
    {
        protected CurrencyChangedEvent(ICurrency currency, long amount) : base(currency)
        {
            Amount = amount;
        }

        public long Amount { get; }
    }
}