using System;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemHolder itemHolder;
    
    public bool FindItem(string id , out ItemHud itemHud)
    {
        var find = Array.Find(itemHolder.ItemInfos, i => i.Id == id);
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
