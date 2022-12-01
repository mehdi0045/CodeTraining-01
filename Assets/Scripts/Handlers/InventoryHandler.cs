using UnityEngine;
using ConditionSystem;
using InventorySystem;

public class InventoryHandler : MonoBehaviour
{
    public string id;
    public string name;
    public int count;
    
    [HideInInspector] public BaseInventory inventory;
    
    void Awake()
    {
        inventory = new BaseInventory(id,name,count,new ICondition[]
        {
            new InventoryConditionFreeSlot(), 
            new InventoryConditionNotContain(), 
        }, 
            new ICondition[]
            {
                new InventoryConditionContain(), 
            });
        
        inventory.Init();
    }
}
