namespace DwarvenSoftware.Framework.Economy
{
    public interface IUpgradableCurrency : ICappedCurrency
    {
        int Level { get; }
        bool TryUpgradeCapacity();
    }
}