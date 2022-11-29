using InventorySystem;

public class HpBoosterArgs : IActionArgs
{
    public HpBoosterArgs(IInventory inventory, IItem item)
    {
        Inventory = inventory;
        Item = item;
    }
    
    public IInventory Inventory;
    
    public IItem Item;
}
