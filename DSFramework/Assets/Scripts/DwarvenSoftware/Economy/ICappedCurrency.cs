namespace DwarvenSoftware.Economy
{
    public interface ICappedCurrency : ICurrency
    {
        long Capacity { get; }
    }
}