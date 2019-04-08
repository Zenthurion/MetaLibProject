namespace DwarvenSoftware.Framework.Economy.Events
{
    public class UpgradableCurrencyUpgradeFailedEvent : UpgradableCurrencyUpgradeEvent
    {
        public UpgradableCurrencyUpgradeFailedEvent(ICappedCurrency currency) : base(currency)
        {
        }
    }
}