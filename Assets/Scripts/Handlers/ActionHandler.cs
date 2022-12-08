using System;
using Action.Base;
using Action.Interface;
using Action.Sequences;
using Handlers.Interfaces;
using UnityEngine;

namespace Handlers
{
    public class ActionHandler : MonoBehaviour,IHandler
    {
        
        
        private BaseAction action;
        
        public void Init(IController controller)
        {
            
        }
        public void Setup(IAction[] actions)
        {
            
        }
    }
}


