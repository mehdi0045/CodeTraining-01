using System.Collections;
using System.Collections.Generic;
using Handlers;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementHandlerLink : IHandlerLink
{
    private MovementHandler movementHandler;
    
    private InputHandler inputHandler;
    public void Link(IController controller)
    {
        movementHandler = controller.GetHandler<MovementHandler>();
        inputHandler = controller.GetHandler<InputHandler>();
        
        inputHandler.OnInputMove += OnInputMoveCallback;
    }

    private void OnInputMoveCallback(InputValue value)
    {
        movementHandler.MoveInput(value);
    }
}
