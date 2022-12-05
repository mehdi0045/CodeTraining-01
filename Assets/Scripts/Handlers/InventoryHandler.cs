using Condition.Interface;
using Condition.InventorySystem;
using Inventory.Base;
using UnityEngine;

namespace Handlers
{
    public class InventoryHandler : MonoBehaviour
    {
        public string id;
        public string Inventoryname;
        public int count;
    
        [HideInInspector] public BaseInventory inventory;
    
        void Awake()
        {
            inventory = new BaseInventory(id,Inventoryname,count,new ICondition[]
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
}
