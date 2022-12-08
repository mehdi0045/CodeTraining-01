using Handlers;
using Inventory.Interface;
public class InventoryHandlerLink : IHandlerLink
{
    private InventoryHandler inventoryHandler;

    private PickupHandler pickupHandler;
    
    public void Link(IController controller)
    {
        inventoryHandler = controller.GetHandler<InventoryHandler>();
        pickupHandler = controller.GetHandler<PickupHandler>();

        pickupHandler.OnPickedUp += OnPickedup;
    }

    private void OnPickedup(IItem item)
    {
        inventoryHandler.AddPickedItem(item);
    }
}
