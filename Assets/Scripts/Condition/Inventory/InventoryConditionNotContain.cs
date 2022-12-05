using System.Collections.Generic;
using Condition.Interface;
using Extensions.Item;
using Inventory.Interface;

namespace Condition.InventorySystem
{
    public class InventoryConditionNotContain : ICondition
    {
        public string Id { get; set; }
        public IConditionCallback Check(IConditionArgs iArgs)
        {
            var args = (ConditionInventoryArgs) iArgs;
            var have = Contain(args.Inventory.Slots,args.Item);
            if (have)
            {
                return  new ConditionInventoryCallback(false, (int)EnumInventoryStatuses.ItemAlreadyExist);
            }
            else
            {
                return  new ConditionInventoryCallback(true, (int)EnumInventoryStatuses.Success);
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
