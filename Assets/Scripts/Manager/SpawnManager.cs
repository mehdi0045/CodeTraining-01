using UnityEngine;

namespace Manager
{
    public class SpawnManager : MonoBehaviour
    {
        public delegate void OnPlayerSpawnDelegate(Controller player);
        public event OnPlayerSpawnDelegate OnPlayerSpawn;

        [SerializeField] private Controller player;
        private void Start()
        {
            OnOnPlayerSpawn(player);
        }

        protected virtual void OnOnPlayerSpawn(Controller player)
        {
            OnPlayerSpawn?.Invoke(player);
        }
    }
}
