using UnityEngine;
using ConditionSystem;
using InventorySystem;

public class WeaponInventory : MonoBehaviour
{
    public BaseInventory _inventory;
    void Awake()
    {
        _inventory = new BaseInventory("1","Weapon",8,new ICondition[]
        {
            new InventoryConditionFreeSlot(), 
            new InventoryConditionNotContain(), 
        }, 
            new ICondition[]
            {
                new InventoryConditionContain(), 
            });
        
        _inventory.Init();
    }
}
