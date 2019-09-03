namespace MetaLib.Economy
{
    public interface IUpgradableCurrency : ICappedCurrency
    {
        int Level { get; }
        bool TryUpgradeCapacity();
    }
}