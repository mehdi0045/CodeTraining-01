using Inventory.Base;
using Inventory.Interface;
using Items;
using UnityEngine;

namespace Manager
{
    public class WordItem : MonoBehaviour
    {
        public IItem iItem;
        [SerializeField] private Item item;

        private void Awake()
        {
            iItem = new BaseItem(item.Id,item.Name,item.Type);
        }
    }
}
