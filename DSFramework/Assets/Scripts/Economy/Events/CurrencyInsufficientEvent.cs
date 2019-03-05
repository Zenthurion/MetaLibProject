namespace Economy.Events
{
    public class CurrencyInsufficientEvent : CurrencyEvent
    {
        public long MissingCurrency { get; private set; }
        public long AmountAttempted { get; private set; }
        
        public CurrencyInsufficientEvent(ICurrency currency, long missingCurrency, long amountAttempted) : base(currency)
        {
            MissingCurrency = missingCurrency;
            AmountAttempted = amountAttempted;
        }
    }
}