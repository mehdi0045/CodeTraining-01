using System.Collections.Generic;
using Extensions.Item;
using Inventory.Interface;

namespace Inventory.Base
{
    public class BaseInventoryHandler : IInventoryHandler
    {
        public BaseInventoryHandler(string type)
        {
            Type = type;
        }

        public string Type { get; set; }

        public IInteractionInventoryCallback Add(IInventoryHandlerArgs iArgs)
        {
            var args = (BaseInventoryHandlerArgs) iArgs;
            
            var freeslot = GetFreeSlot(args.Slots);
            freeslot.Add(args.Item);
            
            return new BaseInteractionInventoryCallback(true, (int) EnumInventoryStatuses.Success,freeslot.Index);
        }

        public IInteractionInventoryCallback Remove(IInventoryHandlerArgs iArgs)
        {
            var args = (BaseInventoryHandlerArgs) iArgs;
            
            var slot =GetSlot(args).Remove(args.Item);
        
            return new BaseInteractionInventoryCallback(true, (int) EnumInventoryStatuses.Success,slot.Index);
        }

        public ISlot GetSlot(IInventoryHandlerArgs iArgs)
        {
            var args = (BaseInventoryHandlerArgs) iArgs;
            
            foreach (var slot in args.Slots)
            {
                if (!slot.IsFree())
                {
                    if (slot.Item.IsEqual(args.Item))
                    {
                        return slot;
                    }
                }
            }
            return null;
        }

        private ISlot GetFreeSlot(List<ISlot> slots)
        {
            foreach (var slot in slots)
            {
                if (slot.IsFree())
                {
                    return slot;
                }
            }
            return null;
        }
    }
}