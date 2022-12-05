using System.Collections.Generic;
using Inventory.Interface;

namespace Inventory.Base
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
