using Cinemachine;
using InventorySystem;
using UnityEngine;

public class WordGameItem : MonoBehaviour
{
    public IItem item;
    [SerializeField] private GameItem gameItem;

    private void Awake()
    {
        item = new BaseItem(gameItem.Id,gameItem.Name,gameItem.Type);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
