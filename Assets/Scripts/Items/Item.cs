using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "New Item" , fileName = "Item")]
    public class Item : ScriptableObject
    {
        public string Id;

        public string Name;

        public string Type;
    }
}
