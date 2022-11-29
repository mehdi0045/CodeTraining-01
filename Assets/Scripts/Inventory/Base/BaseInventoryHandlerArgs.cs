using System.Collections.Generic;

namespace InventorySystem
{
    public class BaseInventoryHandlerArgs : IInventoryHandlerArgs
    {
        public BaseInventoryHandlerArgs(IItem item, List<ISlot> slots)
        {
            Item = item;
            Slots = slots;
        }

        public IItem Item { get; set; }

        public List<ISlot> Slots { get; set; }
    }
}
