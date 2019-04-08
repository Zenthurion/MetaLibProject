namespace DwarvenSoftware.Framework.Economy.Events
{
    public abstract class UpgradableCurrencyUpgradeEvent : CurrencyEvent
    {
        protected UpgradableCurrencyUpgradeEvent(ICappedCurrency currency) : base(currency)
        {
            CappedCurrency = currency;
        }

        public ICappedCurrency CappedCurrency { get; }
    }
}