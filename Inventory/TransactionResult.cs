namespace DwarvenSoftware.Framework.Inventory
{
    public struct TransactionResult
    {
        public readonly IInventoryItem Item;
        public readonly int Remainder;

        public TransactionResult(IInventoryItem item, int remainder)
        {
            Item = item;
            Remainder = remainder;
        }
    }
}