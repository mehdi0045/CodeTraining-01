using InventorySystem;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public IItem iItem;
    [SerializeField] private Item item;

    private void Awake()
    {
        iItem = new BaseItem(item.Id,item.Name,item.Type);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
