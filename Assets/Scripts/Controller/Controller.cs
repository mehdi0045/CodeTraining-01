using System.Collections.Generic;
using System.Threading.Tasks;
using Action.Base;
using Action.Interface;
using Action.Sequences;
using Attribute.Base;
using Handlers;
using Inventory.Base;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform camTransform;
    [SerializeField] private Animator _animator;
    
    private MovementComponent movement;
    private float _turnSmothVelocity;
    private CharacterController _controller;
    private BaseItem item;

    public InventoryHandler inventoryHandler;
    public AttributeHandler attributeHandler;
    private BaseAction action;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        movement = new MovementComponent(_speed,_turnSmothVelocity,_controller,camTransform,transform);
        
        action = new BaseAction("01","Log",new IActionSequence[]
        {
            new ActionSequence1(),
            new ActionSequence2(), 
        });
        
        attributeHandler.Init(new List<BaseAttribute>()
        {
            new BaseAttribute("Health",0,100,100),
            new BaseAttribute("Mana",0,100,100),
        });
    }

    private async Task Update()
    {
        movement.Move(_animator);
        if (Input.GetKeyDown(KeyCode.J))
        {
            await action.Action(new BaseActionArgs());
        }
    }

    private void Pickup(Collider collider)
    {
        var gameItem =  collider.GetComponent<Collider>().GetComponent<ItemHandler>();
        var callback = inventoryHandler.inventory.Add(gameItem.iItem);
        Debug.Log((EnumInventoryStatuses)callback.Status);
        gameItem.DestroyObject();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Pickup(collider);
    }
}
