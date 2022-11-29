using InventorySystem;

public interface IAction 
{
    string Id { get; set; }
    
    IInteractionInventoryCallback Action(IActionArgs iArgs);
}
