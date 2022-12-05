
namespace Inventory.Interface
{
    public interface ISlot 
    {
        IItem Item { get; set; }
    
        int Index { get; set; }
    
        bool IsFree();
    
        IInteractionInventoryCallback Add(IItem item);

        IInteractionInventoryCallback Remove(IItem item);
    }
}

