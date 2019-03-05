namespace Economy
{
    public interface ICappedCurrency : ICurrency
    {
        long Capacity { get; }
        bool TryUpgradeCapacity();
    }
}