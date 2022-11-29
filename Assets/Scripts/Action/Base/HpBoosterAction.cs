using InventorySystem;

public class HpBoosterAction : IAction
{
    public HpBoosterAction(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
    
    public IInteractionInventoryCallback Action(IActionArgs iArgs)
    {
        var args = (HpBoosterArgs) iArgs;
        
        var Result = args.Inventory.Contain(args.Item).Success;
        if (Result)
        {
            return new BaseInteractionInventoryCallback(true,(int) EnumActionStatus.ActionSucces,-1);
        }
        else
            return new BaseInteractionInventoryCallback(false,(int) EnumActionStatus.NotEnough,-1);
    }
}
