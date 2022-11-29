using UnityEngine;
using InventorySystem;

public class ActionManager : MonoBehaviour
{
    
    private IAction hpBosterAction;
    private IInventory inventory;
    private void Awake()
    {

    }

    private void Start()
    {
        hpBosterAction = new HpBoosterAction("01");
    }

    public void ActionHpBosster(Component sender, object data)
    {
                // var callback = hpBosterAction.Action(new HpBoosterArgs(inventory,targetItem));  
                // Debug.Log((EnumActionStatus)callback.Status);

    }
}

