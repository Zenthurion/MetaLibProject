namespace DwarvenSoftware.Economy
{
    public interface ICompositeCurrency : ICappedCurrency
    {
        void AddProviders(params ICurrencyCapacityProvider[] provider);
        void RemoveProviders(params ICurrencyCapacityProvider[] provider);
    }
}