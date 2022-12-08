using Handlers.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Handlers
{
    public class InputHandler : MonoBehaviour , IHandler
    {
        #region Events

        public delegate void OnInputPickupDelegate();
        public event OnInputPickupDelegate OnInputPickup;
    
        public delegate void OnInputInventoryDelegate();
        public event OnInputPickupDelegate OnInputInventory;
        
        public delegate void OnInputMoveDelegate(InputValue value);
        public event OnInputMoveDelegate OnInputMove;

        #endregion

        public void Init(IController iController)
        {
        
        }
        
        #region Actions

        public void OnPickup(InputValue value)
        {
            OnOnItemPickup();
        }

        public void OnInventory(InputValue value)
        {
            OnOnInputInventory();
        }

        #endregion

        #region Axis

        public void OnMove(InputValue value)
        {
            OnOnInputMove(value);
        }

        #endregion

        #region Events Invoker

        protected virtual void OnOnItemPickup()
        {
            OnInputPickup?.Invoke();
        }

        protected virtual void OnOnInputInventory()
        {
            OnInputInventory?.Invoke();
        }
        
        protected virtual void OnOnInputMove(InputValue value)
        {
            OnInputMove?.Invoke(value);
        }
        
        #endregion
    }
}
