namespace DwarvenSoftware.Framework.Economy
{
    public interface ICurrencyCapacity
    {
        long this[int index] { get; }
        int Count { get; }
        long GetCapacity(int index);
    }
}