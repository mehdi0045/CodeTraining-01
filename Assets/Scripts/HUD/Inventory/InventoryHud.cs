using System.Collections.Generic;
using Handlers;
using HUD.Item;
using Inventory.Base;
using Inventory.Interface;
using UnityEditor;
using UnityEngine;

namespace HUD.Inventory
{
    public class InventoryHud : MonoBehaviour
    {
        private BaseInventory _inventory;
        [SerializeField] private ItemHudManager itemHudManager;
        [SerializeField] private SpawnHandler spawnHandler;

        [SerializeField] private GameObject slotPrefab;
    
        private List<SlotHud> slots = new List<SlotHud>();
    
        public GameObject _slot;

        private void OnEnable()
        {
            spawnHandler.OnPlayerSpawn += OnPlayerSpawnCallback;
        }

        private void OnDisable()
        {
            UnSubscript();
        }

        private void UnSubscript()
        {
            spawnHandler.OnPlayerSpawn -= OnPlayerSpawnCallback;
            _inventory.OnItemAdded -= OnItemAddedCallback;
            _inventory.OnItemAdded -= OnItemRemovedCallback;
        }

        private void SubscriptInventory(BaseInventory inventory)
        {
            _inventory = inventory; 
            CreateSlots(_inventory._slotCount);
        
            _inventory.OnItemAdded += OnItemAddedCallback;
            _inventory.OnItemRemove += OnItemRemovedCallback;
        }

        #region Events
        private void OnPlayerSpawnCallback(Controller player)
        {
            SubscriptInventory(player.inventoryHandler.inventory);
        }
    
        
        private void OnItemAddedCallback(IInventory inventory, IItem item , int index)
        {
            AddItemHud(item,index);
        }
    
        private void OnItemRemovedCallback(IInventory inventory, IItem item , int index)
        {
            RemoveItemHud(item,index);
        }

        #endregion
    
        private void CreateSlots(int slotCount)
        {
            for (int i = 0; i < slotCount; i++)
            {
                var lSlot = PrefabUtility.InstantiatePrefab(slotPrefab) as GameObject;
                lSlot.transform.SetParent(_slot.transform, 
                    false);
                var SlotScript = lSlot.GetComponent<SlotHud>();
                slots.Add(SlotScript);
                SlotScript.index = i;
            }   
        }
    
        private void AddItemHud(IItem item , int index)
        {
            var slot = GetSlotByIndex(index);
            itemHudManager.FindItem(item.Id, out var lItem);
            slot.SetSlot(lItem,item);
        }
    
        private void RemoveItemHud( IItem item ,int index)
        {
            var slot = GetSlotByIndex(index);
            slot.EmptySLot();
        }
    
        private SlotHud GetSlotByIndex(int index)
        {
            return slots[index];
        }
    }
}
