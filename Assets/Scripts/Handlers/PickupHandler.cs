using Handlers.Interfaces;
using Inventory.Interface;
using Manager;
using UnityEngine;

public class PickupHandler : MonoBehaviour,IHandler
{
    public delegate void OnPickupRangeDelegate(IItem item);
    public event OnPickupRangeDelegate OnPickupRange;
    
    public delegate void OnOutPickupRangeDelegate();
    public event OnOutPickupRangeDelegate OnOutPickupRange;

    public delegate void OnPickedUpDelegate(IItem item);
    public event OnPickedUpDelegate OnPickedUp;
    
    private IItem item;

    public void Init(IController iController)
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Item"))
        {
            var item = collider.GetComponent<WordItem>().iItem;
            OnOnPickupRange(item);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Item"))
        {
            OnOnOutPickupRange();
        }
    }
    public void PickedUp()
    {
        if (item != null)
        {

            OnOnPickedUp(item);
        }
    }
    protected virtual void OnOnPickupRange(IItem _item)
    {
        item = _item;
        OnPickupRange?.Invoke(item);
    }
    protected virtual void OnOnOutPickupRange()
    {
        item = null;
        OnOutPickupRange?.Invoke();
    }
    protected virtual void OnOnPickedUp(IItem item)
    {
        OnPickedUp?.Invoke(item);
    }
}
