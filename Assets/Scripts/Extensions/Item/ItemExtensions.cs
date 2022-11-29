using InventorySystem;

namespace Extensions
{
    public static class ItemExtensions
    {
        public static bool IsEqual(this IItem item, IItem target)
        {
            return item.Id == target.Id;
        }
    }
}
