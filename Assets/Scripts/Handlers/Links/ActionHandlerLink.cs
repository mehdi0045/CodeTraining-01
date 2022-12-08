using Handlers;
using Inventory.Interface;using UnityEngine;

public class ActionHandlerLink :  IHandlerLink
{
    private ActionHandler _actionHandler;
    private InventoryHandler _inventoryHandler;
    
    public void Link(IController controller)
    {
        _actionHandler = controller.GetHandler<ActionHandler>();
        _inventoryHandler = controller.GetHandler<InventoryHandler>();

        _inventoryHandler.GetActiveInventory().OnItemAdded += OnItemAddedCallback;
        _inventoryHandler.GetActiveInventory().OnItemRemove += OnItemRemoveCallback;
    }

    private void OnItemAddedCallback(IInventory inventory, IItem item, int index)
    {
    }
    
    private void OnItemRemoveCallback(IInventory inventory, IItem item, int index)
    {

    }
}
