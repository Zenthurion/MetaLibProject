namespace Economy.Events
{
    public abstract class CurrencyChangedEvent : CurrencyEvent
    {
        public long Amount { get; private set; }

        protected CurrencyChangedEvent(ICurrency currency, long amount) : base(currency)
        {
            Amount = amount;
        }
    }
}