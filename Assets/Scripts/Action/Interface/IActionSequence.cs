using System.Collections.Generic;
using System.Threading.Tasks;

namespace Action.Interface
{
    public interface IActionSequence 
    {
        string Id { get; set; }
        
        string Name { get; set; }

        Task<IInteractionCallBack> ActionStep(IActionArgs iArgs, Dictionary<string, object> customData);
    }
}
