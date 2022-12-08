using System.Collections.Generic;
using Handlers.Interfaces;

public interface IController
{ 
    List<IHandler> Handlers { get; set; }
    
    List<IHandlerLink> HandlerLinks { get; set; }
    
    T GetHandler<T>() where T : IHandler;
    
}
