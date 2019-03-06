namespace DwarvenSoftware.Economy.Events
{
    public class CappedCurrencyUpgradeFailedEvent : CappedCurrencyUpgradeEvent
    {
        public CappedCurrencyUpgradeFailedEvent(ICappedCurrency currency) : base(currency)
        {
        }
    }
}