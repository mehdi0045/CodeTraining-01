using InventorySystem;

namespace ConditionSystem
{
    public struct ConditionInventoryArgs : IConditionArgs
    {
        public ConditionInventoryArgs(IInventory inventory, IItem item)
        {
            Inventory = inventory;
            Item = item;
        }

        public IInventory Inventory { get; set; }
        
        public IItem Item { get; set; }
    }
}
