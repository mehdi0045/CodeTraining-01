using Inventory.Interface;
using Items;
using Manager;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private WordItem testItem;
    
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
        player.pickupHandler.OnPickedUp += OnPickedUpCallback;
    }

    private void OnPickedUpCallback(IItem item)
    {           
        if (testItem.iItem.Id == item.Id)
        {
            Destroy(testItem.gameObject);
        }
    }
}
