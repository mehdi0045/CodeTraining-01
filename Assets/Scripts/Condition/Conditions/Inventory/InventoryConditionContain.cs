using System.Collections.Generic;
using Extensions;
using InventorySystem;

namespace ConditionSystem
{
    public class InventoryConditionContain : ICondition
    {
        public string Id { get; set; }
        public IConditionCallback Check(IConditionArgs iArgs)
        {
            var args = (ConditionInventoryArgs) iArgs;
            var have = Contain(args.Inventory.Slots,args.Item);
            if (have)
            {
                return  new ConditionInventoryCallback(true, (int)EnumInventoryStatuses.Success);
            }
            else
            {
                return  new ConditionInventoryCallback(false, (int)EnumInventoryStatuses.ItemIsNotExist);
            }
        }
        private bool Contain(List<ISlot> slots, IItem item)
        {
            foreach (var slot in slots)
            {
                if (!slot.IsFree())
                {
                    if (slot.Item.IsEqual(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
