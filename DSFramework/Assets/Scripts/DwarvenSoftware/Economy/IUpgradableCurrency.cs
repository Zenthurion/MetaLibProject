namespace DwarvenSoftware.Economy
{
    public interface IUpgradableCurrency : ICappedCurrency
    {
        int Level { get; }
        bool TryUpgradeCapacity();
    }
}