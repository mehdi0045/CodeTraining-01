using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Action.Base;
using Action.Interface;
using Action.Sequences;
using Attribute.Base;
using Condition.Interface;
using Condition.InventorySystem;
using Controllers.Base;
using Handlers;
using Handlers.Interfaces;
using Inventory.Base;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : BaseController
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform camTransform;
    [SerializeField] private Animator _animator;

    private float _turnSmothVelocity;
    private Rigidbody _rb;
    private BaseItem item;

    public InventoryHandler inventoryHandler;
    public AttributeHandler attributeHandler;
    public ActionHandler actionHandler;
    public PickupHandler pickupHandler;
    public InputHandler inputHandler;
    public MovementHandler movementHandler;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        SetupHandlers();
    }

    private void SetupHandlers()
    {
        item = new BaseItem("01", "HpBoster", "TypeA");
        
        
        attributeHandler.Setup(new List<BaseAttribute>()
        {
            new BaseAttribute("Health", 0, 100, 100),
            new BaseAttribute("Mana", 0, 100, 100),
        });

        var action = new BaseAction("01","Dive",new IActionSequence[]
        {
            new ActionJumpSequence(_rb),
            new ActionAnimationSequence(_animator)
        });
        actionHandler.Setup(new IAction[]{action});
        
        var inventory = new BaseInventory("01","Inventoryname",8,new ICondition[]
            {
                new InventoryConditionFreeSlot(), 
                new InventoryConditionNotContain(), 
            }, 
            new ICondition[]
            {
                new InventoryConditionContain(), 
            });
        inventoryHandler.Setup(inventory);
        
        InitAllHandlers();
        SetupHandlerLink();

    }

    private void FixedUpdate()
    {
        movementHandler.Move(_rb,transform);
    }

    private void SetupHandlerLink()
    {
        HandlerLinks = new List<IHandlerLink>();
        
        AddHandlerLink(new ActionHandlerLink());
        AddHandlerLink(new PickupHandlerLink());
        AddHandlerLink(new InventoryHandlerLink());
        AddHandlerLink(new MovementHandlerLink());
        InitHandlersLink(this);
        
    }

    private void InitAllHandlers()
    {
        Handlers = new List<IHandler>();
        AddHandler(inventoryHandler);
        AddHandler(attributeHandler);
        AddHandler(actionHandler);
        AddHandler(pickupHandler);
        AddHandler(inputHandler);
        AddHandler(movementHandler);
        InitHandlers(this);
    }
}