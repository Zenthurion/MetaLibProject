namespace DwarvenSoftware.Economy.Events
{
    public abstract class CappedCurrencyUpgradeEvent : CurrencyEvent
    {
        protected CappedCurrencyUpgradeEvent(ICappedCurrency currency) : base(currency)
        {
            CappedCurrency = currency;
        }

        public ICappedCurrency CappedCurrency { get; }
    }
}