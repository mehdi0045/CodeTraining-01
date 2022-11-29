using System;
using System.Collections.Generic;
using InventorySystem;

namespace ConditionSystem
{
    public class InventoryConditionFreeSlot : ICondition
    {
        public string Id { get; set; }
        
        public IConditionCallback Check(IConditionArgs iArgs)
        {
            var args = (ConditionInventoryArgs) iArgs;
            var have = GetFreeSlot(args.Inventory.Slots, out var freeSlot);
            if (have)
            {
                return  new ConditionInventoryCallback(have, (int)EnumInventoryStatuses.Success);
            }
            else
            {
                return  new ConditionInventoryCallback(have, (int)EnumInventoryStatuses.InventoryIsFull);
            }
        }
        private bool GetFreeSlot(List<ISlot> slots, out ISlot freeSlot)
        {
            foreach (var slot in slots)
            {
                if (slot.IsFree())
                {
                    freeSlot = slot;
                    return true;
                }
            }

            freeSlot = null;
            return false;
        }
    }
}
