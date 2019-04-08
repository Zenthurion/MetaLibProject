namespace DwarvenSoftware.Framework.Inventory
{
    public struct TransactionResult
    {
        public readonly IInventoryItem Item;
        public readonly int Remainder;
        public readonly bool Successful;

        public TransactionResult(IInventoryItem item, int remainder, bool successful)
        {
            Item = item;
            Remainder = remainder;
            Successful = successful;
        }
    }
}