namespace DwarvenSoftware.Economy.Events
{
    public class UpgradableCurrencyUpgradeSuccessEvent : UpgradableCurrencyUpgradeEvent
    {
        public UpgradableCurrencyUpgradeSuccessEvent(ICappedCurrency currency) : base(currency)
        {
        }
    }
}