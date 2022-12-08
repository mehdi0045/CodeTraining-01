using System.Threading.Tasks;

namespace Action.Interface
{
    public interface IAction 
    {
        string Id { get; set; }
        
        string Name { get; set; }
        
        IActionSequence[] ActionSteps { get; set; }
        
        Task<IInteractionCallBack> Action(IActionArgs iArgs);
        
        
    }
}
