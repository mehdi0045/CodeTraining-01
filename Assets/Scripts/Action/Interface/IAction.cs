
using System.Threading.Tasks;
using Action.Interface;

namespace Action
{
    public interface IAction 
    {
        string Id { get; set; }
        
        string Name { get; set; }
        
        IActionStep[] ActionSteps { get; set; }
        
        Task<IInteractionCallBack> Action(IActionArgs iArgs);
    }
}
