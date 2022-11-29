
namespace InventorySystem
{
    public interface IInteractionInventoryCallback 
    {
        bool Success { get; set; }
    
        int Status { get; set; }

        int Index { get; set; }
    }
}
