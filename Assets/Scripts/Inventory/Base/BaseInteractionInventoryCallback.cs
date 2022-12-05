using Inventory.Interface;

namespace Inventory.Base
{
    public struct BaseInteractionInventoryCallback : IInteractionInventoryCallback
    {
        public BaseInteractionInventoryCallback(bool success, int status, int index)
        {
            Success = success;
            Status = status;
            Index = index;
        }

        public bool Success { get; set; }
        
        public int Status { get; set; }
    
        public int Index { get; set; }
    }
}
