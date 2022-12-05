using System;
using UnityEngine;

namespace HUD.Item
{
    public class ItemHudManager : MonoBehaviour
    {
        public ItemHudHolder itemHudHolder;
    
        public bool FindItem(string id , out ItemHud itemHud)
        {
            var find = Array.Find(itemHudHolder.ItemInfos, i => i.Id == id);
            var itemObject = Resources.Load<ItemHud>(find.ResourcePath);
            if (itemObject == null)
            {
                itemHud = null;
                return false;
            }
        
            itemHud = itemObject;
            return true;
        }
    }
}
