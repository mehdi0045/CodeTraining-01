using System.Collections.Generic;
using HUD.Item;
using Inventory.Base;
using Inventory.Interface;
using Manager;
using UnityEditor;
using UnityEngine;

namespace HUD.Inventory
{
    public class InventoryHud : MonoBehaviour
    {
        private BaseInventory _inventory;
        [SerializeField] private ItemHudResource itemHudResource;
        [SerializeField] private SpawnManager spawnManager;

        [SerializeField] private GameObject inventoryUi;
        [SerializeField] private GameObject slotPrefab;
    
        private List<SlotHud> slots = new List<SlotHud>();
    
        public GameObject _slot;
        
        private void OnEnable()
        {
            spawnManager.OnPlayerSpawn += OnPlayerSpawnCallback;
        }

        private void OnDisable()
        {
            UnSubscript();
        }

        private void UnSubscript()
        {
            spawnManager.OnPlayerSpawn -= OnPlayerSpawnCallback;
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
            SubscriptInventory(player.inventoryHandler.GetActiveInventory());
            player.inputHandler.OnInputInventory += OnInputInentoryCallback;
        }

        private void OnItemAddedCallback(IInventory inventory, IItem item , int index)
        {
            AddItemHud(item,index);
        }
    
        private void OnItemRemovedCallback(IInventory inventory, IItem item , int index)
        {
            RemoveItemHud(item,index);
        }
        private void OnInputInentoryCallback()
        {
            if (inventoryUi.activeSelf)
            {
                EmptyInventory();
                inventoryUi.SetActive(false);
            }
            else
            {
                CheckInventory();
                inventoryUi.SetActive(true);
            }
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

            itemHudResource.FindItem(item.Id, out var lItem);
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

        private void EmptyInventory()
        {
            foreach (var slotHud in slots)
            {
                slotHud.EmptySLot();
            }
        }
        
        private void CheckInventory()
        {
            foreach (var slot in _inventory.Slots)
            {
                if (!slot.IsFree())
                {
                    AddItemHud(slot.Item,slot.Index);
                }
            }
        }
    }
}
