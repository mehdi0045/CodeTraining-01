using System;
using System.Collections.Generic;
using Handlers.Interfaces;
using UnityEngine;

namespace Controllers.Base
{
    public class BaseController : MonoBehaviour, IController
    {
        public List<IHandler> Handlers { get; set; }
        
        public List<IHandlerLink> HandlerLinks { get; set; }

        protected void AddHandler(IHandler handler)
        {
            Handlers.Add(handler);
        }
        protected void RemoveHandler(IHandler handler)
        {
            Handlers.Remove(handler);
        }
        protected void InitHandlers(IController controller)
        {
            foreach (var handler in Handlers)
            {
                handler.Init(controller);
            }
        }
        public T GetHandler<T>() where T : IHandler
        {
            var finder = Handlers.Find(i => i is T);
            return (T) finder;
        }
        
        protected void AddHandlerLink(IHandlerLink handlerlink)
        {
            HandlerLinks.Add(handlerlink);
        }
        
        protected void RemoveHandlerLink(IHandlerLink handlerlink)
        {
            HandlerLinks.Remove(handlerlink);
        }

        protected void InitHandlersLink(IController controller)
        {
            foreach (var handlerLink in HandlerLinks)
            {
                handlerLink.Link(controller);
            }
        }
        public T GetHandlerLink<T>() where T : IHandlerLink
        {
            var finder = HandlerLinks.Find(i => i is T);
            return (T) finder;
        }
    }
}
