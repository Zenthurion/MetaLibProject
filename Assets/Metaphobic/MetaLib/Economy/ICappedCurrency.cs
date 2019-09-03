namespace MetaLib.Economy
{
    public interface ICappedCurrency : ICurrency
    {
        long Capacity { get; }
    }
}