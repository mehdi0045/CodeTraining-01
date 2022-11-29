
namespace InventorySystem
{
    public class BaseSlot : ISlot
    {
        public BaseSlot(int index)
        {
            Index = index;
        }

        public IItem Item { get; set; }
    
        public int Index { get; set; }

        public IInteractionInventoryCallback Add(IItem item)
        {
            Item = item;
            return new BaseInteractionInventoryCallback(true , (int)EnumInventoryStatuses.Success,Index);
        }

        public bool IsFree()
        {
            return Item == null;
        }

        public IInteractionInventoryCallback Remove(IItem item)
        {
            Item = null;
            return new BaseInteractionInventoryCallback(true , (int)EnumInventoryStatuses.Success,Index);
        }
    }

}
