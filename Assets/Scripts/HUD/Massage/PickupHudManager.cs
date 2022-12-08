using System;
using Inventory.Interface;
using Manager;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PickupHudManager : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private PopupManager popupManager;
    public string popUpId;
    private void OnEnable()
    {
        spawnManager.OnPlayerSpawn += OnPlayerSpawn;
    }

    private void OnDisable()
    {
        spawnManager.OnPlayerSpawn -= OnPlayerSpawn;
    }

    private void OnPlayerSpawn(Controller player)
    {
        player.pickupHandler.OnPickupRange += OnPickupRangeCallback;
        player.pickupHandler.OnOutPickupRange += OnOutPickupRangeCallback;
        player.pickupHandler.OnPickedUp += OnPickedUpCallback;
    }

    private void OnPickupRangeCallback(IItem item)
    {
        popupManager.ShowPopup(popUpId);
    }
    
    private void OnOutPickupRangeCallback()
    {
        popupManager.HidePopup();
    }
    
    private void OnPickedUpCallback(IItem item)
    {
        popupManager.HidePopup();

    }
}
