using UnityEngine;
using InventorySystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform camTransform;
    [SerializeField] private Animator _animator;
    
    private MovementComponent movement;
    private float _turnSmothVelocity;
    private CharacterController _controller;
    
    public WeaponInventory _weaponInventory;

    private BaseItem item;
    
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        movement = new MovementComponent(_speed,_turnSmothVelocity,_controller,camTransform,transform);
    }

    private void Update()
    {
        movement.Move(_animator);
    }

    private void Pickup(Collider collider)
    {
        var gameItem =  collider.GetComponent<Collider>().GetComponent<WordGameItem>();
        var callback = _weaponInventory._inventory.Add(gameItem.item);
        Debug.Log((EnumInventoryStatuses)callback.Status);
        gameItem.DestroyObject();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Pickup(collider);
    }
}
