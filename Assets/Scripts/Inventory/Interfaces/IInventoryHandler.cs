
namespace Inventory.Interface
{
    public interface IInventoryHandler 
    {
        string Type { get; set; }
    
        IInteractionInventoryCallback Add(IInventoryHandlerArgs iArgs);
   
        IInteractionInventoryCallback Remove(IInventoryHandlerArgs iArgs);
   
    }
}
