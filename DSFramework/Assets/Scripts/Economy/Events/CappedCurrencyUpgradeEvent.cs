namespace Economy.Events
{
    public abstract class CappedCurrencyUpgradeEvent : CurrencyEvent
    {
        public ICappedCurrency CappedCurrency { get; private set; }
        
        protected CappedCurrencyUpgradeEvent(ICappedCurrency currency) : base(currency)
        {
            CappedCurrency = currency;
        }
    }
}