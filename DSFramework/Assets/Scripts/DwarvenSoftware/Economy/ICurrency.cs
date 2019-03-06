namespace DwarvenSoftware.Economy
{
    public interface ICurrency
    {
        string Name { get; }
        long Value { get; }
        bool TrySpend(long amount);
        void Add(long amount);
    }
}