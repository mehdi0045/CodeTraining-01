using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public delegate void OnPlayerSpawnDelegate(PlayerController player);
    public event OnPlayerSpawnDelegate OnPlayerSpawn;

    [SerializeField] private PlayerController player;
    private void Start()
    {
        OnOnPlayerSpawn(player);
    }

    protected virtual void OnOnPlayerSpawn(PlayerController player)
    {
        OnPlayerSpawn?.Invoke(player);
    }
}
