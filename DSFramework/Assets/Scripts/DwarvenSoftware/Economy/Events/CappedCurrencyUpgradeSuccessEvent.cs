namespace DwarvenSoftware.Economy.Events
{
    public class CappedCurrencyUpgradeSuccessEvent : CappedCurrencyUpgradeEvent
    {
        public CappedCurrencyUpgradeSuccessEvent(ICappedCurrency currency) : base(currency)
        {
        }
    }
}