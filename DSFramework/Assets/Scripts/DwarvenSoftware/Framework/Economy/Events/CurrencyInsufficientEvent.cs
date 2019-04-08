namespace DwarvenSoftware.Framework.Economy.Events
{
    public class CurrencyInsufficientEvent : CurrencyEvent
    {
        public CurrencyInsufficientEvent(ICurrency currency, long missingCurrency, long amountAttempted) :
            base(currency)
        {
            MissingCurrency = missingCurrency;
            AmountAttempted = amountAttempted;
        }

        public long MissingCurrency { get; }
        public long AmountAttempted { get; }
    }
}