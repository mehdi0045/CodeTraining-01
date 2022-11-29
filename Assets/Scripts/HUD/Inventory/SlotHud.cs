using UnityEngine;
using UnityEngine.UI;
using InventorySystem;

public class SlotHud : MonoBehaviour
{
    
    
    public int index;

    [SerializeField] private Image imageIcon;
    [SerializeField] private bool fill;
    
    private IItem _item;

    public void SetSlot(ItemHud itemHudObject,IItem item)
    {
        imageIcon.sprite = itemHudObject.Icon;
        _item = item;
        fill = true;
    }
    
    public void EmptySLot()
    {
        if (fill)
        {
            imageIcon.sprite = null;
            _item = null;
            fill = false;    
        }
    }
}
