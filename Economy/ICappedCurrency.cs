namespace DwarvenSoftware.Framework.Economy
{
    public interface ICappedCurrency : ICurrency
    {
        long Capacity { get; }
    }
}