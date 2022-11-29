using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using InventorySystem;

public class InventoryHud : MonoBehaviour
{
    private BaseInventory _inventory;

    [SerializeField] private ItemManager _itemManager;
    [SerializeField] private SpawnManager _spawnManager;

    [SerializeField] private GameObject _slotPrefab;
    
    private List<SlotHud> slots = new List<SlotHud>();
    
    public GameObject _slot;

    private void OnEnable()
    {
        _spawnManager.OnPlayerSpawn += OnPlayerSpawnCallback;
    }

    private void OnDisable()
    {
        _spawnManager.OnPlayerSpawn -= OnPlayerSpawnCallback;
        _inventory.OnItemAdded -= OnItemAddedCallback;
        _inventory.OnItemAdded -= OnItemRemovedCallback;
    }

    #region Events
    private void OnPlayerSpawnCallback(PlayerController player)
    {
        _inventory = player._weaponInventory._inventory; 
        CreateSlots(_inventory._slotCount);
        
        _inventory.OnItemAdded += OnItemAddedCallback;
        _inventory.OnItemRemove += OnItemRemovedCallback;
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
            var Slot = PrefabUtility.InstantiatePrefab(_slotPrefab) as GameObject;
            Slot.transform.SetParent(_slot.transform, false);
            var SlotScript = Slot.GetComponent<SlotHud>();
            slots.Add(SlotScript);
            SlotScript.index = i;
        }   
    }
    
    private void AddItemHud(IItem item , int index)
    {
        var slot = GetSlotByIndex(index);
        _itemManager.FindItem(item.Id, out var lItem);
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
