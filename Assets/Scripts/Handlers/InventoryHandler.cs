using Condition.Interface;
using Condition.InventorySystem;
using Handlers.Interfaces;
using Inventory.Base;
using Inventory.Interface;
using UnityEngine;

namespace Handlers
{
    public class InventoryHandler : MonoBehaviour,IHandler
    {
        public string id;
        public string Inventoryname;
        public int count;
        private BaseInventory _inventory;
    
        public void Init(IController controller)
        {
            _inventory.Init();
        }
        public void Setup(BaseInventory inventory)
        {
            _inventory = inventory;
        }

        public BaseInventory GetActiveInventory()
        {
            return _inventory;
        }

        public void AddPickedItem(IItem item)
        {
            var callback = _inventory.Add(item);
            Debug.Log((EnumInventoryStatuses) callback.Status);
        }
    }
}
